using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit.Sdk;
using OnlineShop.Common;


namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Bạn phải nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string PassWord { set; get; }
        public bool RememberMe { set; get; }
    }
}