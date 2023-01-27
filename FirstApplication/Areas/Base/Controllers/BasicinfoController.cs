using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Areas.Base.Controllers
{
    [Area("Base")]
    public class BasicinfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
