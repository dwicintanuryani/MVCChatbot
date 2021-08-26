using ChatBotMVC.Infrastructure.Attributes;
using ChatBotMVC.Models.MainModel;
using Framework.Constant;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotMVC.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("Request")]
        [ValidateModelState]
        [RequireHeader(requiredHeader = new string[] {HeaderConstant.Language})]
        public async Task<IActionResult> Request([FromBody] ChatRequest request)
        {
            return new JsonResult("Hello");
        }




        [HttpGet, Route("Initialize")]
        public async Task<IActionResult> Initialize()
        {
            ChatConfig config = new ChatConfig();
            config.Status = true;
            config.Max = 140;
            config.Name = "Mizuho Virtual Assistant";
            return new JsonResult(config);
        }
    }
}
