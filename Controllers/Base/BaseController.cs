﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotMVC.Controllers.Base
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseController : Controller
    {
    }
}
