using EventManagementSystem.Application.DTOs.EventDto;
using EventManagementSystem.Application.DTOs.TicketDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.API.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }


        /// <summary>
        /// Get Ticket by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTicketByIdAsync(int id)
        {
            try
            {
                var result = await _ticketService.GetTicketByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        /// <summary>
        /// Get All Tickets / Get Ticket by EventId
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTicketsAsync([FromQuery] TicketQuery query)
        {
            try
            {
                var result = await _ticketService.GetTicketAsync(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        /// <summary>
        /// Buy Ticket (only Clients)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        //CREATE REQUESTS
        [HttpPost]
        [Authorize(Roles = "client")]

        public async Task<IActionResult> BuyTicketAsync(CreateTicketDto dto)
        {
            try
            {
                await _ticketService.BuyTicketAsync(dto);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
            
        }

    }
}
