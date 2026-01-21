using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Domain.Interfaces;
using EventManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _dataContext;

        public ClientRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(Client client)
        {
            await _dataContext.Clients.AddAsync(client);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _dataContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client == null)
                throw new KeyNotFoundException($"Client with ID {id} not found.");

            _dataContext.Clients.Remove(client);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int Id)
        {
            var client = await _dataContext.Clients.AnyAsync(c => c.Id == Id);
            return client ? true : false;
        }

        public async Task<ICollection<Client>> GetAllAsync()
        {
            var clients = await _dataContext.Clients.OrderBy(c=>c.Id)
                .ToListAsync();
            return clients;
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            var client = await _dataContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
            return client;
        }

        public async Task<Client> GetByNameAsync(string name)
        {
            var client = await _dataContext.Clients.FirstOrDefaultAsync(c => c.Name == name);
            return client;
        }


        public async Task UpdateAsync(Client clientUpdate)
        {
            var existingClient = await _dataContext.Clients
        .FirstOrDefaultAsync(c => c.Id == clientUpdate.Id);

            if (existingClient == null)
                throw new KeyNotFoundException($"Client with ID {clientUpdate.Id} not found.");


            existingClient.Name = clientUpdate.Name;

            await _dataContext.SaveChangesAsync();
        }
    }
}
