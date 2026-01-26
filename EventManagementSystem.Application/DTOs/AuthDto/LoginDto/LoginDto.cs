using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManagementSystem.Application.DTOs.AuthDto.LoginDto
{
    public class LoginDto
    {
        [Required]

        public string? UserName { get; set; }
       

        [Required]
        [PasswordPropertyText]

        public string? Password { get; set; }
    }
}
