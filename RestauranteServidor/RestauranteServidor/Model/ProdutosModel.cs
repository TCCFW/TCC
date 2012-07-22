using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteServidor.Model
{
    public class ProdutosModel
    {
        public ProdutosModel(){}

        private string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        private int _fornecedor;

        public int Fornecedor
        {
            get { return _fornecedor; }
            set { _fornecedor = value; }
        }
        private int _cod_subgrupo;

        public int Cod_Subgrupo
        {
            get { return _cod_subgrupo; }
            set { _cod_subgrupo = value; }
        }
        private int _estoque;

        public int Estoque
        {
            get { return _estoque; }
            set { _estoque = value; }
        }
        private string _cod_barras;

        public string Cod_barras
        {
            get { return _cod_barras; }
            set { _cod_barras = value; }
        }

        private string _bloqueado;

        public string Bloqueado
        {
            get { return _bloqueado; }
            set { _bloqueado = value; }
        }
        private decimal _preco;

        public decimal Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }

        private string _razao;

        public string Razao
        {
            get { return _razao; }
            set { _razao = value; }
        }

        private string _desc_subgrupo;

        public string Desc_Subgrupo
        {
            get { return _desc_subgrupo; }
            set { _desc_subgrupo = value; }
        }
    }
}
