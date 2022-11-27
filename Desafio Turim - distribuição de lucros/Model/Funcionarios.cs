using Desafio_Turim.Model.Enum;

namespace Desafio_Turim.Model
{
    public class Funcionarios
    {
        public int MatriculaId { get; set; }

        public string Nome { get; set; }

        public Area_de_atuacao Area { get; set; }

        public Cargo Cargo { get; set; }

        public int Salario { get; set; }

        public int DataAdmissao { get; set; }
    }
}
