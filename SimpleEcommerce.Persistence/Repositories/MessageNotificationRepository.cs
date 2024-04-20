using SimpleEcommerce.Application.Contracts.Persistence;
using SimpleEcommerce.Domain.Entities;


namespace SimpleEcommerce.Persistence.Repositories
{
    public class MessageNotificationRepository : BaseRepository<MessageNotification>, IMessageNotificationRepository
    {
        public MessageNotificationRepository(EcommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
