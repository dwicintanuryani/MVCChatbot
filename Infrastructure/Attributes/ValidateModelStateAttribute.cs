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
    internal class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var response = new ApiResponseModel();
            bool isNullObject = false;

            if (context.ActionArguments.Any(x => x.Value == null))
            {
                context.Result = ApiHelper.Response((EnumResponseCode)HttpStatusCode.BadRequest, response);
                isNullObject = true;
            }

            if (!context.ModelState.IsValid && !isNullObject)
            {
                context.Result = ApiHelper.Response((EnumResponseCode)HttpStatusCode.BadRequest, response);
            }

            base.OnActionExecuting(context);
        }
    }
}
