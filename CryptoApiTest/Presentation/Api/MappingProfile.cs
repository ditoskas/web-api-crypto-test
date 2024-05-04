using AutoMapper;
using Entities.Models;
using Shared.DataTransferObject;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Crypto, CryptoDto>();
            //CreateMap<Entities.Crypto, Models.CryptoForCreationDto>();
            //CreateMap<Entities.Crypto, Models.CryptoForUpdateDto>();
            CreateMap<CryptoForCreationDto, Crypto>();
            CreateMap<CryptoForUpdateDto, Crypto>();
            CreateMap<CryptoNetwork, CryptoNetworkDto>().ForMember(c => c.Symbol, opt => opt.MapFrom(x => x.Crypto.Symbol));
            CreateMap<CryptoBlock, CryptoBlockDto>()
                .ForMember(c => c.Txids, opt => opt.MapFrom(x => x.Txids.Select(txid => txid.Hash).ToList()))
                .ForMember(c => c.InternalTxids, opt => opt.MapFrom(x => x.InternalTxids.Select(txid => txid.Hash).ToList()));
        }
    }
}
