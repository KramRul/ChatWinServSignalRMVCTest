using ChatWithSignalRAndWinServMVC.Web.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatWithSignalRAndWinServMVC.Web.Common.Helpers
{
    public class CustomErrorHandling : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled)
            {
                string controllerName = (string)exceptionContext.RouteData.Values["controller"];
                string actionName = (string)exceptionContext.RouteData.Values["action"];

                Trace.WriteLine(exceptionContext.Exception.Message + " in " + controllerName);
                var customException = new Exception("Internal server error");
                if (exceptionContext.Exception is CustomServiceException)
                {
                    customException = exceptionContext.Exception;
                }
                var model = new HandleErrorInfo(customException, controllerName, actionName);

                exceptionContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = exceptionContext.Controller.TempData
                };

                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}