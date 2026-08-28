using Microsoft.AspNetCore.Mvc;
using TestDB.interfaces;
using TestDB.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestDBApi.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonaEmpresaController : ControllerBase
    {
        private readonly IPersonaEmpresa personaService;

        public PersonaEmpresaController(IPersonaEmpresa personaService )
        {
            this.personaService = personaService;
        }

        // GET: api/<personas>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaEmpresa>>> Get()
        {
           var listado = await personaService.ListadoEmpleados();

            if (listado is null)
            {
                return  NotFound();
            }

            return Ok(listado);
        }


        // POST api/<personas>
        [HttpPost]
        public async Task<ActionResult<PersonaEmpresa>> Post(PersonaEmpresa persona)
        {
            var empleado = await personaService.CrearEmpleado(persona);

            if (empleado is null)
            {
                return BadRequest();
            }

            return empleado;
        }

    }
}
