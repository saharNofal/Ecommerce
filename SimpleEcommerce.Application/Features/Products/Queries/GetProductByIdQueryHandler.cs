using AutoMapper;
using MediatR;
using SimpleEcommerce.Application.Contracts;
using SimpleEcommerce.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Products.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductVM>
    {
        //private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByIdQueryHandler( IUnitOfWork unitOfWork, IMapper mapper)
        {
           // _productRepository = productRepository;
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductVM> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
            var ProductViewModel= _mapper.Map<ProductVM>(product);
            return ProductViewModel;
        }
    }
}
