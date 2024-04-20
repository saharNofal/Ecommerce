using SimpleEcommerce.Domain.Entities;

namespace SimpleEcommerce.Application.Contracts.Persistence
{
    public interface IOrderItemRepository : IAsyncRepository<OrderItem>
    {
    }
}
