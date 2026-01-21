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
        Task<ICollection<Ticket>> GetByEventAsync(int eventId);
        Task<ICollection<Ticket>> GetAllAsync();
        //create Methods 
        Task CreateAsync(Ticket ticket);
        Task<int> CountByEventAsync(int eventId);


    }
}
