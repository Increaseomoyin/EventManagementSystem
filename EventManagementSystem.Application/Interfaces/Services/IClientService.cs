using EventManagementSystem.Application.DTOs.ClientDto;
using EventManagementSystem.Application.Queries;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.Interfaces.Services
{
    public interface IClientService
    {
        //Get methods
        Task<IEnumerable<GetClientDto>> GetClientAsync(ClientQuery query);
        Task<GetClientDto> GetClientByIdAsync(int id);
        //Create Methods
        Task CreateClientAsync(CreateClientDto client);
        //Update Methods
        Task UpdateClientAsync(UpdateClientDto clientUpdate);
        //Delete Methods
        Task DeleteClientAsync(int id);
    }
}
