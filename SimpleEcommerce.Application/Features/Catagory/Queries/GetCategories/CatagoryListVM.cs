using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Features.Catagory.Queries.GetCategories
{
    public class CatagoryListVM : IRequest<int>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
