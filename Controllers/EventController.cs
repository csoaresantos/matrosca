using System.Collections.Generic;
using System.Linq;
using Matrosca.API.Data;
using Matrosca.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Matrosca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController: ControllerBase
    {
        private readonly DataContext _context;
        public EventController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> get(int id)
        {
            try
            {
                var results = await _context.Events.ToListAsync();
                return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error!");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> getById(int id)
        {
            try
            {
                return await _context.Events.FirstOrDefaultAsync(x=> x.EventId == id);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database error!");
            }
        }
    }
}