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
            //CreateMap<Models.CryptoForCreationDto, Entities.Crypto>();
            //CreateMap<Models.CryptoForUpdateDto, Entities.Crypto>();
        }
    }
}
