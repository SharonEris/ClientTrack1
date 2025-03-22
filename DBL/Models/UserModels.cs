using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTrack.DBL.Models
{
        public class UserLoginModel
        {
            [Required]
            [Display(Name = "Username", Prompt = "Username")]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password", Prompt = "Password")]
            public string Password { get; set; }
        }
    }

