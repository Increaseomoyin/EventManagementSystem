using EventManagementSystem.Application.DTOs.TicketDto;
using EventManagementSystem.Application.Queries;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Application.Interfaces.Services
{
    public interface ITicketService
    {
        //Get Methods
        Task<GetTicketDto> GetTicketByIdAsync(int ticketId);
        Task<IEnumerable<GetTicketDto>> GetTicketAsync(
            TicketQuery query);
        //create Methods 
        Task<string>  BuyTicketAsync(CreateTicketDto ticket);
    }
}
