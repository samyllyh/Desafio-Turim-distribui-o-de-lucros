using Desafio_Turim.Context;
using Desafio_Turim.Context.Interface;
using Desafio_Turim.Model;
using Desafio_Turim.TRA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Turim.Context
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApiContext _context;

        public EmployeeRepository(ApiContext context)
        => _context = context;

        public IEnumerable<Funcionarios> GetAllFuncionarios()
        {
                return _context.Funcionarios.ToList();
           
        }

        public Funcionarios Post(Funcionarios funcionarios)
        {
                _context.Funcionarios.Add(funcionarios);
                _context.SaveChanges();

                //esse retorno nos indicas o id que a dica foi salva, retorna o codico 201 em caso de sucesseso 
                return new { id = funcionarios.MatriculaId };
        }
        public Funcionarios Put(int id, Funcionarios funcionarios)
        {
                _context.Entry(funcionarios).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(funcionarios);
        }

        public bool Delete(int id)
        {
                var funcionarios = _context.Funcionarios.FirstOrDefault(d => d.MatriculaId == id);

                _context.Funcionarios.Remove(funcionarios);
                _context.SaveChanges();

                return funcionarios;
            }
        }

        public List<Funcionarios> ViewDistribuicao(List<Funcionarios> funcionarios)
        {
                var result = 0;
                foreach (var funcionario in funcionarios)
                {
                    var pesoArea = CalculoTRA.GetArea(funcionario);
                    int pesoSalario = CalculoTRA.GetSalario(funcionario);
                    int pesoAdimissao = CalculoTRA.GetDataAdmissao(funcionario);

                    result = CalculoTRA.Distribuicao(pesoArea, pesoSalario, pesoAdimissao, funcionario);
                }

                return (result);
            
        }

        public double PostDistribuicao(int valor)
        {

                int distribution = Int32.Parse(Console.ReadLine());
        }
   
}
