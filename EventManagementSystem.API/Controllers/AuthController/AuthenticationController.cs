using EventManagementSystem.Application.DTOs.AuthDto.LoginDto;
using EventManagementSystem.Application.DTOs.AuthDto.RegisterDto;
using EventManagementSystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.API.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register/client")]
        public async Task<IActionResult> RegisterClient([FromBody] RegisterDto dto)
        {
            await _authService.RegisterClientAsync(dto);
            return Ok();
        }

        [HttpPost("register/producer")]
        public async Task<IActionResult> RegisterProducer([FromBody] RegisterDto dto)
        {
          
            await _authService.RegisterProducerAync(dto);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginUserAsync(dto);
            return Ok(result);
        }
    }
    
}
