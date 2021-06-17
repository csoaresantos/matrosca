using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Matrosca.Repository;
using Matrosca.Domain;
using AutoMapper;
using Matrosca.API.DTOs;

namespace Matrosca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IMatroscaRepository _repo;

        public IMapper _mapper { get; }

        public EventController(IMatroscaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var events = await _repo.GetAllEventAsync(true);
                var results = _mapper.Map<IEnumerable<EventDTO>>(events);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error!");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var single = await _repo.GetEventAsyncById(id, true);
                var result = _mapper.Map<EventDTO>(single);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error!");
            }
        }

        [HttpGet("getByTheme/theme")]
        public async Task<IActionResult> Get(string theme)
        {
            try
            {
                var result = await _repo.GetAllEventAsyncByTheme(theme, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Event model)
        {
            try
            {
                _repo.Add(model);

                var result = await _repo.SaveChangesAsync();

                if (result)
                {
                    return Created($"/api/evenet/{model.EventId}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error!");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int eventId, Event model)
        {
            try
            {
                var evenet = await _repo.GetEventAsyncById(eventId, false);

                if(evenet == null) return NotFound();

                _repo.Add(model);

                var result = await _repo.SaveChangesAsync();

                if (result)
                {
                    return Created($"/api/evenet/{model.EventId}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error!");
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int eventId)
        {
            try
            {
                var evenet = await _repo.GetEventAsyncById(eventId, false);

                if(evenet == null) return NotFound();
                
                _repo.Delete(evenet);

                var result = await _repo.SaveChangesAsync();

                if (result)
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error!");
            }

            return BadRequest();
        }

        [HttpGet("/calc")]
        public IActionResult Calc()
        {
           return Ok();
        }
    }
}