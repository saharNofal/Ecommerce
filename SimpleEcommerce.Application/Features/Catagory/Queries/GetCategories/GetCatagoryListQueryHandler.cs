using AutoMapper;
using MediatR;
using SimpleEcommerce.Application.Contracts;
using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Catagory.Queries.GetCategories
{
    public class GetCatagoryListQueryHandler : IRequestHandler<GetCatagoryListQuery, List<CatagoryListVM>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetCatagoryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_unitOfWork.CategoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CatagoryListVM>> Handle(GetCatagoryListQuery request, CancellationToken cancellationToken)
        {
            var allCatagory = await _unitOfWork.CategoryRepository.ListAllAsync();
            return _mapper.Map<List<CatagoryListVM>>(allCatagory);
        }
    }
}
