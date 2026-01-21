using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Domain.Interfaces
{
    public interface IClientRepository
    {   
        //Get methods
        Task<ICollection<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task<Client> GetByNameAsync(string name);
        //Create Methods
        Task<bool> ExistsAsync(int Id);
        Task CreateAsync(Client client);
        //Update Methods
        Task UpdateAsync(Client clientUpdate);
        //Delete Methods
        Task DeleteAsync(int id);
      

    }
}
