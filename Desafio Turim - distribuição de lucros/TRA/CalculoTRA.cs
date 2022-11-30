using Desafio_Turim.Model;
using Desafio_Turim.Model.Enum;

namespace Desafio_Turim.TRA
{
    public class CalculoTRA
    {
        /*variaveis a receber e calcular*/

        public static int Distribuicao(int pesoArea, int pesoSalario, int PesoAdmissao, Funcionarios funcionarios)
        {
            try
            {
                int result;
                if(pesoArea == 1)
                    return result = (funcionarios.Salario * PesoAdmissao) + (funcionarios.Salario * pesoArea) / funcionarios.Salario * pesoSalario;
        
                if(pesoArea == 2)
                    return result = (funcionarios.Salario * PesoAdmissao) + (funcionarios.Salario * pesoArea) / funcionarios.Salario * pesoSalario;

                if(pesoArea == 3)
                {
                    result = (funcionarios.Salario * PesoAdmissao) + (funcionarios.Salario * pesoArea) / funcionarios.Salario * pesoSalario;
                    return result;
                }
                if (pesoArea == 4)
                {
                    result = (funcionarios.Salario * PesoAdmissao) + (funcionarios.Salario * pesoArea) / funcionarios.Salario * pesoSalario;
                    return result;
                }
                else
                    return 0;
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public static int GetArea(Funcionarios funcionarios)
        {
            try
            {
                if (funcionarios.Area == Area_de_atuacao.Financiero)
                     return 2;

                if (funcionarios.Area == Area_de_atuacao.Cotabilidade)
                    return 2;

                if(funcionarios.Area == Area_de_atuacao.Tecnologia)
                    return 2;

                if (funcionarios.Area == Area_de_atuacao.Diretoria)
                    return 1;
                
                if(funcionarios.Area == Area_de_atuacao.Servicos_Gerais)
                    return 3;
                
                if(funcionarios.Area == Area_de_atuacao.Relecionamento_cliente)
                    return 4;

                else
                    return 0;
                
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public static int GetSalario(Funcionarios funcionarios)
        {
            if(funcionarios.Salario > 8000)
                 return 5;   
            if(funcionarios.Salario == 8000 || funcionarios.Salario < 5000)
                return 3;
            if(funcionarios.Salario == 5000 || funcionarios.Salario < 3000)
                 return 2;
            if(funcionarios.Salario >= 3000 || funcionarios.Cargo == Cargo.Estagiario)
                 return 1;
            else
                return 0;
        }

        public static int GetDataAdmissao(Funcionarios funcionarios)
        {
            if(funcionarios.DataAdmissao <= 1)
                return 1;
            if(funcionarios.DataAdmissao > 1 || funcionarios.DataAdmissao < 3)
                return 2;
            if(funcionarios.DataAdmissao == 3 || funcionarios.DataAdmissao < 8)
                return 3;   
            if (funcionarios.DataAdmissao > 8)
                return 4;
            
            else
                return 0;
        }
    }
}