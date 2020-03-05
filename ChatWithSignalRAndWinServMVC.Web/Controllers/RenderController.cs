using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChatWithSignalRAndWinServMVC.Web.Controllers
{
    [Authorize]
    public class RenderController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }
    }
}