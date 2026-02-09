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

        public async Task<Ticket> GetByIdAsync(int ticketId)
        {
            var ticket = await _dataContext.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);
            return ticket;
        }

      

        public async Task<IEnumerable<Ticket>> GetAsync(int? eventId, int Page = 1, int PageNumber = 10)
        {
            var tickets = _dataContext.Tickets.AsQueryable();
            if(eventId != null)
            {
                tickets = _dataContext.Tickets.Where(t => t.EventId == eventId);
            }
            return await tickets
                .Skip((Page - 1) * PageNumber)
                .Take(PageNumber)
                .ToListAsync();
        }
    }
}
