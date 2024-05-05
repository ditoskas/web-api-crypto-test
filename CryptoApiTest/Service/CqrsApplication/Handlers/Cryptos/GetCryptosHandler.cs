using AutoMapper;
using Contracts;
using CqrsApplication.Queries.Cryptos;
using MediatR;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsApplication.Handlers.Cryptos
{
    public sealed class GetCryptosHandler : IRequestHandler<GetCryptosQuery, IEnumerable<CryptoDto>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetCryptosHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CryptoDto>> Handle(GetCryptosQuery request, CancellationToken cancellationToken)
        {
            var cryptos = await _repository.Crypto.GetAllCryptosAsync(request.trackChanges);
            return _mapper.Map<IEnumerable<CryptoDto>>(cryptos);
        }
    }
}
