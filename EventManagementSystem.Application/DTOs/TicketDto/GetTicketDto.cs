using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.DTOs.TicketDto
{
    public class GetTicketDto
    {
        public int Id { get; set; }
        //Link to Client
        public int ClientId { get; set; }
        //Link to Event
        public int EventId { get; set; }
        //Ticket numnber
        public string? TicketNumber { get; set; }
        public DateTime PurchasedAt { get; set; }
    }
}
