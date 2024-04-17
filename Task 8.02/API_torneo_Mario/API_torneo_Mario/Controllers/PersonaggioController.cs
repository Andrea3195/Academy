using API_torneo_Mario.DTO;
using API_torneo_Mario.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_torneo_Mario.Controllers
{
    [Route("api/personaggi")]
    [ApiController]
    public class PersonaggioController : ControllerBase
    {
        private readonly PersonaggioService _service;

        public PersonaggioController(PersonaggioService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllPer());
        }

        [HttpPost("inserisci")]
        public IActionResult InsPersonaggio(PersonaggioDTO objPer)
        {
            if (_service.InsPersonaggio(objPer))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("modifica")]
        public IActionResult ModificaPersonaggio(PersonaggioDTO objPer)
        {
            if (_service.ModPersonaggio(objPer))
                return Ok();
            return BadRequest();
        }
    }
}
