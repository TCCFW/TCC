using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RestauranteServidor.BLL
{
    public class GruposBLL
    {
        public void IncluirGrupos(Model.GrupoModel grupos)
        {
            if (grupos.Grupo.Trim().Length == 0)
            {
                throw new Exception("O grupo é obrigatorio");
            }

            DAL.GruposDAL gruposDAL = new DAL.GruposDAL();
            gruposDAL.salvarGrupos(grupos);
        }

        public void AlterarGrupos(Model.GrupoModel grupos)
        {
            if (grupos.Codigo >= 1)
            {
                DAL.GruposDAL gruposDAL = new DAL.GruposDAL();
                gruposDAL.AlterarGrupos(grupos);
            }
            else
            {
                throw new Exception("Informe o codigo antes de alterar");
            }

        }

        public void ExcluirGrupos(Model.GrupoModel grupos)
        {
            if (grupos.Codigo >= 1)
            {
                DAL.GruposDAL gruposDAL = new DAL.GruposDAL();
                gruposDAL.ExcluirGrupos(grupos);
            }
            else
            {
                throw new Exception("Informe o codigo antes de excluir");
            }
        }

        public DataTable getGruposDT(string ordem, string bloqueado, string parametro)
        {
            DAL.GruposDAL grupos = new DAL.GruposDAL();
            return grupos.getGruposDT(ordem,bloqueado,parametro);
        }

    }
}
