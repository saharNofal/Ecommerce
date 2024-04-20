using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.WishList
{
    public class WishlistMV: IRequest<int>
    {
        public int WishlistId { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
}
