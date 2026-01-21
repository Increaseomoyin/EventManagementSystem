using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Domain.Interfaces
{
    public interface IEventRepository
    {   
        //Get Methods
        Task<ICollection<Event>> GetAllAsync();
        Task<Event> GetByIdAsync(int id);
        Task<Event> GetByNameAsync(string name);
        Task<ICollection<Event>> GetByProducerAsync(string producerName);
        //Create Methods
        Task<bool> ExistsAsync(int Id);
        Task CreateAsync(Event eventCreate);
        //Update Methods
        Task UpdateAsync(Event eventUpdate);
        //Delete Methods
        Task DeleteAsync(int id);

    }
}
