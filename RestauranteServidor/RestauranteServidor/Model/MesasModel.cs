using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteServidor.Model
{
    public class MesasModel
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        private string _mesa;

        public string Mesa
        {
            get { return _mesa; }
            set { _mesa = value; }
        }

        private string _bloqueado;

        public string Bloqueado
        {
            get { return _bloqueado; }
            set { _bloqueado = value; }
        }

    }
}
