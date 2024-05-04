namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICryptoService CryptoService { get; }
        ICryptoBlockService CryptoBlockService { get; }
        ICryptoNetworkService CryptoNetworkService { get; }
    }
}
