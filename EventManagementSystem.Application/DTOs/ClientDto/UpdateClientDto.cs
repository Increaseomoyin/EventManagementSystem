using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManagementSystem.Application.DTOs.ClientDto
{
    public class UpdateClientDto
    {
        [Required]

        public int Id { get; set; }
        [Required]

        public string? Name { get; set; }

    }
}
