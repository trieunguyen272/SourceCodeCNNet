using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS_DTCK.Areas.User.Models
{
    public class LoginModel
    {
        [Key]
        
        [Required(ErrorMessage = "Bạn phải nhập tên đăng nhập")]
        public string UserName { get; set; }

        
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string PassWord { get; set; }

        
        public bool RememberMe { get; set; }
    }
}