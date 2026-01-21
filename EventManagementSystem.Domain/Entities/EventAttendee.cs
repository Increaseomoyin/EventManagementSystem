using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Domain.Entities
{
    public class EventAttendee
    {
        public int EventId { get; set; }
        public Event? Event { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
