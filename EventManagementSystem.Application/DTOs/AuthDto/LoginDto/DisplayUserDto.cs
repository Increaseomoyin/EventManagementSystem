using EventManagementSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.DTOs.AuthDto.LoginDto
{
    public class DisplayUserDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
