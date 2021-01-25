using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webMVC1.Areas.Admin.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Moi nhap tai khoan")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Moi nhap mat khau")]
        public string PassWord { set; get; }

        public bool Rememberme { set; get; }
    }
}