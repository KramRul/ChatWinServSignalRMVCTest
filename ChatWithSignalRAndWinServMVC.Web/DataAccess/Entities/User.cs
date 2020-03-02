using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public string ConnectionId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType = null)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, string.IsNullOrEmpty(authenticationType) ? DefaultAuthenticationTypes.ApplicationCookie : authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}