using EventManagementSystem.Application.DTOs.ClientDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Application.Queries;
using Microsoft.AspNetCore.Authorization;
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


        /// <summary>
        /// Get All clients / Get Client by Name
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
       // GET REQUESTS
        [HttpGet]
        public async Task<IActionResult> GetClientsAsync([FromQuery] ClientQuery query)
        {
            try
            {
                var clients = await _clientService.GetClientAsync(query);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        /// <summary>
        /// Get client by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClientByIdAsync(int id)
        {

            try
            {
                 var client = await _clientService.GetClientByIdAsync(id);
                 return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }



        //UPDATE REQUEST

        /// <summary>
        /// Update Client details  (only Clients)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> UpdateClientAsync(int id,  [FromBody] UpdateClientDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return BadRequest();
                await _clientService.UpdateClientAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            
        }

        //DELETE REQUEST
        /// <summary>
        /// Delete a Client from Db  (only Clients)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "client")]

        public async Task<IActionResult> DeleteClientAsync(int id)
        {

            try
            {
                await _clientService.DeleteClientAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

         
        }

    }
}
