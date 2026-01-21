using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.DTOs.AuthDto.LoginDto
{
    public class TokenUserDto
    {
        public string Id { get; set; }       // User Id
        public string UserName { get; set; } // Username
        public string Email { get; set; }    // optional
    }
}

