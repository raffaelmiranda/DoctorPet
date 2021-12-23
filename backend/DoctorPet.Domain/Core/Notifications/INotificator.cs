using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPet.Domain.Core.Notifications
{
    public interface INotificator
    {
        void Add(string message);
        List<string> Notifications();
        bool HasNotifications();
    }
}
