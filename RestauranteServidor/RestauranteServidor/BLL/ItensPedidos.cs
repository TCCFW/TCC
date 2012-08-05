using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace RestauranteServidor.BLL
{
    public class ItensPedidos
    {

        public void IncluirItens(Model.ItemPedidoModel itens)
        {
            if (itens.Produto.Trim().Length == 0)
            {
                throw new Exception("A Descrição é obrigatória");
            }
            if (itens.Qtd == 0)
            {
                throw new ApplicationException("A quantidade é obrigatória");
            }
            DAL.ItemDAL cidadesDAL = new DAL.ItemDAL();
            cidadesDAL.salvarItens(itens);
        }

        public void AlterarItens(Model.ItemPedidoModel itens)
        {
            if (itens.Codigo != 0)
            {
                DAL.ItemDAL itensDAL = new DAL.ItemDAL();
                itensDAL.AlterarItens(itens);
            }
            else
            {
                throw new Exception("Informe o codigo antes de alterar");
            }

        }

        public void ExcluirItens(Model.ItemPedidoModel itens)
        {
            if (itens.Codigo != 0)
            {
                DAL.ItemDAL itensDAL = new DAL.ItemDAL();
                itensDAL.ExcluirItens(itens);
            }
            else
            {
                throw new Exception("Informe o codigo antes de excluir");
            }
        }

        public DataTable getItensDT()
        {
            DAL.ItemDAL itens = new DAL.ItemDAL();
            return itens.getItensDT();
        }
    }
}
