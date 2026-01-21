using AutoMapper;
using EventManagementSystem.Application.DTOs.ProducerDto;
using EventManagementSystem.Application.Interfaces.Services;
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

        public async Task<ICollection<GetProducerDto>> GetAllProducersAsync()
        {
            var producers = await _producerRepository.GetAllAsync();
            var producerMap = _mapper.Map<ICollection<GetProducerDto>>(producers);
            return producerMap;
        }

        public async Task<GetProducerDto> GetProducerByIdAsync(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            var producerMap = _mapper.Map<GetProducerDto>(producer);
            return producerMap;
        }

        public async Task<GetProducerDto> GetProducerByNameAsync(string name)
        {
            var producer = await _producerRepository.GetByNameAsync(name);
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
