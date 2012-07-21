using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteServidor.Model
{
    public class EnderecoModel
    {
        private string _numero;

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _rua;

        public string Rua
        {
            get { return _rua; }
            set { _rua = value; }
        }

        private string _bairro;

        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }

        private string _cep;

        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        CidadeModel cidade = new CidadeModel();

        public CidadeModel Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

    }
}
