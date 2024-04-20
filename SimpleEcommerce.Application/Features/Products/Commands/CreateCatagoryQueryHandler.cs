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

namespace SimpleEcommerce.Application.Features.Products.Commands
{
    public class CreateCatagoryQueryHandler : IRequestHandler<ProductVM, int>
    {



        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCatagoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<int> Handle(ProductVM request, CancellationToken cancellationToken)
        {
            var @product = _mapper.Map<Product>(request);
            if (product.ProductId >0)
            {
                await _unitOfWork.ProductRepository.UpdateAsync(product);
            }
            else
            {
                @product = await _unitOfWork.ProductRepository.AddAsync(product);
            }
            await _unitOfWork.CommitAsync();
            return @product.ProductId;
        }
    }
}
