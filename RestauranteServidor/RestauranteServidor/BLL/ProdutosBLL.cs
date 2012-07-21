using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RestauranteServidor.BLL
{
    public class ProdutosBLL
    {
        public void IncluirProdutos(Model.ProdutosModel produtos)
        {
            if (produtos.Descricao.Trim().Length == 0)
            {
                throw new Exception("A descricao é obrigatória");
            }
            if (produtos.Codigo < 1)
            {
                throw new ApplicationException("O codigo é obrigatório");
            }
            if (produtos.Fornecedor < 1)
            {
                throw new ApplicationException("O fornecedor é obrigatório");
            }
            if (produtos.Cod_Subgrupo < 1)
            {
                throw new ApplicationException("O subgrupo é obrigatório");
            }
            if (produtos.Estoque < 0)
            {
                throw new ApplicationException("O estoque não pode ser negativo");
            }

            DAL.ProdutosDAL produtosDAL = new DAL.ProdutosDAL();

            produtosDAL.salvarProdutos(produtos);

        }

        public void AlterarProdutos(Model.ProdutosModel produtos)
        {
            DAL.ProdutosDAL produtosDAL = new DAL.ProdutosDAL();
            if (produtos.Codigo >= 1)
            {
                produtosDAL.AlterarProdutos(produtos);
            }
            else
            {
                throw new Exception("Informe o codigo antes de alterar");
            }

        }

        public void ExcluirProdutos(Model.ProdutosModel produtos)
        {
            if (produtos.Codigo >= 1)
            {
                DAL.ProdutosDAL produtosDAL = new DAL.ProdutosDAL();
                produtosDAL.ExcluirProdutos(produtos);
            }
            else
            {
                throw new Exception("Informe o codigo antes de excluir");
            }
        }

        public DataTable getProdutosDT(String ordem, String bloqueado, string fornecedor, string parametro)
        {
            DAL.ProdutosDAL produtos = new DAL.ProdutosDAL();
            return produtos.getProdutosDT(ordem, bloqueado, fornecedor, parametro);
        }

        public DataTable getProdutosDT(string ordem, string bloqueado, string parametro)
        {
            DAL.ProdutosDAL produtos = new DAL.ProdutosDAL();
            return produtos.getProdutosDT(ordem, bloqueado, parametro);
        }

        public int verificarProdRepetido(string fornecedor, string produto)
        {
            DAL.ProdutosDAL produtosDAL = new DAL.ProdutosDAL();
            if ((fornecedor == produtosDAL.getProdutos(0).Fornecedor.ToString()) && (produto == produtosDAL.getProdutos(0).Codigo.ToString()))
            {
                //throw new Exception("Já existe outro produto cadastrado com o mesmo codigo");
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
