using Desafio_Turim.Model;

namespace Desafio_Turim.Context.Interface
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Funcionarios> GetAllFuncionarios();
        public int Post(Funcionarios funcionarios);
        public Funcionarios Put(int id, Funcionarios funcionarios);
        public bool Delete(int id);
    }
}