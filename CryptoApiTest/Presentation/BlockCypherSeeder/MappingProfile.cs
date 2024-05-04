using AutoMapper;
using BlockCypher.Models;
using Entities.Models;
using Shared.DataTransferObject;

namespace BlockCypherSeeder
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping for automapper library that required by the BlockCypherSeeder application
        /// </summary>
        public MappingProfile()
        {
            CreateMap<BlockCypherCryptoBlock, CryptoBlockForManipulationDto>();
            CreateMap<CryptoBlockForManipulationDto, CryptoBlock>();
            CreateMap<string, CryptoTransaction>().ConvertUsing(src => new CryptoTransaction { Hash = src, CreatedAt = DateTime.UtcNow });
            CreateMap<string, CryptoInternalTransaction>().ConvertUsing(src => new CryptoInternalTransaction { Hash = src, CreatedAt = DateTime.UtcNow });
            CreateMap<CryptoNetwork, CryptoNetworkDto>().ForMember(c => c.Symbol, opt => opt.MapFrom(x => x.Crypto.Symbol));
            CreateMap<CryptoBlock, CryptoBlockDto>()
                .ForMember(c => c.Txids, opt => opt.MapFrom(x => x.Txids.Select(txid => txid.Hash).ToList()))
                .ForMember(c => c.InternalTxids, opt => opt.MapFrom(x => x.InternalTxids.Select(txid => txid.Hash).ToList()));
        }
    }
}
