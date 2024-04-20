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
    public class GetProductByUserIdQueryHandler : IRequestHandler<GetProductByUserIdQuery, List<ProductVM>>
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByUserIdQueryHandler( IUnitOfWork unitOfWork, IMapper mapper)
        {
           
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductVM>> Handle(GetProductByUserIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.WishlistRepository.FindByAsnc(x=>x.UserId == request.UserId);
            var productIds = product.ToList().Select(x => x.ProductId);
            var products = await _unitOfWork.ProductRepository.FindByAsnc(x => productIds.Contains(x.ProductId));
            var ProductViewModel = _mapper.Map<List<ProductVM>>(products);
            return ProductViewModel;
        }
    }
    public class GetProductByUserIdQuery : IRequest<List<ProductVM>>
    {
        private string id;

        public string UserId { get; set; }

        public GetProductByUserIdQuery(string userId)
        {
            UserId = userId;
        }

        
    }
}
