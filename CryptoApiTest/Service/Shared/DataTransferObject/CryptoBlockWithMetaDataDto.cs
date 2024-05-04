using Shared.RequestFeatures;

namespace Shared.DataTransferObject
{
    public sealed class CryptoBlockWithMetaDataDto
    {
        public CryptoBlockWithMetaDataDto(IEnumerable<CryptoBlockDto> cryptoBlocks, MetaData metaData)
        {
            CryptoBlocks = cryptoBlocks;
            MetaData = metaData;
        }

        public IEnumerable<CryptoBlockDto> CryptoBlocks { get; private set; }
        public MetaData MetaData { get; private set; }
    }
}
