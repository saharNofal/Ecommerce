using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Domain.Entities;


namespace SimpleEcommerce.Persistence.Repositories
{
    public class NotificationSettingsRepository : BaseRepository<NotificationSettings>, INotificationSettingsRepository
    {
        public NotificationSettingsRepository(EcommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
