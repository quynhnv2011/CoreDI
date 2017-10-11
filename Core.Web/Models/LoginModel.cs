﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Core.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời bạn nhập tài khoản")]
        [Display(Name = "UserInfo name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}