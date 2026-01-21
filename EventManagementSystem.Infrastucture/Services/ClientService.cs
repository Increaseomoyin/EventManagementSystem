using AutoMapper;
using EventManagementSystem.Application.DTOs.ClientDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task CreateClientAsync(CreateClientDto client)
        {
           var clientMap = _mapper.Map<Client>(client);
            await _clientRepository.CreateAsync(clientMap);



        }

        public async Task DeleteClientAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);
        }

        public async Task UpdateClientAsync(UpdateClientDto clientUpdate)
        {
            var clientMap = _mapper.Map<Client>(clientUpdate);
            await _clientRepository.UpdateAsync(clientMap);

            
        }

        public async Task<ICollection<GetClientDto>> GetAllClientAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            var clientsMap = _mapper.Map<ICollection<GetClientDto>>(clients);
            return clientsMap;
        }

        public async Task<GetClientDto> GetClientByIdAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            var clientMap = _mapper.Map<GetClientDto>(client);
            return clientMap;
        }

        public async Task<GetClientDto> GetClientByNameAsync(string name)
        {
            var client = await _clientRepository.GetByNameAsync(name);
            var clientMap = _mapper.Map<GetClientDto>(client);
            return clientMap;
        }
    }
}
