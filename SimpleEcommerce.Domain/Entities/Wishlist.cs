using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Domain.Entities
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public Product? Product { get; set; }
    }
}
