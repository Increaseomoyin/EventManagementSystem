using EventManagementSystem.Application.DTOs.AuthDto.LoginDto;
using EventManagementSystem.Application.DTOs.AuthDto.RegisterDto;
using EventManagementSystem.Application.DTOs.EmailNotificationDto;
using EventManagementSystem.Application.Interfaces.Email;
using EventManagementSystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.API.Controllers
{   


    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailNotificationQueue _emailQueue;

        public AuthenticationController(IAuthService authService, IEmailNotificationQueue emailQueue )
        {
            _authService = authService;
            _emailQueue = emailQueue;
        }

        /// <summary>
        /// Use this endpoint to register clients
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("register/client")]
        public async Task<IActionResult> RegisterClient([FromBody] RegisterDto dto)
        {
            try
            {
                await _authService.RegisterClientAsync(dto);
                var emailNotification = new EmailNotificationDto()
                {
                    To = dto.Email,
                    Subject = "Welcome to Event Management System",
                    Body = $"Hello {dto.Name},<br/>Your registration was successful! <br/> Thank you"
                };
                await _emailQueue.QueueAsync(emailNotification);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
         

        /// <summary>
        /// Use this endpoint to register producers
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("register/producer")]
        public async Task<IActionResult> RegisterProducer([FromBody] RegisterDto dto)
        {
            try
            {
                await _authService.RegisterProducerAync(dto);
                var emailNotification = new EmailNotificationDto()
                {
                    To = dto.Email,
                    Subject = "Welcome to Event Management System",
                    Body = $"Hello {dto.Name},<br/>Your registration was successful! <br/> Thank you"
                };
                await _emailQueue.QueueAsync(emailNotification);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Use this endpoint to login, and copy the JWT Token.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto dto)
        {
            try
            {
                var result = await _authService.LoginUserAsync(dto);
                var emailNotification = new EmailNotificationDto()
                {
                    To = result.Email,
                    Subject = "Welcome to Event Management System",
                    Body = $"Hello {result.UserName},<br/>Your Login was successful! <br/> Thank you"
                };
                await _emailQueue.QueueAsync(emailNotification);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
    
}
