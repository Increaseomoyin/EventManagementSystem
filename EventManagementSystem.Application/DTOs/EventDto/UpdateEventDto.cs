using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManagementSystem.Application.DTOs.EventDto
{
    public class UpdateEventDto
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string? Name { get; set; }
        [Required]

        public string? Type { get; set; }
        [Required]

        public DateTime? StartDate { get; set; }
        [Required]

        //Where is the Event
        public string? Location { get; set; }
        [Required]

        //Number of tickets available for sale
        public int TotalTickets { get; set; }

    }
}
