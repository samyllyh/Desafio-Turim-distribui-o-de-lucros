using Desafio_Turim.Context;
using Desafio_Turim.Context.Interface;
using Desafio_Turim.Model;
using Desafio_Turim.TRA;
using Desafio_Turim___distribuição_de_lucros.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Desafio_Turim.Context
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApiContext _context;
        int valor = 0;

        public EmployeeRepository(ApiContext context)
        => _context = context;

        public IEnumerable<Funcionarios> GetAllFuncionarios()
        {
            return _context.Funcionarios.ToList();

        }

        public  int Post(Funcionarios funcionarios)
        {
            _context.Funcionarios.Add(funcionarios);
            _context.SaveChanges();

            //esse retorno nos indicas o id que a dica foi salva, retorna o codico 201 em caso de sucesseso 
            return (funcionarios.MatriculaId);
        }
        public Funcionarios Put(int id, Funcionarios funcionarios)
        {
            _context.Entry(funcionarios).State = EntityState.Modified;
            _context.SaveChanges();

            return funcionarios;
        }

        public bool Delete(int id)
        {
            var funcionarios = _context.Funcionarios.FirstOrDefault(d => d.MatriculaId == id);

            _context.Funcionarios.Remove(funcionarios);
            _context.SaveChanges();

            return true;
        }

        public List<ResultDistribuicao> ViewDistribuicao(List<Funcionarios> funcionarios)
        {
            List<ResultDistribuicao> results = new();
            
            foreach (var funcionario in funcionarios)
            {
               
                int pesoArea = CalculoTRA.GetArea(funcionario);
                int pesoSalario = CalculoTRA.GetSalario(funcionario);
                int pesoAdimissao = CalculoTRA.GetDataAdmissao(funcionario);

                ResultDistribuicao resultDistribuicao = new()
                {
                    ValorDistribuicao = CalculoTRA.Distribuicao(pesoArea, pesoSalario, pesoAdimissao, funcionario)
                };
                results.Add(resultDistribuicao);
            }

            return (results);

        }

        public double PostDistribuicao(int valor)
        {
            valor = Int32.Parse(Console.ReadLine());
            return valor;
        }

        //somar o total distribuido
        public int SomaDistribuicao(List<ResultDistribuicao> resultDistribuicaos)
        {
            int valor = 0;
            foreach(var result in resultDistribuicaos)
            {
                valor += result.ValorDistribuicao;
            }

            return valor;
        }

        //view valor disponibilizado
        public int ViewDistribuicao()
        {
            return valor;
        }

        public int Saldo(int valor, int distribuicao)
        {
            int result = valor - distribuicao;
            return result ;
        }
    }
}