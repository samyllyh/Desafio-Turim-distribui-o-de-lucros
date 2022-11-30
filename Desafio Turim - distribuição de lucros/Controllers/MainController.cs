using Desafio_Turim.Context;
using Desafio_Turim.Context.Interface;
using Desafio_Turim.Model;
using Desafio_Turim.TRA;
using Desafio_Turim___distribuição_de_lucros.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
        public ActionResult<List<Funcionarios>> Get()
        {
            return Ok(_employeeRepository.GetHashCode);
        }

        [HttpPost]
        public ActionResult Post()
        {
            return Ok(_employeeRepository.Post);
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