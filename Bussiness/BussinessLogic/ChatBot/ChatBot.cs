using Bussiness.Interface;
using DataAccess.Interface;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.BussinessLogic.ChatBot
{
    public class ChatBot : BaseBussinessLogic, IChatBot
    {
        private IUnitofWork _uow { get; set; }

        public ChatBot (IUnitofWork uow)
        {
            _uow = uow;
        }
    }
}
