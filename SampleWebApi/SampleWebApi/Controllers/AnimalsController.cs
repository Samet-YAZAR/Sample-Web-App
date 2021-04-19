using Microsoft.AspNetCore.Mvc;
using SampleWebApi.Services;
using SampleWebApi.Services.AnimalServiceAsync;
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
        private readonly IDatabaseService _service1;
        private readonly IDatabaseService2 _service2;

        public AnimalsController(IDatabaseService service, IDatabaseService2 service2)
        {
            _service1 = service;
            _service2 = service2;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_service1.GetAnimals());
        }

        [HttpGet("proc")]
        public async Task<IActionResult> GetAnimalsByProc()
        {
            return Ok(await _service2.GetAnimalsByStoredProcedureAsync());
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateAnimals()
        {
            return Ok(await _service2.ChangeAnimalAsync();
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAnimals2()
        {
            return Ok(await _service2.GetAnimalsAsync());
        }
    }
}
