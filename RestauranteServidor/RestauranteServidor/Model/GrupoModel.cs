using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteServidor.Model
{
    public class GrupoModel
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _grupo;

        public string Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }

        public GrupoModel(int codigo, string grupo)
        {
            this._codigo = codigo;
            this._grupo = grupo;
        }

        public GrupoModel() { }

        private string bloqueado;

        public string Bloqueado
        {
            get { return bloqueado; }
            set { bloqueado = value; }
        }

    }
}
