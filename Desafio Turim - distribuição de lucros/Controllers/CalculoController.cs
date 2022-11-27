using Desafio_Turim.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Turim.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        [HttpGet]
        public ActionResult ViewDistribuicao(Funcionarios funcionarios)
        {
            try
            {
                var result = CalculoTRA.Distribuicao(funcionarios);

                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest("erro no calculo de distribuiçao");
            }
        }
    }
}
