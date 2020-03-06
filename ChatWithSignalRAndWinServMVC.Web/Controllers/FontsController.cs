using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatWithSignalRAndWinServMVC.Web.Controllers
{
    public class FontsController : Controller
    {
        // GET: Fonts
        public FileResult Authem()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes($@"{Server.MapPath("~/App_Data/fonts/Authem_Script_Regular.json")}");
            string fileName = "Authem_Script_Regular.json";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}