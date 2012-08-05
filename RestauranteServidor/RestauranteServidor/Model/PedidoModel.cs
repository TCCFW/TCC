using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteServidor.Model
{
    public class PedidoModel
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private int _mesa;

        public int Mesa
        {
            get { return _mesa; }
            set { _mesa = value; }
        }
        private int _garcom;

        public int Garcom
        {
            get { return _garcom; }
            set { _garcom = value; }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private DateTime _databertura;

        public DateTime Databertura
        {
            get { return _databertura; }
            set { _databertura = value; }
        }
        private DateTime _data_fechamento;

        public DateTime Data_fechamento
        {
            get { return _data_fechamento; }
            set { _data_fechamento = value; }
        }
        private decimal _valor;

        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        private decimal _vlrcomissao;

        public decimal Vlrcomissao
        {
            get { return _vlrcomissao; }
            set { _vlrcomissao = value; }
        }

        private string desmesa;

        public string Desmesa
        {
            get { return desmesa; }
            set { desmesa = value; }
        }
        private string desusuario;

        public string Desusuario
        {
            get { return desusuario; }
            set { desusuario = value; }
        }

    }
}
