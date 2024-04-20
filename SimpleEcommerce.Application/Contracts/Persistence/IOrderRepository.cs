using SimpleEcommerce.Domain.Entities;

namespace SimpleEcommerce.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
         public Task<Order> FindOrderById(int id);
        public Task UpdateOrderAsync(Order entity);
    }
   
}
