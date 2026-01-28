using AutoMapper;
using EventManagementSystem.Application.DTOs.TicketDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Application.Queries;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Domain.Interfaces;
using EventManagementSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IClientRepository _clientRepository;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper, IEventRepository eventRepository, UserManager<AppUser> userManager, IClientRepository clientRepository) 
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _eventRepository = eventRepository;
            _userManager = userManager;
            _clientRepository = clientRepository;
        }

        public async Task<string> BuyTicketAsync(CreateTicketDto ticket)
        {
            var eventEntity = await _eventRepository.GetByIdAsync(ticket.EventId);
            if (eventEntity == null)
                throw new Exception("Event not found");
            // ✅ 1. Business rule: one client per event
            var alreadyAttending = eventEntity.EventAttendees
                .Any(ea => ea.ClientId == ticket.ClientId);

            if (alreadyAttending)
                throw new Exception("Client already has a ticket for this event");
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


            var eventattendee = new EventAttendee()
            {
                ClientId = ticket.ClientId,
                EventId = ticket.EventId,
            };

            eventEntity.EventAttendees.Add(eventattendee);

            await _eventRepository.UpdateAsync(eventEntity);


            var client = await _clientRepository.GetByIdAsync(ticket.ClientId);
            var appUserId = client.IdentityUserId;
            var appUser = await _userManager.FindByIdAsync(appUserId);
            var email = await _userManager.GetEmailAsync(appUser);

            return email;



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
