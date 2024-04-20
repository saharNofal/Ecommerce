using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Domain.Entities
{
   
   
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public int Status { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }


    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
