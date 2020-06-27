using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectWeb.Models
{
    public class RegisterModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được bỏ trống")]
        [EmailAddress(ErrorMessage ="Email không hợp lệ")]
        public String email { set; get; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name không được bỏ trống")]
        public String username { set; get; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name không được bỏ trống")]
        public String name { set; get; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password không được bỏ trống")]
        [DataType(DataType.Password)]
        public String password { set; get; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password không được bỏ trống")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage ="The password and confirm password doesn't match")]
        public String confirmpassword { set; get; }
        

    }

    public class LoginModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Vui lòng nhập username")]
        public String username { set; get; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Vui lòng nhập password")]
        public String password { set; get; }

    }
}