using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        
        public IOrderRepository OrderRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IWishlistRepository WishlistRepository { get; }
        Task CommitAsync();
    }
}
