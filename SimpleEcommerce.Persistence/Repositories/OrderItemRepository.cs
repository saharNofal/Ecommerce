using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Domain.Entities;


namespace SimpleEcommerce.Persistence.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(EcommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
