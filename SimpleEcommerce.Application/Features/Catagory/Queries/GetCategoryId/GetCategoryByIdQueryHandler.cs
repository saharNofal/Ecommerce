using AutoMapper;
using MediatR;
using SimpleEcommerce.Application.Contracts;
using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Application.Features.Catagory.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Catagory.Queries.GetCategoryId
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryIdQuery, CatagoryListVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;  
            _mapper = mapper;
        }

        public async Task<CatagoryListVM> Handle(GetCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var product = await  _unitOfWork.CategoryRepository.GetByIdAsync(request.CatagoryId);
            var ProductViewModel = _mapper.Map<CatagoryListVM>(product);
            return ProductViewModel;
        }
    }
}


