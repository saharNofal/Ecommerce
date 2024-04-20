using AutoMapper;
using MediatR;
using SimpleEcommerce.Application.Contracts;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.WishList.Commands
{
    internal class AddToWishlistQueryHandler : IRequestHandler<WishlistMV, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AddToWishlistQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<int> Handle(WishlistMV request, CancellationToken cancellationToken)
        {
            var wishList = _mapper.Map<Wishlist>(request);
            wishList= await _unitOfWork.WishlistRepository.AddAsync(wishList);
           await _unitOfWork.CommitAsync();
            return wishList.WishlistId;
        }
    }

}
