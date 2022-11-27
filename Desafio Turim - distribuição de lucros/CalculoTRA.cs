using Desafio_Turim.Model;
using Desafio_Turim.Model.Enum;

namespace Desafio_Turim
{
    public class CalculoTRA
    {
        /*variaveis a receber e calcular*/

        public int Distribuicao(Funcionarios funcionarios)
        {
            try
            {
                var salario = funcionarios.Salario;

                switch (funcionarios.Area)
                {
                    case Area_de_atuacao.Diretoria: 
                        if(funcionarios.Cargo == Cargo.Funcionario && funcionarios.DataAdmissao > 8 && salario > 8000)
                        {
                            var result = (salario * 4) + (salario * 1) / salario * 5;
                            return result*12;
                        }
                        if(funcionarios.Cargo == Cargo.Funcionario && funcionarios.DataAdmissao == 8 || funcionarios.DataAdmissao > 3 && salario > 8000)
                        {
                            var result = (salario * 3) + (salario * 1) / salario * 5;
                            return result*12;
                        }
                        if(funcionarios.Cargo == Cargo.Funcionario && funcionarios.DataAdmissao == 3 || funcionarios.DataAdmissao > 1 && salario > 8000)
                        {
                            var result = (salario * 2) / salario * 5;
                            return result*12;
                        }
                        if(funcionarios.Cargo == Cargo.Funcionario && funcionarios.DataAdmissao == 1 && salario > 8000){
                            var result = (salario * 1) + (salario * 1) / salario * 5;
                            return result * 12;
                        }
                        if(funcionarios.Cargo == Cargo.Funcionario && funcionarios.DataAdmissao > 8  && salario > 5000 || salario == 8000)
                        {
                            var result = (salario * 4) + (salario * 1) / salario * 3;
                            return result * 12;
                        }
                        break;
                }
               
            }
            catch (Exception)
            {

                return 0;
            }
           

            
        }
    }
}