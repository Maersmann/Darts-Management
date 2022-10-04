using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Darts.Data.Model.UserEntitys.DTOs
{
   public class RegisterUserDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Username={Username}, LastName={LastName}, FirstName={FirstName}";
        }
    }
}
