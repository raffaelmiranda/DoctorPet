using DoctorPet.Domain.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace DoctorPet.Api.Filter
{
    public class ModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(new ResultFault
                {
                    Notifications = context.ModelState.Keys
                    .Where(k => context.ModelState[k].Errors.Count > 0)
                    .Select(k => context.ModelState[k].Errors[0].ErrorMessage)
                }); 
            }
        }
    }
}
