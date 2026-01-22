using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Domain.Interfaces
{
    public interface IEventRepository
    {   
        //Get Methods
        Task<IEnumerable<Event>> GetAsync(
            string? name = null,
            string? producerName = null,
            int Page = 1,
            int PageSize = 10);
        Task<Event> GetByIdAsync(int id);
        //Create Methods
        Task<bool> ExistsAsync(int Id);
        Task CreateAsync(Event eventCreate);
        //Update Methods
        Task UpdateAsync(Event eventUpdate);
        //Delete Methods
        Task DeleteAsync(int id);

    }
}
