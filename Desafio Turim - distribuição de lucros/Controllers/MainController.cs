using Desafio_Turim.Context;
using Desafio_Turim.Model;
using Desafio_Turim___distribuição_de_lucros.Model;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Turim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        readonly EmployeeRepository _employeeRepository;
        public MainController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Funcionarios>> Get()
        {
            return Ok(_employeeRepository.GetAllFuncionarios);
        }

        [HttpPost]
        public ActionResult Post(Funcionarios funcionarios)
        {
            return Ok(_employeeRepository.Post(funcionarios));
        }

        [HttpPut]
        public ActionResult Put(int id, Funcionarios funcionarios)
        {
            return Ok(_employeeRepository.Put(id, funcionarios));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return Ok(_employeeRepository.Delete(id));
        }

        [HttpGet("/distribuição")]
        public ActionResult ViewDistribuicao(List<Funcionarios> funcionarios)
        {
            return Ok(_employeeRepository.ViewDistribuicao(funcionarios));
        }

        [HttpPost("/distribuição")]
        public ActionResult PostDistribuicao(int valor)
        {
            return Ok(_employeeRepository.PostDistribuicao(valor));
        }

        [HttpGet("/distribuicao/results")]
        public ActionResult SomaDistribuicao(List<ResultDistribuicao> resultDistribuicaos)
        {
            return Ok(_employeeRepository.SomaDistribuicao(resultDistribuicaos));
        }

        [HttpGet("/distribuicao/viewTotal")] 
        public ActionResult ViewDistribuicao()
        {
            return Ok(_employeeRepository.ViewDistribuicao());
        }

        [HttpGet("/distribuição/saldo")]
        public ActionResult Saldo(int valor, int distribuicao)
        {
            return Ok(_employeeRepository.Saldo(valor, distribuicao));
        }

    }
}