using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VueProj.Lib
{
    public class AuthViewModel
    {

        [Required(ErrorMessage = "*Username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
