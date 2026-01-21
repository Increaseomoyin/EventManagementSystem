using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Domain.Interfaces
{
    public interface IProducerRepository
    {
        //Get methods
        Task<ICollection<Producer>> GetAllAsync();
        Task<Producer> GetByIdAsync(int id);
        Task<Producer> GetByNameAsync(string name);
        //Create Methods
        Task<bool> ExistsAsync(int Id);
        Task CreateAsync(Producer producerCreate);
        //Update Methods
        Task UpdateAsync(Producer producerUpdate);
        //Delete Methods
        Task DeleteAsync(int id);
    }
}
