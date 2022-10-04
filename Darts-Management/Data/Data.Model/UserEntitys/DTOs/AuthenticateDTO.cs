using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Darts.Data.Model.UserEntitys.DTOs
{
    public class AuthenticateDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }


        public override string ToString()
        {
            return $"Username={Username}";
        }
    }
}
