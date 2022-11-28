using Desafio_Turim.Model;
using Desafio_Turim.Model.Enum;

namespace Desafio_Turim.TRA
{
    public class CalculoTRA
    {
        /*variaveis a receber e calcular*/

        public int Distribuicao(int pesoArea, int pesoSalario, int PesoAdmissao, Funcionarios funcionarios)
        {
            try
            {
                var result = 0;
                if(pesoArea == 1)
                {
                    result = (funcionarios.Salario * PesoAdmissao) + (funcionarios.Salario * pesoArea) / funcionarios.Salario * pesoSalario;
                    return result;
                }
                if(pesoArea == 2)
                {
                    result = (funcionarios.Salario * PesoAdmissao) + (funcionarios.Salario * pesoArea) / funcionarios.Salario * pesoSalario;
                    return result;
                }
                if(pesoArea == 3)
                {
                    result = (funcionarios.Salario * PesoAdmissao) + (funcionarios.Salario * pesoArea) / funcionarios.Salario * pesoSalario;
                    return result;
                }
                if(pesoArea == 4)
                {
                    result = (funcionarios.Salario * PesoAdmissao) + (funcionarios.Salario * pesoArea) / funcionarios.Salario * pesoSalario;
                    return result;
                }
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public int GetArea(Funcionarios funcionarios)
        {
            try
            {
                if (funcionarios.Area == Area_de_atuacao.Financiero || Area_de_atuacao.Cotabilidade || Area_de_atuacao.Tecnologia)
                {
                    return 2;
                }
                if (funcionarios.Area == Area_de_atuacao.Diretoria)
                {
                    return 1;
                }
                if(funcionarios.Area == Area_de_atuacao.Servocos_Gerais)
                {
                    return 3;
                }
                if(funcionarios.Area == Area_de_atuacao.Relecionamento_cliente)
                {
                    return 4;
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public int GetSalario(Funcionarios funcionarios)
        {
            if(funcionarios.Salario > 8000)
            {
                return 5;
            }
            if(funcionarios.Salario == 8000 || funcionarios.Salario < 5000)
            {
                return 3;
            }
            if(funcionarios.Salario == 5000 || funcionarios.Salario < 3000)
            {
                return 2;
            }
            if(funcionarios.Salario >= 3000 || funcionarios.Cargo == Cargo.Estagiario)
            {
                return 1;
            }
        }

        public int GetDataAdmissao(Funcionarios funcionarios)
        {
            if(funcionarios.DataAdmissao <= 1)
            {
                return 1;
            }
            if(funcionarios.DataAdmissao > 1 || funcionarios.DataAdmissao < 3)
            {
                return 2;
            }
            if(funcionarios.DataAdmissao == 3 || funcionarios.DataAdmissao < 8)
            {
                return 3;
            }
            if (funcionarios.DataAdmissao > 8)
            {
                return 4;
            }
        }
    }
}