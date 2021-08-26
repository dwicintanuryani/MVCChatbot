using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotMVC.Models.MainModel
{
    public class ChatResult
    {
        public string Reply { get; set; }
        public DateTime Date { get; set; }
        public string Template { get; set; }
    }
}
