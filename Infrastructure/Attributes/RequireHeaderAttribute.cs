using ChatBotMVC.Infrastructure.Helpers;
using ChatBotMVC.Models;
using DataAccess.ViewModel;
using Framework.Enum;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ChatBotMVC.Infrastructure.Attributes
{
    internal class RequireHeaderAttribute : ActionFilterAttribute
    {
        public string[] requiredHeader { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string[] header = requiredHeader;
            if (header.Length > 0)
            {
                foreach (string value in header)
                {
                    if (!context.HttpContext.Request.Headers.Any(h => h.Key.Equals(value, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        context.Result = ApiHelper.Response((EnumResponseCode)HttpStatusCode.BadRequest, new ApiResponseModel());
                    }
                }
            }


            base.OnActionExecuting(context);
        }
    }
}
