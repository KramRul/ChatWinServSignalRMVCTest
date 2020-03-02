﻿using System.ComponentModel.DataAnnotations;

namespace ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.AccountViews
{
    public class LoginAccountView
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
