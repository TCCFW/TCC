using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RestauranteServidor.BLL
{
    public class SubGruposBLL
    {
        public void IncluirSubGrupos(Model.SubGrupoModel subgrupos)
        {
            if (subgrupos.Subgrupo.Trim().Length == 0)
            {
                throw new Exception("O subgrupo é obrigatorio");
            }

            DAL.SubGruposDAL subgruposDAL = new DAL.SubGruposDAL();
            subgruposDAL.salvarSubGrupos(subgrupos);
        }

        public void AlterarSubGrupos(Model.SubGrupoModel subgrupos)
        {
            if (subgrupos.Codigo >= 1)
            {
                DAL.SubGruposDAL subgruposDAL = new DAL.SubGruposDAL();
                subgruposDAL.AlterarSubGrupos(subgrupos);
            }
            else
            {
                throw new Exception("Informe o codigo antes de alterar");
            }

        }

        public void ExcluirSubGrupos(Model.SubGrupoModel subgrupos)
        {
            if (subgrupos.Codigo >= 1)
            {
                DAL.SubGruposDAL subgruposDAL = new DAL.SubGruposDAL();
                subgruposDAL.ExcluirSubGrupos(subgrupos);
            }
            else
            {
                throw new Exception("Informe o codigo antes de excluir");
            }
        }

        public DataTable getSubGruposDT(string ordem, string bloqueado, string parametro)
        {
            DAL.SubGruposDAL subgrupos = new DAL.SubGruposDAL();
            return subgrupos.getSubGruposDT(ordem,bloqueado,parametro);
        }
    }
}
