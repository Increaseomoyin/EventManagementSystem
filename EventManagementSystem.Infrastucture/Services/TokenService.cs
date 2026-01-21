using AutoMapper;
using EventManagementSystem.Application.DTOs.AuthDto.LoginDto;
using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventManagementSystem.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config, UserManager<AppUser> userManager, IMapper mapper)
        {
            _config = config;
            _userManager = userManager;
           _mapper = mapper;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }

        public async Task<string> GenerateTokenAsync(TokenUserDto user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.GivenName , user.UserName),
                new Claim(JwtRegisteredClaimNames.Email , user.Email)

            };
            var userMap = _mapper.Map<AppUser>(user);
            var roles = await _userManager.GetRolesAsync(userMap);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                SigningCredentials = creds,
                Audience = _config["JWT:Audience"],
                Subject = new ClaimsIdentity(claims),
                Issuer = _config["JWT:Issuer"],
                Expires = DateTime.UtcNow.AddDays(7)


            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }   
    }
}
