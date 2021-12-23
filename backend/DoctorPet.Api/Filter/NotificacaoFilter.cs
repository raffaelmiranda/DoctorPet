using DoctorPet.Domain.Core.Notifications;
using DoctorPet.Domain.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorPet.Api.Filter
{
    public class NotificacaoFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var notificador = (INotificator)context.HttpContext.RequestServices.GetService(typeof(INotificator));

            if (notificador.HasNotifications())
            {
                context.Result = new UnprocessableEntityObjectResult(new ResultFault
                {
                    Notifications = ((Notificator)notificador).Notifications()
                });
            }
        }
    }
}
