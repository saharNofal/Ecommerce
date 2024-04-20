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

    public class DeleteWishlistCommand : IRequest
    {
        public int ProductId { get; set; }

        public DeleteWishlistCommand(int productId)
        {
            ProductId = productId;
        }
    }
    public class DeleteProductFromWishlistCommandHandler : IRequestHandler<DeleteWishlistCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductFromWishlistCommandHandler(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }

      

         async Task  IRequestHandler<DeleteWishlistCommand>.Handle(DeleteWishlistCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _unitOfWork.WishlistRepository.FindByAsnc(x=>x.ProductId ==request.ProductId);

            if (productToDelete != null)
            {
               var  entity = productToDelete.FirstOrDefault();
                await _unitOfWork.WishlistRepository.DeleteAsync(entity);
            }

            await _unitOfWork.CommitAsync();
            
        }
    }
}
