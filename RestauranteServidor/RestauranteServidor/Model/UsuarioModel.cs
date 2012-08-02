using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteServidor.Model
{
    public class UsuarioModel
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private Model.EnderecoModel endereco = new EnderecoModel();

        public Model.EnderecoModel Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        private string _telefone;

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }
        private string _celular;

        public string Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }
        private string _usuario;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _categoria;

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        private string _bloqueado;

        public string Bloqueado
        {
            get { return _bloqueado; }
            set { _bloqueado = value; }
        }

        private int? _comissao;

        public int? Comissao
        {
            get { return _comissao; }
            set { _comissao = value; }
        }
    }
}
