using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteServidor.Model
{
    public class FornecedorModel
    {
        public FornecedorModel()
        {

        }

        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _razao;

        public string Razao
        {
            get { return _razao; }
            set { _razao = value; }
        }


        private string _fantasia;

        public string Fantasia
        {
            get { return _fantasia; }
            set { _fantasia = value; }
        }
        private string _cnpj;

        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = value; }
        }
        private string _inscricao;

        public string Inscricao
        {
            get { return _inscricao; }
            set { _inscricao = value; }
        }


        private string _contato;

        public string Contato
        {
            get { return _contato; }
            set { _contato = value; }
        }
        private string _telefone;

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
        private string _fax;

        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        private string _celular;

        public string Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _observacao;

        public string Observacao
        {
            get { return _observacao; }
            set { _observacao = value; }
        }

        private string _bloqueado;

        public string Bloqueado
        {
            get { return _bloqueado; }
            set { _bloqueado = value; }
        }

        Model.EnderecoModel endereco = new Model.EnderecoModel();

        public EnderecoModel Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

    }
}
