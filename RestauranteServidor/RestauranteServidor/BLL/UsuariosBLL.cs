using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RestauranteServidor.BLL
{
    public class UsuariosBLL
    {
        public void IncluirUsuarios(Model.UsuarioModel usuarios)
        {
            if (usuarios.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome é obrigatório");
            }
            if (usuarios.Usuario.Trim().Length == 0)
            {
                throw new ApplicationException("O usuário é obrigatório");
            }
            DAL.UsuarioDAL usuariosDAL = new DAL.UsuarioDAL();
            usuariosDAL.salvarUsuarios(usuarios);
        }

        public void AlterarUsuarios(Model.UsuarioModel usuarios)
        {
            if (usuarios.Codigo >= 1)
            {
                DAL.UsuarioDAL usuariosDAL = new DAL.UsuarioDAL();
                usuariosDAL.AlterarUsuarios(usuarios);
            }
            else
            {
                throw new Exception("Informe o codigo antes de alterar");
            }

        }

        public void ExcluirUsuarios(Model.UsuarioModel usuarios)
        {
            if (usuarios.Codigo >= 1)
            {
                DAL.UsuarioDAL usuariosDAL = new DAL.UsuarioDAL();
                usuariosDAL.ExcluirUsuarios(usuarios);
            }
            else
            {
                throw new Exception("Informe o codigo antes de excluir");
            }
        }

        public DataTable getCidadesDT(string ordem, string bloqueado, string parametro)
        {
            DAL.UsuarioDAL usuarios = new DAL.UsuarioDAL();
            return usuarios.getUsuariosDT(ordem, bloqueado, parametro);
        }

    }
}
