﻿using System.ComponentModel.DataAnnotations;

namespace ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.AccountViews
{
    public class RegisterAccountView
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Password сonfirm")]
        public string PasswordConfirm { get; set; }
    }
}
