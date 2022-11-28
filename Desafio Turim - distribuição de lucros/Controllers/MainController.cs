using Desafio_Turim.Context;
using Desafio_Turim.Model;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Turim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ApiContext _context;

        public MainController(ApiContext context)
        => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Funcionarios>> GetAllFuncionarios()
        {
            try
            {
                return _context.funcionarios.ToList();
            }
            catch 
            {
               return BadRequest("erro ao buscar funcionarios");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Funcionarios>> GetAllDistribuicao()
        {
            try
            {
                var distribuicai = _context.funcionarios.ToList();
            }
            catch (global::System.Exception)
            {

                throw;
            }
        }

    }
}