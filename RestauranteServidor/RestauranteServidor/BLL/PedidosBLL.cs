using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RestauranteServidor.BLL
{
    public class PedidosBLL
    {
        public void IncluirPedidos(Model.PedidoModel pedidos)
        {
            if (pedidos.Garcom== 0)
            {
                throw new ApplicationException("Informe o garçom");
            }
            if (pedidos.Mesa == 0)
            {
                throw new ApplicationException("Informe a mesa");
            }

            DAL.PedidoDAL pedidosDAL = new DAL.PedidoDAL();
            pedidosDAL.salvarPedidos(pedidos);
        }

        public void AlterarPedidos(Model.PedidoModel pedidos)
        {
            if (pedidos.Codigo >= 1)
            {
                DAL.PedidoDAL pedidosDAL = new DAL.PedidoDAL();
                pedidosDAL.AlterarPedidos(pedidos);
            }
            else
            {
                throw new Exception("Informe o codigo antes de alterar");
            }

        }

        public void ExcluirPedidos(Model.PedidoModel pedidos)
        {
            if (pedidos.Codigo >= 1)
            {
                DAL.PedidoDAL pedidosDAL = new DAL.PedidoDAL();
                pedidosDAL.ExcluirPedidos(pedidos);
            }
            else
            {
                throw new Exception("Informe o codigo antes de excluir");
            }
        }

        /*public DataTable getPedidosDT(string ordem, string bloqueado, string parametro)
        {
            DAL.CidadesDAL cidades = new DAL.CidadesDAL();
            return cidades.getCidadesDT(ordem, bloqueado, parametro);
        }*/
    }
}
