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


    public class DeleteProductCommand : IRequest
    {
        public int ProductId { get; set; }

        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        //private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
           // _productRepository = productRepository;
           _unitOfWork = unitOfWork;
        }

      

         async Task  IRequestHandler<DeleteProductCommand>.Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);

            if (productToDelete != null)
                await _unitOfWork.ProductRepository.DeleteAsync(productToDelete);
                
            await _unitOfWork.CommitAsync();
            
        }
    }
}
