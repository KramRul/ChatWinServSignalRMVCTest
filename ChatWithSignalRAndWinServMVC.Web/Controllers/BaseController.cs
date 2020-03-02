using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace ChatWithSignalRAndWinServMVC.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string UserName
        {
            get
            {
                return User.Identity.Name;
            }
        }

        protected string UserId
        {
            get
            {
                return User.Identity.GetUserId();
            }
        }
    }
}
