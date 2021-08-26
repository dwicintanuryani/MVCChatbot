using ChatBotMVC.Models;
using DataAccess.ViewModel;
using Framework.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ChatBotMVC.Infrastructure.Helpers
{
    /// <summary>
    /// Api Helper functionally as an extend to reveal the result
    /// </summary>
    public class ApiHelper
    {
        private static string MSG_200 = "OK";
        private static string MSG_201 = "Created";
        private static string MSG_204 = "No Data";
        private static string MSG_400 = "Bad Request";
        private static string MSG_403 = "Unauthorized";
        private static string MSG_500 = "Internal Server Error";

        public static JsonResult Response(EnumResponseCode code, ApiResponseModel result = null, string apiVersion = "1.0.0.0")
        {
            result.Version = apiVersion;
            result.ResponseCode = (HttpStatusCode)code;

            if (string.IsNullOrEmpty(result.Message))
            {
                switch (code)
                {
                    case EnumResponseCode.Success:
                        result.Message = MSG_200;
                        break;
                    case EnumResponseCode.Created:
                        result.Message = MSG_201;
                        break;
                    case EnumResponseCode.BadRequest:
                        result.Message = MSG_400;
                        break;
                    case EnumResponseCode.Unauthorized:
                        result.Message = MSG_403;
                        break;
                    case EnumResponseCode.InternalServerError:
                        result.Message = MSG_500;
                        break;
                }
            }

            try
            {
                if (string.IsNullOrEmpty(result.Message) && result.Result == null)
                {
                    result.ResponseCode = HttpStatusCode.NoContent;
                    result.Message = MSG_204;
                }
                    

                //Validations
                if (result.Validations != null)
                {
                    if (result.validations.Count > 0)
                    {
                        result.responseCode = HttpStatusCode.NoContent;
                        result.message = MSG_204;
                    }
                }

            }
            catch (Exception)
            {
                result.responseCode = HttpStatusCode.InternalServerError;
                result.message = MSG_500;
            }

            return new JsonResult(result);

        }        
    }
}
