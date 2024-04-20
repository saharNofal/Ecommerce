using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EcommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
