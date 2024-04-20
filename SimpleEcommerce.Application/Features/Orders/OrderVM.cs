using MediatR;

namespace SimpleEcommerce.Application.Features.Orders
{
    public class OrderVM : IRequest<int>
    {
        public int OrderId { get; set; }
        public string? UserId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<OrderItemVM> OrderItems { get; set; }
}
    public enum OrderStatus
    {
        inprogress,
        done
    }
}
