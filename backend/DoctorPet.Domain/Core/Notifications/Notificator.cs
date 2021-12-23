using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPet.Domain.Core.Notifications
{
    public class Notificator: INotificator
    {
        private List<string> _notifications;

        public Notificator()
        {
            _notifications = new List<string>();
        }

        public void Add(string message)
        {
            if (!string.IsNullOrEmpty(message))
                _notifications.Add(message);
        }

        public List<string> Notifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}
