using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Enum
{
    public enum EnumResponseCode
    {
        [Description("OK")]
        Success = 200,
        [Description("Created")]
        Created = 201,
        [Description("No Content")]
        NoContent = 204,
        [Description("Bad Request")]
        BadRequest = 400,
        [Description("Unauthorized")]
        Unauthorized = 403,
        [Description("Not Found")]
        NotFound = 404,
        [Description("Internal Server Error")]
        InternalServerError = 500,
    }
}
