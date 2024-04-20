using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Products
{
    public class ProductVM : IRequest<int>
    {
        public ProductVM()
        {
          
        }
        public ProductVM(int productId)
        {
            ProductId = productId;
        }
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; } = string.Empty;
        public int CategoryId { get; set; }


    }
}
