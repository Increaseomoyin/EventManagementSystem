using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Domain.Interfaces;
using EventManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DataContext _dataContext;

        public TicketRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(Ticket ticket)
        {
            await _dataContext.Tickets.AddAsync(ticket);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int ticketId)
        {
            var ticket = await _dataContext.Tickets.AnyAsync(t => t.Id == ticketId);
            return ticket ? true : false;
        }

        public async Task<ICollection<Ticket>> GetAllAsync()
        {
            var tickets = await _dataContext.Tickets.OrderBy(t=>t.Id)
                .ToListAsync();
            return tickets;
        }

        public async Task<ICollection<Ticket>> GetByEventAsync(int eventId)
        {
            var ticket = await _dataContext.Tickets
                .Where(e=>e.EventId == eventId)
                .OrderBy(t=>t.Id)
                .ToListAsync();
            return ticket;
        }

        public async Task<Ticket> GetByIdAsync(int ticketId)
        {
            var ticket = await _dataContext.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);
            return ticket;
        }

        public async Task<int> CountByEventAsync(int eventId)
        { 
            //Count existing tickets for this event
            int count = await _dataContext.Tickets.CountAsync(t=>t.EventId == eventId);

            return count;
        }

    }
}
