using AutoMapper;
using EventManagementSystem.Application.DTOs.TicketDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Application.Queries;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper, IEventRepository eventRepository) 
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task BuyTicketAsync(CreateTicketDto ticket)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(ticket.EventId);
            if (eventEntity == null)
                throw new Exception("Event not found");
            if (eventEntity.TicketsSold >= eventEntity.TotalTickets)
            {
                throw new Exception("Tickets sold out");
            }
            var nextNumber = eventEntity.TicketsSold + 1;
            var ticketNumber = $"EVT{eventEntity.Id} - {nextNumber}";

            var ticketMap = _mapper.Map<Ticket>(ticket);
            ticketMap.TicketNumber = ticketNumber;

            await _ticketRepository.CreateAsync(ticketMap);

            eventEntity.TicketsSold++;

            await _eventRepository.UpdateAsync(eventEntity);






        }

       

        public async Task<IEnumerable<GetTicketDto>> GetTicketAsync(TicketQuery query)
        {
            var ticket = await _ticketRepository.GetAsync(
                query.eventId,
                query.Page,
                query.PageSize
                );
            var ticketMap = _mapper.Map<IEnumerable<GetTicketDto>>(ticket);
            return ticketMap;
        }

        public async Task<GetTicketDto> GetTicketByIdAsync(int ticketId)
        {
            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            var ticketMap = _mapper.Map<GetTicketDto>(ticket);
            return ticketMap;
        }
    }
}
