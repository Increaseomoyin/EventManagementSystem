using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        //Link to Client
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        //Link to Event
        public int EventId { get; set; }
        public Event? Event { get; set; }
        //Ticket numnber
        public string? TicketNumber { get; set; } 
        public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;
    }
}
