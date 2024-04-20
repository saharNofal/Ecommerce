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

namespace SimpleEcommerce.Application.Features.Products.Queries
{
    internal class GetCatagoryListQueryHandler : IRequestHandler<GetProductByCategoryQuery, List<ProductVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCatagoryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async  Task<List<ProductVM>> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var allProudect= new List<Product>();
            if (request.CategoryId >0)
                allProudect= await _unitOfWork.ProductRepository.GetByCategoryAsync((int)request.CategoryId);
            else
                allProudect= (List<Product>)await _unitOfWork.ProductRepository.ListAllAsync();
            return _mapper.Map<List<ProductVM>>(allProudect);
        }
    }
}
