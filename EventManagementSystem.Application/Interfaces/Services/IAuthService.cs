using EventManagementSystem.Application.DTOs.AuthDto.LoginDto;
using EventManagementSystem.Application.DTOs.AuthDto.RegisterDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task RegisterClientAsync(RegisterDto dto);
        Task RegisterProducerAync(RegisterDto dto);
        Task<DisplayUserDto> LoginUserAsync(LoginDto dto);
    }
}
