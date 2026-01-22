using AutoMapper;
using EventManagementSystem.Application.DTOs.AuthDto.LoginDto;
using EventManagementSystem.Application.DTOs.ClientDto;
using EventManagementSystem.Application.DTOs.EventDto;
using EventManagementSystem.Application.DTOs.ProducerDto;
using EventManagementSystem.Application.DTOs.TicketDto;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Helper.MappingProfile
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Producer, GetProducerDto>();
            CreateMap<Producer, UpdateProducerDto>();
            CreateMap<Producer, DeleteProducerDto>();
            CreateMap<Producer, CreateProducerDto>();
            CreateMap<CreateProducerDto, Producer>();
            CreateMap<DeleteProducerDto, Producer>();
            CreateMap<UpdateProducerDto, Producer>();
            CreateMap<GetProducerDto, Producer>();

            CreateMap<Client, GetClientDto>();
            CreateMap<Client, UpdateClientDto>();
            CreateMap<Client, DeleteClientDto>();
            CreateMap<Client, CreateClientDto>();
            CreateMap<CreateClientDto, Client>();
            CreateMap<DeleteClientDto, Client>();
            CreateMap<UpdateClientDto, Client>();
            CreateMap<GetClientDto, Client>();

            CreateMap<Event, GetEventDto>();
            CreateMap<Event, UpdateEventDto>();
            CreateMap<Event, DeleteEventDto>();
            CreateMap<Event, CreateEventDto>();
            CreateMap<CreateEventDto, Event>();
            CreateMap<DeleteEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
            CreateMap<GetEventDto, Event>();

            CreateMap<Ticket, GetTicketDto>();
            CreateMap<Ticket, CreateTicketDto>();
            CreateMap<CreateTicketDto, Ticket>();
            CreateMap<GetTicketDto, Ticket>();

            CreateMap<AppUser, TokenUserDto>();
            CreateMap<TokenUserDto, AppUser>();
        }
    }
}
