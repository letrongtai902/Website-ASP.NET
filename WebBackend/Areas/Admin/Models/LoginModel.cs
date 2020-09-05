using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebBackend.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Nhập User Name")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Nhập và Password")]
        public string PassWord { set; get; }
        public bool RememberMe { set; get; }

    }
}