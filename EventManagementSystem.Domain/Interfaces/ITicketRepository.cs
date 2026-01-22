using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace EventManagementSystem.Domain.Interfaces
{
    public interface ITicketRepository
    {
        //Get Methods
        Task<bool> ExistsAsync(int ticketId);
        Task<Ticket> GetByIdAsync(int ticketId);
        Task<IEnumerable<Ticket>> GetAsync(
            int? eventId,
            int Page = 1,
            int PageNumber = 10);
        //create Methods 
        Task CreateAsync(Ticket ticket);


    }
}
