using EventManagementSystem.Application.DTOs.ProducerDto;
using EventManagementSystem.Application.Queries;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.Interfaces.Services
{
    public interface IProducerService
    {

        //Get methods
        Task<IEnumerable<GetProducerDto>> GetProducersAsync(ProducerQuery query);
        Task<GetProducerDto> GetProducerByIdAsync(int id);
        //Create Methods
    
        Task CreateAsync(CreateProducerDto producerCreate);
        //Update Methods
        Task UpdateAsync(UpdateProducerDto producerUpdate);
        //Delete Methods
        Task DeleteAsync(int id);
    }
}
