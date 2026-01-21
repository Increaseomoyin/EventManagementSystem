using EventManagementSystem.Application.DTOs.ProducerDto;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.Interfaces.Services
{
    public interface IProducerService
    {

        //Get methods
        Task<ICollection<GetProducerDto>> GetAllProducersAsync();
        Task<GetProducerDto> GetProducerByIdAsync(int id);
        Task<GetProducerDto> GetProducerByNameAsync(string name);
        //Create Methods
    
        Task CreateAsync(CreateProducerDto producerCreate);
        //Update Methods
        Task UpdateAsync(UpdateProducerDto producerUpdate);
        //Delete Methods
        Task DeleteAsync(int id);
    }
}
