using Desafio_Turim.Context;
using Desafio_Turim.Model;
using Desafio_Turim.TRA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                return _context.Funcionarios.ToList();
            }
            catch 
            {
               return BadRequest("erro ao buscar funcionarios");
            }
        }
        [HttpGet]
        public ActionResult ViewDistribuicao(List<Funcionarios> funcionarios)
        {
            try
            {
                var result = 0;
                foreach (var funcionario in funcionarios)
                {
                    var pesoArea = CalculoTRA.GetArea(funcionario);
                    int pesoSalario = CalculoTRA.GetSalario(funcionario);
                    int pesoAdimissao = CalculoTRA.GetDataAdmissao(funcionario);

                    result = CalculoTRA.Distribuicao(pesoArea, pesoSalario, pesoAdimissao, funcionario);
                }

                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest("erro no calculo de distribuiçao");
            }
        }

        [HttpPost]
        public ActionResult Post(Funcionarios funcionarios)
        {
            try
            {
                _context.Funcionarios.Add(funcionarios);
                _context.SaveChanges();

                //esse retorno nos indicas o id que a dica foi salva, retorna o codico 201 em caso de sucesseso 
                return new CreatedAtRouteResult("Obter dicas",
                    new { id = funcionarios.MatriculaId }, funcionarios);
            }
            catch (Exception)
            {
                return BadRequest("dados invalidos");
            }
        }

        //alteracao das dicas completa, tanto o titudo como a descricao, trocar pelo patch se quiser apenas alterar uma das informacoes
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Funcionarios funcionarios)
        {
            try
            {
                _context.Entry(funcionarios).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(funcionarios);
            }
            catch (Exception)
            {
                return BadRequest("Error ao alterar dados");
            }
        }

        //excluir uma dica
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var funcionarios = _context.Funcionarios.FirstOrDefault(d => d.MatriculaId == id);

                _context.Funcionarios.Remove(funcionarios);
                _context.SaveChanges();

                return Ok(funcionarios);
            }
            catch (Exception)
            {
                return NotFound("pessoa não localizada");
            }
        }

    }
}