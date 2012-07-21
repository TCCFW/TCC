using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RestauranteServidor.BLL
{
    public class CidadesBLL
    {
        public void IncluirCidades(Model.CidadeModel cidades)
        {
            if (cidades.Cidade.Trim().Length == 0)
            {
                throw new Exception("A cidade é obrigatória");
            }
            if (cidades.UF.Trim().Length == 0)
            {
                throw new ApplicationException("O UF é obrigatório");
            }
            DAL.CidadesDAL cidadesDAL = new DAL.CidadesDAL();
            cidadesDAL.salvarCidades(cidades);
        }

        public void AlterarCidades(Model.CidadeModel cidades)
        {
            if (cidades.Codigo >=1)
            {
                DAL.CidadesDAL cidadesDAL = new DAL.CidadesDAL();
                cidadesDAL.AlterarCidades(cidades);
            }
            else
            {
                throw new Exception("Informe o codigo antes de alterar");
            }

        }

        public void ExcluirCidades(Model.CidadeModel cidades)
        {
            if (cidades.Codigo >= 1)
            {
                DAL.CidadesDAL cidadesDAL = new DAL.CidadesDAL();
                cidadesDAL.ExcluirCidades(cidades);
            }
            else
            {
                throw new Exception("Informe o codigo antes de excluir");
            }
        }

        public DataTable getCidadesDT(string ordem, string bloqueado, string parametro)
        {
            DAL.CidadesDAL cidades = new DAL.CidadesDAL();
            return cidades.getCidadesDT(ordem,bloqueado,parametro);
        }

    }
}
