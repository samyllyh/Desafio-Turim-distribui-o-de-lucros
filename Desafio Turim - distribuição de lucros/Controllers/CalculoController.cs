using Desafio_Turim.Model;
using Desafio_Turim.TRA;
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
                int PesoArea = CalculoTRA.GetArea(funcionarios);
                int PesoSalario = CalculoTRA.GetSalario(funcionarios);
                int pesoAdimissao = CalculoTRA.GetDataAdmissao(funcionarios);

                foreach(var funcionario in funcionarios)
                {
                    var result = CalculoTRA.Distribuicao(PesoArea, PesoSalario, pesoAdimissao, funcionarios);
                }
                
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest("erro no calculo de distribuiçao");
            }
        }
    }
}
