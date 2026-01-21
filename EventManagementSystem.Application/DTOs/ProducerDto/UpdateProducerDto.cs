using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManagementSystem.Application.DTOs.ProducerDto
{
    public class UpdateProducerDto
    {
        [Required]

        public int Id { get; set; }

        [Required]

        public string? Name { get; set; }
    }
}
