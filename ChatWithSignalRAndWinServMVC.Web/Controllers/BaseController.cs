using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace ChatWithSignalRAndWinServMVC.Web.Controllers
{
    public class BaseController : ApiController
    {
        protected string UserName
        {
            get
            {
                return User.Identity.Name;
            }
        }

        public async Task<IHttpActionResult> Execute<T>(Func<Task<T>> func)
        {
            var response = new GenericResponseView<T>();
            var result = await func();
            response.Model = result;
            return Ok(response.Model);
        }

        protected async Task<IHttpActionResult> Execute(Func<Task> func)
        {
            var response = new GenericResponseView<string>();
            await func();
            return Ok(response);
        }
    }
}
