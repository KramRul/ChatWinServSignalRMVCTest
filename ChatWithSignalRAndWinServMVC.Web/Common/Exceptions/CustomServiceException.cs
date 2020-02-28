using System;

namespace ChatWithSignalRAndWinServMVC.Web.Common.Exceptions
{
    public class CustomServiceException : Exception
    {
        public CustomServiceException(string message) : base(message)
        {
        }
    }
}
