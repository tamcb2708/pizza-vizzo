using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webMVC1.Models
{
    public class Register
    {
        [Key]
        public long ID { set; get; }

        [Display(Name="Ten Dang Nhap")] 
        [Required(ErrorMessage ="yeu cau nhap ten dang nhap")]
        public string UserName { set; get; }

        [Display(Name = "Mat khau")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="do dai it nhat 6 ky tu")]
        [Required(ErrorMessage = "yeu cau nhap mat khau")]
        public string PassWord { set; get; }

        [Display(Name = "Nhap lai Mat Khau")]
        [Compare("PassWord",ErrorMessage="xac nhan khong dung")]
        public string ConfirmPassWord { set; get; }

        [Display(Name = "Dia Chi")]
        public string Address { set; get; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "yeu cau nhap email")]
        public string Email { set; get; }

        [Display(Name = "Dien Thoai")]
        [Required(ErrorMessage = "yeu cau nhap so dien thoai")]
        public string Phone { set; get; }

        [Display(Name = "Ho ten")]
        [Required(ErrorMessage = "yeu cau nhap ho ten")]
        public string Name { set; get; }


    }
}