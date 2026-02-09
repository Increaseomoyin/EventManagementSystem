using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Domain.Interfaces;
using EventManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly DataContext _dataContext;

        public ProducerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(Producer producerCreate)
        {
            await _dataContext.Producers.AddAsync(producerCreate);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var producer = await _dataContext.Producers.FirstOrDefaultAsync(p => p.Id == id);
            if (producer == null)
                throw new KeyNotFoundException($"Producer with ID {id} not found.");

            _dataContext.Producers.Remove(producer);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int Id)
        {
            var producer = await _dataContext.Producers.AnyAsync(p => p.Id == Id);
            return producer ? true : false;
        }

      

        public async Task<IEnumerable<Producer>> GetAsync(string? name = null, int Page = 1, int PageSize = 10)
        {
            var producers = _dataContext.Producers.AsQueryable();
            if(!string.IsNullOrWhiteSpace(name))
                producers = producers.Where(p=> p.Name.Contains(name));
            return await producers
                .Skip((Page-1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            var producer = await _dataContext.Producers.FirstOrDefaultAsync(p => p.Id == id);
            return producer;
        }

     

        public async Task UpdateAsync(Producer producerUpdate)
        {
            var existingProducer = await _dataContext.Producers.FirstOrDefaultAsync(p => p.Id == producerUpdate.Id);
            if (existingProducer == null)
                throw new KeyNotFoundException($"Producer with ID {producerUpdate.Id} not found.");

            existingProducer.Name = producerUpdate.Name;
            await _dataContext.SaveChangesAsync();
        }
    }
}
