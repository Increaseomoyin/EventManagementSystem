using EventManagementSystem.Application.DTOs.EventDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        //GET REQUESTS

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEventByIdAsync(int id)
        {
            var result = await _eventService.GetEventByIdAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetEventsAsync([FromQuery] EventQuery query)
        {
            var result = await _eventService.GetAsync(query);
            return Ok(result);
        }

        //CREATE REQUESTS
        [HttpPost]
        public async Task<IActionResult> CreateEventsAsync(CreateEventDto dto)
        {
            await _eventService.CreateEventAsync(dto);
            return NoContent();
        }

        //UPDATE REQUESTS
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEventsAsync(int id, [FromBody] UpdateEventDto dto)
        {
            if (id != dto.Id)
                return BadRequest();
            await _eventService.UpdateAsync(dto);
            return NoContent();
        }

        //DELETE REQUESTS
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEventsAsync(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return NoContent();
        }
    }
}
