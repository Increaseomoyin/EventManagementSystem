using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Domain.Interfaces;
using EventManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _dataContext;

        public EventRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(Event eventCreate)
        {
            await _dataContext.Events.AddAsync(eventCreate);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existingEvent = await _dataContext.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (existingEvent == null)
                throw new KeyNotFoundException($"Event with ID {id} not found.");

            _dataContext.Events.Remove(existingEvent);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int Id)
        {
            var existingEvent = await _dataContext.Events.AnyAsync(e => e.Id == Id);
            return existingEvent ? true : false;
        }

        public async Task<ICollection<Event>> GetAllAsync()
        {
            var events = await _dataContext.Events.OrderBy(e => e.Id).ToListAsync();
            return events;
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            var existingEvent = await _dataContext.Events.FirstOrDefaultAsync(e => e.Id == id);
            return existingEvent;
        }

        public async Task<Event> GetByNameAsync(string name)
        {
            var existingEvent = await _dataContext.Events.FirstOrDefaultAsync(e => e.Name == name);
            return existingEvent;
        }

        public async Task<ICollection<Event>> GetByProducerAsync(string producerName)
        {
            var producer = await _dataContext.Producers.Include(p=>p.Events)
                .FirstOrDefaultAsync(p=>p.Name == producerName);
            return producer.Events.ToList();
        }

        public async Task UpdateAsync(Event eventUpdate)
        {
            var existingEvent = await _dataContext.Events.FirstOrDefaultAsync(e => e.Id == eventUpdate.Id);
            if (existingEvent == null)
                throw new KeyNotFoundException($"Event with ID {eventUpdate.Id} not found.");

            existingEvent.Location = eventUpdate.Location;
            existingEvent.StartDate = eventUpdate.StartDate;
            existingEvent.TotalTickets = eventUpdate.TotalTickets;
            existingEvent.Type = eventUpdate.Type;
            existingEvent.Name = eventUpdate.Name;

            await _dataContext.SaveChangesAsync();
        }
    }
}
