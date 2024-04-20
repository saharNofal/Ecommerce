using Microsoft.EntityFrameworkCore;
using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Domain.Entities;

namespace SimpleEcommerce.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Order> FindOrderById(int id)
        {

            var order = await _dbContext.Orders
          .Include(o => o.OrderItems)
          .ThenInclude(oi => oi.Product)
          .FirstOrDefaultAsync(o => o.OrderId == id);

            return order;

        }

        public async Task UpdateOrderAsync(Order entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            foreach (var orderItem in entity.OrderItems)
            {
                if (orderItem.OrderItemId != 0)
                {
                    _dbContext.Entry(orderItem).State = EntityState.Modified;
                }
                else
                {
                    await _dbContext.Set<OrderItem>().AddAsync(orderItem);
                }
            }

        }
    }
}
