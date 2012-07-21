using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestauranteServidor.Model
{
    public class SubGrupoModel
    {
        public SubGrupoModel(int codigo, string subgrupo, int grupo, string bloqueado, string descricao_grupo)
        {
            this._codigo = codigo;
            this._subgrupo = subgrupo;
            this._grupo = grupo;
            this._bloqueado = bloqueado;
            this._descricao_grupo = descricao_grupo;
        }

        public SubGrupoModel() { }

        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _subgrupo;

        public string Subgrupo
        {
            get { return _subgrupo; }
            set { _subgrupo = value; }
        }
        private int _grupo;

        public int Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }
        private string _bloqueado;

        public string Bloqueado
        {
            get { return _bloqueado; }
            set { _bloqueado = value; }
        }

        private string _descricao_grupo;

        public string Descricao_grupo
        {
            get { return _descricao_grupo; }
            set { _descricao_grupo = value; }
        }
    }
}
