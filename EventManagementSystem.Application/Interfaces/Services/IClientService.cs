using EventManagementSystem.Application.DTOs.ClientDto;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.Interfaces.Services
{
    public interface IClientService
    {
        //Get methods
        Task<ICollection<GetClientDto>> GetAllClientAsync();
        Task<GetClientDto> GetClientByIdAsync(int id);
        Task<GetClientDto> GetClientByNameAsync(string name);
        //Create Methods
        Task CreateClientAsync(CreateClientDto client);
        //Update Methods
        Task UpdateClientAsync(UpdateClientDto clientUpdate);
        //Delete Methods
        Task DeleteClientAsync(int id);
    }
}
