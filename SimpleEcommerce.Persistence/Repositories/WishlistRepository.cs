using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Domain.Entities;


namespace SimpleEcommerce.Persistence.Repositories
{
    public class WishlistRepository : BaseRepository<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(EcommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
