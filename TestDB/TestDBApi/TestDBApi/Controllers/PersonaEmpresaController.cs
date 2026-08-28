using Microsoft.AspNetCore.Mvc;
using TestDB.CONCRETES;
using TestDB.interfaces;
using TestDB.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestDBApi.Controllers
{
    [Route("api/Persona")]
    [ApiController]
    public class PersonaEmpresaController : ControllerBase
    {
        private readonly IPersona personaService;

        public PersonaEmpresaController(IPersona personaService)
        {
            this.personaService = personaService;
        }

        // GET: api/<PersonaEmpresaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaEmpresa>>> Listar()
        {
            var personas = await personaService.GetEmpleados();
            return Ok(personas);
        }


        // POST api/<PersonaEmpresaController>
        [HttpPost("{idEmpresa}")]
        public async Task<ActionResult<PersonaEmpresa>> Crear(int idEmpresa, [FromBody] PersonaEmpresa persona)
        {
            var personal = await personaService.CrearEmpleadoPorEmpresa(idEmpresa, persona);
            

            if (personal is null)
            {
                return BadRequest(new
                {
                    mensaje = "La empresa o la persona indicada no existe."
                });
            }

            return Ok(personal);


        }


    }
}
