using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Domain.Entities
{
    public class NotificationSettings
    {
        public int NotificationSettingsId { get; set; }
        public string UserId { get; set; }= string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public string ConnectionId { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
    public class MessageNotification
    {
        public int MessageNotificationId { get; set; }
        public string Message { get; set; }=string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
