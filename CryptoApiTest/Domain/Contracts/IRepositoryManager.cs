namespace Contracts
{
    public interface IRepositoryManager
    {
        ICryptoRepository Crypto { get; }
        ICryptoNetworkRepository CryptoNetwork { get; }
        ICryptoBlockRepository CryptoBlock { get; }
        Task SaveAsync();
    }
}
