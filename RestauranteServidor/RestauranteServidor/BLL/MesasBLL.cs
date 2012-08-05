using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RestauranteServidor.BLL
{
    public class MesasBLL
    {
        public void IncluirMesas(Model.MesasModel mesas)
        {
            if (mesas.Mesa.Trim().Length == 0)
            {
                throw new Exception("A mesa é obrigatória");
            }
            DAL.MesasDAL mesasDAL = new DAL.MesasDAL();
            mesasDAL.salvarMesas(mesas);
        }

        public void AlterarMesas(Model.MesasModel mesas)
        {
            if (mesas.Codigo >= 1)
            {
                DAL.MesasDAL mesasDAL = new DAL.MesasDAL();
                mesasDAL.AlterarMesas(mesas);
            }
            else
            {
                throw new Exception("Informe o codigo antes de alterar");
            }

        }

        public void ExcluirMesas(Model.MesasModel mesas)
        {
            if (mesas.Codigo >= 1)
            {
                DAL.MesasDAL mesasDAL = new DAL.MesasDAL();
                mesasDAL.ExcluirMesas(mesas);
            }
            else
            {
                throw new Exception("Informe o codigo antes de excluir");
            }
        }

        public DataTable getMesasDT(string ordem, string bloqueado, string parametro)
        {
            DAL.MesasDAL mesas = new DAL.MesasDAL();
            return mesas.getMesasDT(ordem, bloqueado, parametro);
        }
        
    }
}
