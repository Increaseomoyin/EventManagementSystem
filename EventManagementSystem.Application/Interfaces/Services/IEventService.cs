using EventManagementSystem.Application.DTOs.EventDto;
using EventManagementSystem.Application.Queries;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.Interfaces.Services
{
    public interface IEventService
    {
        //Get Methods
        Task<IEnumerable<GetEventDto>> GetAsync(EventQuery query);
        Task<GetEventDto> GetEventByIdAsync(int id);
        //Create Methods
        Task CreateEventAsync(CreateEventDto eventCreate);
        //Update Methods
        Task UpdateAsync(UpdateEventDto eventUpdate);
        //Delete Methods
        Task DeleteEventAsync(int id);
    }
}
