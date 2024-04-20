using Microsoft.AspNetCore.Identity;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Persistence
{

    public enum UserTypeEnum
    {
        Admin,
        Customer
    }
    public class ApplicationUser : IdentityUser
    {
        public UserTypeEnum UserType { get; set; }


        //// Navigation property
        //public ICollection<Wishlist> Wishlists { get; set; }
        //public ICollection<Order> Orders { get; set; }
    }
}
