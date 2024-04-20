using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductVM>
    {
        public int ProductId { get; set; }

        public GetProductByIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
