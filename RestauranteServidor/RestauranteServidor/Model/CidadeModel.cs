using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteServidor.Model
{
    public class CidadeModel
    {
        private int _codigo;

        public CidadeModel(string cidade, string uf, string bloqueado)
        {
            this._cidade = cidade;
            this._uf = uf;
            this._bloqueado = bloqueado;
        }

        public CidadeModel()
        {

        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _cidade;

        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }

        private string _uf;

        public string UF
        {
            get { return _uf; }
            set { _uf = value; }
        }

        private string _bloqueado;

        public string Bloqueado
        {
            get { return _bloqueado; }
            set { _bloqueado = value; }
        }

    }
}
