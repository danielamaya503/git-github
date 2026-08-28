using Microsoft.AspNetCore.Mvc;
using TestDB.interfaces;
using TestDB.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestDBApi.Controllers
{
    [Route("api/empresas")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresa empresaService;

        public EmpresaController(IEmpresa empresaService)
        {
            this.empresaService = empresaService;
        }

        // GET: api/<empresas>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> Get()
        {
           var listado = await empresaService.ListadoEmpresa();

            if(listado is null)
            {
                return NotFound();
            }

            return Ok(listado);
        }


        // POST api/<empresas>
        [HttpPost]
        public async Task<ActionResult<Empresa>> Post(Empresa empresa)
        {
            var existe = await empresaService.CrearEmpresa(empresa);

            if(existe is null)
            {
                return BadRequest();
            }

            return Ok(existe);
        }

    }
}
