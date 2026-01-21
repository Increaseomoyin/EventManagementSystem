using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace EventManagementSystem.Application.DTOs.AuthDto.RegisterDto
{
    public class RegisterDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]

        public string? Name { get; set; }
        [Required]
        [PasswordPropertyText]

        public string? Password { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
