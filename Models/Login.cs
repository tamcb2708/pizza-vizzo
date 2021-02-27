using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webMVC1.Models
{
    public class Login
    {
        [Key]
        [Display(Name="Ten dang nhap")]
        [Required(ErrorMessage ="yeu cau ban phai nhap tai khoan")]
        public string UserName { set; get; }

        [Display(Name = "Mat Khau")]
        [Required(ErrorMessage ="yeu cau ban phai nhap mat khau")]
        public string Password { set; get; }
    }
}