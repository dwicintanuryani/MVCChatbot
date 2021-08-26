using RepoDb.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotMVC.Models.MainModel
{
    public class ChatRequest
    {
        [Required]
        public Guid BotID { get; set; }
        public Guid? UserID { get; set; }

        [Required]
        public string UserInput { get; set; }

        [Required]
        public DateTime StartOn { get; set; }
        public string Type { get; set; }
    }
}
