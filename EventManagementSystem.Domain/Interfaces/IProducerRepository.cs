using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Domain.Interfaces
{
    public interface IProducerRepository
    {
        //Get methods
        Task<IEnumerable<Producer>> GetAsync(
            string ?name =null,
            int Page = 1,
            int PageSize = 10);
        Task<Producer> GetByIdAsync(int id);
        //Create Methods
        Task<bool> ExistsAsync(int Id);
        Task CreateAsync(Producer producerCreate);
        //Update Methods
        Task UpdateAsync(Producer producerUpdate);
        //Delete Methods
        Task DeleteAsync(int id);
    }
}
