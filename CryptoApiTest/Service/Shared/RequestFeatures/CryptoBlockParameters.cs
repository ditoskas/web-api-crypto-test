namespace Shared.RequestFeatures
{
    /// <summary>
    /// Get parameters that we can use to filter, sort and search for CryptoBlock on the API
    /// Available parameters are: PageNumber, PageSize, OrderBy, Hash, HeightMin, HeightMax, TimeMin, TimeMax, Chain, 
    /// </summary>
    public class CryptoBlockParameters : RequestParameters
    {
        public string? Hash { get; set; }
        public uint HeightMin { get; set; }
        public uint HeightMax { get; set; } = uint.MaxValue;
        public DateTime? TimeMin { get; set; }
        public DateTime? TimeMax { get; set; }
        public string? Chain { get; set; }
    }
}
