using Microsoft.AspNetCore.Mvc;
using TestDB.CONCRETES;
using TestDB.interfaces;
using TestDB.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestDBApi.Controllers
{
    [Route("api/Empresa")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresa empresaService;

        public EmpresaController(IEmpresa empresaService)
        {
            this.empresaService = empresaService;
        }

        // GET: api/<EmpresaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> Listar()
        {
            var empresas = await empresaService.ListadoEmpresa();

            return Ok(empresas);
        }

        // POST api/<EmpresaController>
        [HttpPost]
        public async Task<ActionResult<Empresa>> Registrar([FromBody] Empresa empresa)
        {
            var nuevaEmpresa = await empresaService.CrearEmpresa(empresa);
            return Ok(nuevaEmpresa);
        }

 
    }
}
