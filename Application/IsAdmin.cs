using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IsAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //var token = context.

            //if (!found || !result)
            //{
            //    // don't continue
            //    context.HttpContext.Response.StatusCode = 403;
            //}
        }
    }
}
