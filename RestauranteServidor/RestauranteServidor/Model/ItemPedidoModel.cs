using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteServidor.Model
{
    public class ItemPedidoModel
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private int _pedido;

        public int Pedido
        {
            get { return _pedido; }
            set { _pedido = value; }
        }
        private string _produto;

        public string Produto
        {
            get { return _produto; }
            set { _produto = value; }
        }
        private decimal _valor;

        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        private int _qtd;

        public int Qtd
        {
            get { return _qtd; }
            set { _qtd = value; }
        }
        private DateTime _horaabertura;

        public DateTime HoraAbertura
        {
            get { return _horaabertura; }
            set { _horaabertura = value; }
        }

        private DateTime _horafechamento;

        public DateTime Horafechamento
        {
            get { return _horafechamento; }
            set { _horafechamento = value; }
        }

        private string _complemento;

        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }

        private string _desProduto;

        public string DesProduto
        {
            get { return _desProduto; }
            set { _desProduto = value; }
        }
    }
}
