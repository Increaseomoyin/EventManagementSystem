using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public int ProducerId { get; set; }
        public Producer? Producer { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public DateTime? StartDate { get; set; }
        //Where is the Event
        public string? Location { get; set; }
        //Number of tickets available for sale
        public int TotalTickets { get; set; }
        //TicketsSold
        public int TicketsSold { get; set; } = 0;
        //Link to Tickets
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<EventAttendee>? EventAttendees { get; set; }

       

    }
}
