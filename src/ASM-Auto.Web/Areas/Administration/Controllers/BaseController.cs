﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ASM_Auto.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Route("/[controller]/[Action]/{id?}")]
    [Authorize(Roles = "Administrator")]
    public class BaseController : Controller
    {
       
    }
}
