using AutoMapper;
using EventManagementSystem.Application.DTOs.ProducerDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Application.Queries;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManagementSystem.Infrastructure.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;

        public ProducerService(IProducerRepository producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateProducerDto producerCreate)
        {
            var producerMap = _mapper.Map<Producer>(producerCreate);
            await _producerRepository.CreateAsync(producerMap);
        }

        public async Task DeleteAsync(int id)
        {
            await _producerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<GetProducerDto>> GetProducersAsync(ProducerQuery query)
        {
            var producers = await _producerRepository.GetAsync(
                query.Name,
                query.Page,
                query.PageSize
                );

            var producerMap = _mapper.Map<IEnumerable<GetProducerDto>>(producers);
            return producerMap;
        }

        public async Task<GetProducerDto> GetProducerByIdAsync(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            var producerMap = _mapper.Map<GetProducerDto>(producer);
            return producerMap;
        }

       

        public async Task UpdateAsync(UpdateProducerDto producerUpdate)
        {
            var producerMap = _mapper.Map<Producer>(producerUpdate);
            await _producerRepository.UpdateAsync(producerMap);
        }
    }
}
