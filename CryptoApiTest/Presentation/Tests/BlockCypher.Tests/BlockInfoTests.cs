using BlockCypher.Models;
using Xunit;

namespace BlockCypher.Tests
{
    public class BlockInfoTests
    {
        [Fact]
        public void JsonDeserialized_Succeeds()
        {

            string url = "https://api.blockcypher.com/v1/eth/main/blocks/4682a0772e3a89201f471a6e6b30d6214c474a40fd94c7c8499a6f62b47edfe9";
            BlockCypherCryptoBlock? block = BlockCypherHttpHandler.Instance.GetAsync<BlockCypherCryptoBlock>(url).Result;
            Assert.NotNull(block);
            Assert.Equal("4682a0772e3a89201f471a6e6b30d6214c474a40fd94c7c8499a6f62b47edfe9", block.Hash);
            Assert.Equal(19761095, block.Height);
            Assert.Equal("ETH.main", block.Chain);
            Assert.Equal("30317987268942582822", block.Total);
            Assert.Equal(274061416721791709, block.Fees);
            Assert.Equal(10121544913, block.BaseFee);
            Assert.Equal(65102, block.Size);
            Assert.Equal("2024-04-29", block.Time.ToString("yyyy-MM-dd"));
            Assert.Equal("2024-04-29", block.ReceivedTime.ToString("yyyy-MM-dd"));
            Assert.Equal("95222290dd7278aa3ddd389cc1e1d165cc4bafe5", block.CoinbaseAddr);
            Assert.Equal("", block.RelayedBy);
            Assert.Equal(0, block.Nonce);
            Assert.Equal(187, block.NTx);
            Assert.Equal("67232e2e36a11c35bf05e2e671968ddb84b96e1cbc7ca223d04f93731c28f2fd", block.PrevBlock);
            Assert.Equal("7f00a317f780bd172b265ac5ecb91cd41e3e5b43db2fbe91971ad4dc010618f1", block.MrklRoot);
            Assert.Equal(20, block.Txids.Count);
            Assert.Equal(558, block.InternalTxids.Count);
            Assert.True(block.Depth > 0);
            Assert.Equal("https://api.blockcypher.com/v1/eth/main/blocks/67232e2e36a11c35bf05e2e671968ddb84b96e1cbc7ca223d04f93731c28f2fd", block.PrevBlockUrl);
            Assert.Equal("https://api.blockcypher.com/v1/eth/main/txs/", block.TxUrl);
            Assert.Equal("https://api.blockcypher.com/v1/eth/main/blocks/4682a0772e3a89201f471a6e6b30d6214c474a40fd94c7c8499a6f62b47edfe9?txstart=20&limit=20", block.NextTxids);
        }
    }
}
