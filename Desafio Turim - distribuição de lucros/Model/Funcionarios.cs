using Desafio_Turim.Model.Enum;

namespace Desafio_Turim.Model
{
    public class Funcionarios
    {
        public int Matricula { get; set; }

        public string Nome { get; set; }

        public Area_de_atuacao Area { get; set; }

        public Cargo Cargo { get; set; }

        public int Salario { get; set; }

        public DateTime DataAdmissao { get; set; }
    }
}
