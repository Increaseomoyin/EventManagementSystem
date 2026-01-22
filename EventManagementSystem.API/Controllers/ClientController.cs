using EventManagementSystem.Application.DTOs.ClientDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.API.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

       // GET REQUESTS
        [HttpGet]
        public async Task<IActionResult> GetClientsAsync([FromQuery] ClientQuery query)
        {

            var clients = await _clientService.GetClientAsync(query);
            return Ok(clients);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClientByIdAsync(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            return Ok(client);
        }

        
        //UPDATE REQUEST
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateClientAsync(int id,  [FromBody] UpdateClientDto dto)
        {
            if (id != dto.Id)
                return BadRequest();
            await _clientService.UpdateClientAsync(dto);
            return NoContent();
        }

        //DELETE REQUEST
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteClientAsync(int id)
        {
            
            await _clientService.DeleteClientAsync(id);
            return NoContent();
        }

    }
}
