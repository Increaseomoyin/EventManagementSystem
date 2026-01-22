using EventManagementSystem.Application.DTOs.ClientDto;
using EventManagementSystem.Application.DTOs.ProducerDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Application.Queries;
using EventManagementSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.API.Controllers
{
    [Route("api/producers")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        //GET REQUESTS
        [HttpGet]
        public async Task<IActionResult> GetProducers([FromQuery] ProducerQuery query)
        {
            var producers = await _producerService.GetProducersAsync(query);
            return Ok(producers);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProducerById(int id)
        {
            var producer = await _producerService.GetProducerByIdAsync(id);
            return Ok(producer);
        }

        //UPDATE REQUEST
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProducerAsync(int id, [FromBody] UpdateProducerDto dto)
        {
            if (id != dto.Id)
                return BadRequest();
            await _producerService.UpdateAsync(dto);
            return NoContent();
        }

        //DELETE REQUEST
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProducreAsync(int id)
        {

            await _producerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
