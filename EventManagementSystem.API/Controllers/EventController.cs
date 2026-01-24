using EventManagementSystem.Application.DTOs.EventDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Application.Queries;
using Microsoft.AspNetCore.Authorization;
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
        /// <summary>
        /// Get Event by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEventByIdAsync(int id)
        {
            var result = await _eventService.GetEventByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Get all Events / Get Events by Name / Get Events by ProducerName
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEventsAsync([FromQuery] EventQuery query)
        {
            var result = await _eventService.GetAsync(query);
            return Ok(result);
        }

        //CREATE REQUESTS
        /// <summary>
        /// Create an Event (only producers)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "producer")]

        public async Task<IActionResult> CreateEventsAsync(CreateEventDto dto)
        {
            await _eventService.CreateEventAsync(dto);
            return NoContent();
        }

        //UPDATE REQUESTS
        /// <summary>
        /// Update an Event information (only producers)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "producer")]


        public async Task<IActionResult> UpdateEventsAsync(int id, [FromBody] UpdateEventDto dto)
        {
            if (id != dto.Id)
                return BadRequest();
            await _eventService.UpdateAsync(dto);
            return NoContent();
        }

        //DELETE REQUESTS

        /// <summary>
        /// Delete an event from Db (only producers)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "producer")]

        public async Task<IActionResult> DeleteEventsAsync(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return NoContent();
        }
    }
}
