using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.DTOs.EventDto
{
    public class GetEventDto
    {
        public int Id { get; set; }

        public int ProducerId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        //Where is the Event
        public string? Location { get; set; }
        //Number of tickets available for sale
        public int TotalTickets { get; set; }
        //TicketsSold
        public int TicketsSold { get; set; }
    }
}
