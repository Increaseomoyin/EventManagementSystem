using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Domain.Interfaces
{
    public interface IClientRepository
    {   
        //Get methods
        Task<IEnumerable<Client>> GetAllAsync(
            string? name = null,
            int page = 1,
            int pageSize = 10);
        Task<Client> GetByIdAsync(int id);
        //Create Methods
        Task<bool> ExistsAsync(int Id);
        Task CreateAsync(Client client);
        //Update Methods
        Task UpdateAsync(Client clientUpdate);
        //Delete Methods
        Task DeleteAsync(int id);
      

    }
}
