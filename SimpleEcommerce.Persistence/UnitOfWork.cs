using SimpleEcommerce.Application.Contracts;
using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Domain.Entities;
using SimpleEcommerce.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Persistence
{


    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _dbContext;

        public UnitOfWork(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IOrderRepository _OrderRepository;
        private IOrderItemRepository _OrderItemRepository;
        private ICategoryRepository _CategoryRepository;
        private IProductRepository _ProductRepository;
        private IWishlistRepository _WishlistRepository;
        private IMessageNotificationRepository _MessageNotificationRepository;
        private INotificationSettingsRepository _NotificationSettingsRepository;

        public IOrderRepository OrderRepository => _OrderRepository ??= new OrderRepository(_dbContext);

        public IOrderItemRepository OrderItemRepository => _OrderItemRepository ??= new OrderItemRepository(_dbContext);
        public ICategoryRepository CategoryRepository => _CategoryRepository ??= new CategoryRepository(_dbContext);
        public IProductRepository ProductRepository => _ProductRepository ??= new ProductRepository(_dbContext);

        public IWishlistRepository WishlistRepository => _WishlistRepository ??= new WishlistRepository(_dbContext);
        public INotificationSettingsRepository NotificationSettingsRepository => _NotificationSettingsRepository ??= new NotificationSettingsRepository(_dbContext);
        public IMessageNotificationRepository MessageNotificationRepository => _MessageNotificationRepository ??= new MessageNotificationRepository(_dbContext);







        // Add more repositories as needed

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }

}


