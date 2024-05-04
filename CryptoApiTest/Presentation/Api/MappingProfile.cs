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
        }
    }
}
