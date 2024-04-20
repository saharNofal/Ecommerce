using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Application.Contracts.Persistence
{
    public interface IProductRepository:IAsyncRepository<Product>
    {
        public  Task<List<Product>> GetByCategoryAsync(int categoryId);
    }
}
