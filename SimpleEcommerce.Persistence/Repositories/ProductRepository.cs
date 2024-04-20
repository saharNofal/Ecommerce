using Microsoft.EntityFrameworkCore;
using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public  async Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products
           .Where(p => p.CategoryId == categoryId)
           .ToListAsync();
        }
    }
}
