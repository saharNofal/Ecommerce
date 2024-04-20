namespace SimpleEcommerce.Application.Features.Orders
{
    public class OrderItemVM
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
