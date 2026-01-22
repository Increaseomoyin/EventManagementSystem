using AutoMapper;
using EventManagementSystem.Application.DTOs.EventDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Application.Queries;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task CreateEventAsync(CreateEventDto eventCreate)
        {
            var eventMap = _mapper.Map<Event>(eventCreate);
            await _eventRepository.CreateAsync(eventMap);
        }

        public async Task DeleteEventAsync(int id)
        {
            await _eventRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GetEventDto>> GetAsync(EventQuery query)
        {
            var events = await _eventRepository.GetAsync(
                query.name,
                query.producerName,
                query.Page,
                query.PageSize);
            var eventMap = _mapper.Map<IEnumerable<GetEventDto>>(events);
            return eventMap;
        }

        public async Task<GetEventDto> GetEventByIdAsync(int id)
        {   
              var events =await  _eventRepository.GetByIdAsync(id);
            var eventMap = _mapper.Map<GetEventDto>(events);
            return eventMap;


        }

        public async Task UpdateAsync(UpdateEventDto eventUpdate)
        {   
            var eventMap = _mapper.Map<Event>(eventUpdate);
            await _eventRepository.UpdateAsync(eventMap);
        }
    }
}
