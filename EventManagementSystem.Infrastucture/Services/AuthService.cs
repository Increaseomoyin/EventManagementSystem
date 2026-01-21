using AutoMapper;
using EventManagementSystem.Application.DTOs.AuthDto.LoginDto;
using EventManagementSystem.Application.DTOs.AuthDto.RegisterDto;
using EventManagementSystem.Application.DTOs.ClientDto;
using EventManagementSystem.Application.DTOs.ProducerDto;
using EventManagementSystem.Application.Exceptions;
using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IClientService _clientService;
        private readonly IProducerService _producerService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(UserManager<AppUser> userManager, IClientService clientService, IProducerService producerService, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
           _clientService = clientService;
            _producerService = producerService;
           _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<DisplayUserDto> LoginUserAsync(LoginDto dto)
        {   
            var user = await _userManager.FindByNameAsync(dto.UserName);
            if (user == null)
            {
                throw new ConflictException("User can't be found");
            }
            else
            {
                var existingUser = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
                if(!existingUser.Succeeded)
                {
                    throw new ConflictException("User could not log in");

                }
                else
                {
                    var tokenMap = _mapper.Map<TokenUserDto>(user);

                    var newUser = new DisplayUserDto()
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = await _tokenService.GenerateTokenAsync(tokenMap)
                    };
                    return newUser;
                }

            }
        }

        public async Task RegisterClientAsync(RegisterDto dto)
        {
            var existingUser = await _userManager.FindByNameAsync(dto.UserName);
            if (existingUser != null)
            {
                throw new ConflictException("Username already exist");
            }
            else
            {
                var user = new AppUser()
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                };
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (!result.Succeeded)
                {
                    throw new ConflictException("Could not Create User");
                }
                else
                {
                    var registeredUser = await _userManager.AddToRoleAsync(user,"client");
                    if (!registeredUser.Succeeded)
                    {
                        throw new ConflictException("Could not Add Role");
                    }
                    else
                    {
                        var createdUser = new CreateClientDto()
                        {
                            Name = dto.Name,
                            IdentityUserId = user.Id

                        };
                        await _clientService.CreateClientAsync(createdUser);
                    }
                   
                }

            }
        }

        public async Task RegisterProducerAync(RegisterDto dto)
        {
            var existingUser = await _userManager.FindByNameAsync(dto.UserName);
            if (existingUser != null)
            {
                throw new ConflictException("Username already exist");
            }
            else
            {
                var user = new AppUser()
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                };
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (!result.Succeeded)
                {
                    throw new ConflictException("Could not Create User");
                }
                else
                {
                    var registeredUser = await _userManager.AddToRoleAsync(user, "producer");
                    if (!registeredUser.Succeeded)
                    {
                        throw new ConflictException("Could not Add Role");
                    }
                    else
                    {
                        var createdUser = new CreateProducerDto()
                        {
                            Name = dto.Name,
                            AppUserId = user.Id

                        };
                        await _producerService.CreateAsync(createdUser);
                    }

                }

            }
        }
    }
}
