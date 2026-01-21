using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManagementSystem.Application.DTOs.ClientDto
{
    public class CreateClientDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]

        //Link to Identity User
        public string? IdentityUserId { get; set; }
    }
}
