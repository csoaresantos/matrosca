using Microsoft.AspNetCore.Mvc;
using System;

namespace Matrosca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtmController: ControllerBase
    {
        [HttpGet("{letters}")]
        public IActionResult Get(string letters)
        {
            char[] chars = letters.ToCharArray();
            Array.Reverse(chars);
            return Ok(String.Join(null, chars));
        }
        
    }
}