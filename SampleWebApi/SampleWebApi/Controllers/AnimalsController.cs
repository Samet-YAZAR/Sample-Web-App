using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok();
        }

        [HttpGet("proc")]
        public async Task<IActionResult> GetAnimalsByProc()
        {
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateAnimals()
        {
            return Ok();
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAnimals2()
        {
            return Ok();
        }
    }
}
