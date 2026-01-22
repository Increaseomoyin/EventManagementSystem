using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManagementSystem.Application.DTOs.TicketDto
{
    public class CreateTicketDto
    {
        [Required]
        public int ClientId { get; set; }
        [Required]

        //Link to Event
        public int EventId { get; set; }


    }
}
