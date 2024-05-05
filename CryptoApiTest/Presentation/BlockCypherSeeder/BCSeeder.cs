using AutoMapper;
using BlockCypher;
using BlockCypher.Models;
using Service.Contracts;
using Shared.DataTransferObject;

namespace BlockCypherSeeder
{
    public class BCSeeder
    {
        /// <summary>
        /// Seed the database with the latest blocks from the network
        /// if the action is seed, then the system is reading the oldest in time cryptoblock, it will get the previous url and populate the database recurvively 
        /// until the number of records to read is reached
        /// On other hand if it is update, the system will read the last block from the BlockCypher Network API and populate the database with the latest blocks
        /// until it finds a hash that already exists in the database or the number of records to read is reached
        /// </summary>
        /// <param name="serviceManager"></param>
        /// <param name="mapper"></param>
        /// <param name="crypto"></param>
        /// <param name="network"></param>
        /// <param name="recordsToRead"></param>
        public static void Seed(IServiceManager serviceManager, IMapper mapper, string crypto, string network, int recordsToRead, string action)
        {
            if (crypto == "all")
            {
                var cryptoNetworks = serviceManager.CryptoNetworkService.GetAllCryptoWithNetworkAsync(false).Result;
                foreach (var cryptoNetwork in cryptoNetworks)
                {
                    SeedNetwork(serviceManager, mapper, cryptoNetwork.Symbol, cryptoNetwork.Name, recordsToRead, action).Wait();
                }
            }
            else
            {
                SeedNetwork(serviceManager, mapper, crypto, network, recordsToRead, action).Wait();
            }
        }
        public static async Task SeedNetwork(IServiceManager serviceManager, IMapper mapper, string crypto, string network, int recordsToRead, string action)
        {
            try
            {
                Console.WriteLine($"Execute Seeder for {crypto}.{network}");
                //check if crypto network exists
                var cryptoWithNetwork = await serviceManager.CryptoNetworkService.GetCryptoWithNetworkAsync(crypto, network, false);
                if (cryptoWithNetwork != null)
                {
                    long cryptoNetworkId = cryptoWithNetwork.Id;
                    string? latestUrl = string.Empty;
                    if (action != "seed")
                    {
                        // We want to continue the seeding so we read the last url from our DB
                        var lastCryptoBlock = await serviceManager.CryptoBlockService.GetFirstCryptoBlockOfNetworkAsync(cryptoNetworkId);
                        if (lastCryptoBlock != null)
                        {
                            latestUrl = lastCryptoBlock.PrevBlockUrl;
                        }
                    }
                    if (string.IsNullOrEmpty(latestUrl))
                    {
                        // we dont have any block stored in our DB, or the action is not seed, read from the Network api
                        latestUrl = await BlockCypherHttpHandler.Instance.GetLastNetworkUrlAsync(crypto, network);
                        if (string.IsNullOrEmpty(latestUrl))
                        {
                            Console.Error.WriteLine($"Error getting last URL for {crypto}.{network}");
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(latestUrl))
                    {
                        int recordsStored = 0;
                        for (int i = 0; i < recordsToRead; i++)
                        {
                            var blockInfo = await BlockCypherHttpHandler.Instance.GetBlockInfoAsync(latestUrl);
                            if (blockInfo != null)
                            {
                                CryptoBlockForManipulationDto blockToSave = mapper.Map<CryptoBlockForManipulationDto>(blockInfo);
                                //check if the hash exists in our DB
                                var existingBlock = await serviceManager.CryptoBlockService.GetByHashAsync(blockToSave.Hash);
                                if (existingBlock != null)
                                {
                                    Console.WriteLine($"End of execution block with hash: {blockToSave.Hash} already exists in the database");
                                    break;
                                }
                                var createdBlock = await serviceManager.CryptoBlockService.CreateCryptoBlockAsync(cryptoNetworkId, blockToSave);
                                Console.WriteLine($"Block with id: {createdBlock.Id} has been created");
                                Console.WriteLine($"Block Hash: {createdBlock.Hash}");
                                Console.WriteLine($"Number of Transactions: {createdBlock.Txids.Count}");
                                latestUrl = createdBlock.PrevBlockUrl;
                                recordsStored = i;
                                //Delay to avoid rate limit of 3 requests per second
                                Task.Delay(500).Wait();

                            }
                            else
                            {
                                Console.Error.WriteLine($"Error getting block info: {latestUrl}");
                                break;
                            }
                        }
                        Console.WriteLine($"Store of {recordsStored}/{recordsToRead} blocks of {crypto}.{network} have been updated");
                    }
                }
                else
                {
                    Console.Error.WriteLine($"Crypto with network {crypto}.{network} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error executing seeder for {crypto}.{network}: {ex.Message}");
            }
        }
    }
}
