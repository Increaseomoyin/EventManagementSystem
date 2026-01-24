using EventManagementSystem.Application.DTOs.ClientDto;
using EventManagementSystem.Application.DTOs.ProducerDto;
using EventManagementSystem.Application.Interfaces.Services;
using EventManagementSystem.Application.Queries;
using EventManagementSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
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
        /// <summary>
        /// Get All Producers / Get Producer by Name
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducers([FromQuery] ProducerQuery query)
        {

            try
            {
                var producers = await _producerService.GetProducersAsync(query);
                return Ok(producers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        /// <summary>
        /// Get Producer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetProducerById(int id)
        {
            try
            {
                var producer = await _producerService.GetProducerByIdAsync(id);
                return Ok(producer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }

        //UPDATE REQUEST

        /// <summary>
        /// Update a Producer account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [Authorize(Roles = "producer")]

        public async Task<IActionResult> UpdateProducerAsync(int id, [FromBody] UpdateProducerDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return BadRequest();
                await _producerService.UpdateAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
            
        }

        //DELETE REQUEST

        /// <summary>
        /// Delete a Producer account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "producer")]

        public async Task<IActionResult> DeleteProducreAsync(int id)
        {
            try
            {
                await _producerService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

           
        }
    }
}
