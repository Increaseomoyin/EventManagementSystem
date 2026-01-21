using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //Link to Identity User
        public string? IdentityUserId { get; set; }
        //Tickets owned by client
        public ICollection<Ticket>? Tickets { get; set; }
        //Events that client is attending
        public ICollection<EventAttendee>? EventAttendees { get; set; }
    }
}
