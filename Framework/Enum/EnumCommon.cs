using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Enum
{
    public static class EnumCommon
    {
        public enum TypeStatus
        {
            Start = 1,
            Online = 2,
            Maintenance = 3,
            Offline = 4,
            Timeout = 5,
            FeedBack = 6,
            End = 7
        }
    }
}
