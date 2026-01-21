using EventManagementSystem.Application.DTOs.AuthDto.LoginDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(TokenUserDto user);
    }
}
