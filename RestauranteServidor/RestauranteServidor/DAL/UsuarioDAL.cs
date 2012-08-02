using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RestauranteServidor.DAL
{
    public class UsuarioDAL
    {
        string Strconexao = @"Server = .\sqlexpress;Database=restaurante; Integrated Security = SSPI;";
        SqlConnection conn = null;

        public void salvarUsuarios(Model.UsuarioModel usuarioModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("insert into usuarios(nome, endereco, numero, bairro, cidade, telefone, celular, usuario, senha, cep, email, categoria, bloqueado, comissao)values(@nome, @endereco, @numero, @bairro, @cidade, @telefone, @celular, @usuario, @senha, @cep, @email, @categoria, @bloqueado,@comissao)", conn);

                cmd.Parameters.AddWithValue("@nome", usuarioModel.Nome);
                cmd.Parameters.AddWithValue("@endereco",usuarioModel.Endereco.Rua);
                cmd.Parameters.AddWithValue("@numero",usuarioModel.Endereco.Numero);
                cmd.Parameters.AddWithValue("@bairro",usuarioModel.Endereco.Bairro);
                cmd.Parameters.AddWithValue("@cidade",usuarioModel.Endereco.Cidade.Codigo);
                cmd.Parameters.AddWithValue("@telefone",usuarioModel.Telefone);
                cmd.Parameters.AddWithValue("@celular",usuarioModel.Celular);
                cmd.Parameters.AddWithValue("@usuario",usuarioModel.Usuario);
                cmd.Parameters.AddWithValue("@senha",usuarioModel.Senha);
                cmd.Parameters.AddWithValue("@cep",usuarioModel.Endereco.Cep);
                cmd.Parameters.AddWithValue("@email",usuarioModel.Email);
                cmd.Parameters.AddWithValue("@categoria", usuarioModel.Categoria);
                cmd.Parameters.AddWithValue("@bloqueado", usuarioModel.Bloqueado);
                cmd.Parameters.AddWithValue("@comissao",usuarioModel.Comissao);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar usuarios" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        public void ExcluirUsuarios(Model.UsuarioModel usuarios)
        {
            try
            {

                conn = new SqlConnection(Strconexao);
                SqlCommand comsql = new SqlCommand("delete from usuarios where codigo=" + usuarios.Codigo, conn);
                conn.Open();
                comsql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        public void AlterarUsuarios(Model.UsuarioModel usuarioModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("update usuarios set nome=@nome, endereco=@endereco, numero=@numero, bairro=@bairro, cidade=@cidade, telefone=@telefone, celular=@celular, usuario=@usuario, cep=@cep, email=@email, categoria=@categoria, bloqueado=@bloqueado, comissao=@comissao where codigo=@codigo", conn);
                cmd.Parameters.AddWithValue("@codigo", usuarioModel.Codigo);
                cmd.Parameters.AddWithValue("@nome", usuarioModel.Nome);
                cmd.Parameters.AddWithValue("@endereco", usuarioModel.Endereco.Rua);
                cmd.Parameters.AddWithValue("@numero", usuarioModel.Endereco.Numero);
                cmd.Parameters.AddWithValue("@bairro", usuarioModel.Endereco.Bairro);
                cmd.Parameters.AddWithValue("@cidade", usuarioModel.Endereco.Cidade.Codigo);
                cmd.Parameters.AddWithValue("@telefone", usuarioModel.Telefone);
                cmd.Parameters.AddWithValue("@celular", usuarioModel.Celular);
                cmd.Parameters.AddWithValue("@usuario", usuarioModel.Usuario);
                //cmd.Parameters.AddWithValue("@senha", usuarioModel.Senha);
                cmd.Parameters.AddWithValue("@cep", usuarioModel.Endereco.Cep);
                cmd.Parameters.AddWithValue("@email", usuarioModel.Email);
                cmd.Parameters.AddWithValue("@categoria", usuarioModel.Categoria);
                cmd.Parameters.AddWithValue("@bloqueado", usuarioModel.Bloqueado);
                cmd.Parameters.AddWithValue("@comissao",usuarioModel.Comissao);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar usuarios" + ex.Message);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        // retorna datatable para popular GridView
        public DataTable getUsuariosDT(string ordem, string bloqueado, string parametro)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = conn.CreateCommand();
            SqlDataAdapter da;
            if ((bloqueado == "S") || (bloqueado == "N"))
            {
                cmd.CommandText = "SELECT usuarios.*, cidades.cidade, cidades.uf from usuarios join cidades on cidades.codigo=usuarios.cidade where usuarios.bloqueado='" + bloqueado + "' and usuarios.nome like '%" + parametro + "%' order by " + ordem;
            }
            else
            {
                cmd.CommandText = "SELECT usuarios.*, cidades.cidade, cidades.uf from usuarios join cidades on cidades.codigo=usuarios.cidade where usuarios.nome like '%" + parametro + "%' order by " + ordem;
            }

            try
            {
                conn.Open();
                cmd = new SqlCommand(cmd.CommandText, conn);
                da = new SqlDataAdapter(cmd);
                //
                DataTable dtUsuarios = new DataTable();
                da.Fill(dtUsuarios);
                return dtUsuarios;
            }

            catch (SqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public Model.UsuarioModel getUsuarios(int codigo)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            SqlDataReader dr;
            string commandtext;

            if (codigo != 0)
            {
                commandtext = "select usuarios.*, cidades.cidade, cidades.uf from usuarios join cidades on cidades.codigo=usuarios.cidade where usuarios.codigo=" + codigo;
            }
            else
            {
                commandtext = "select usuarios.*, cidades.cidade, cidades.uf from usuarios join cidades on cidades.codigo=usuarios.cidade";
            }
            Model.UsuarioModel usuarios = new Model.UsuarioModel();

            try
            {
                cmd = new SqlCommand(commandtext, conn);
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //
                while (dr.Read())
                {
                    usuarios.Codigo = dr.GetInt32(0);
                    usuarios.Nome = dr.GetString(1);
                    usuarios.Endereco.Rua = dr.GetString(2);
                    usuarios.Endereco.Numero = dr.GetString(3);
                    usuarios.Endereco.Bairro = dr.GetString(4);
                    usuarios.Endereco.Cidade.Codigo = dr.GetInt32(5);
                    usuarios.Telefone = dr.GetString(6);
                    usuarios.Celular = dr.GetString(7);
                    usuarios.Usuario = dr.GetString(8);
                    usuarios.Senha = dr.GetString(9);
                    usuarios.Endereco.Cep = dr.GetString(10);
                    usuarios.Email = dr.GetString(11);
                    usuarios.Categoria = dr.GetString(12);
                    usuarios.Bloqueado = dr.GetString(13);
                    usuarios.Comissao = dr.GetInt32(14);
                    usuarios.Endereco.Cidade.Cidade = dr.GetString(15);
                    usuarios.Endereco.Cidade.UF = dr.GetString(16);
                }
                return usuarios;
            }

            catch (SqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
