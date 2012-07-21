using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RestauranteServidor.DAL
{
    public class GruposDAL
    {
        string Strconexao = @"Server = .\sqlexpress;Database=restaurante; Integrated Security = SSPI;";
        SqlConnection conn = null;

        public void salvarGrupos(Model.GrupoModel gruposModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("insert into grupos(grupo, bloqueado)values(@grupo,@bloqueado)", conn);

                cmd.Parameters.AddWithValue("@bloqueado", gruposModel.Bloqueado);
                cmd.Parameters.AddWithValue("@grupo", gruposModel.Grupo);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar grupo" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        public void ExcluirGrupos(Model.GrupoModel grupos)
        {
            try
            {

                conn = new SqlConnection(Strconexao);
                SqlCommand comsql = new SqlCommand("delete from grupos where codigo=" + grupos.Codigo, conn);
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

        public void AlterarGrupos(Model.GrupoModel gruposModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("update grupos set grupo=@grupo, bloqueado=@bloqueado where codigo=@codigo", conn);
                cmd.Parameters.AddWithValue("@codigo", gruposModel.Codigo);
                cmd.Parameters.AddWithValue("@grupo", gruposModel.Grupo);
                cmd.Parameters.AddWithValue("@bloqueado", gruposModel.Bloqueado);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar grupo" + ex.Message);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public DataTable getGruposDT(string ordem, string bloqueado, string parametro)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = conn.CreateCommand();
            SqlDataAdapter da;
            if ((bloqueado == "S") || (bloqueado == "N"))
            {
                cmd.CommandText = "SELECT * from grupos where bloqueado='" + bloqueado + "' and grupo like '%"+parametro+"%' order by " + ordem;
            }
            else
            {
                cmd.CommandText = "SELECT * from grupos where grupo like '%"+parametro+"%' order by " + ordem;
            }

            try
            {
                conn.Open();
                cmd = new SqlCommand(cmd.CommandText, conn);
                da = new SqlDataAdapter(cmd);
                //
                DataTable dtCidades = new DataTable();
                da.Fill(dtCidades);
                return dtCidades;
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

        //retorna objeto cidades para preenchimento dos campos
        /*public Model.GrupoModel getGrupos()
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            SqlDataReader dr;
            string commandtext = "select * from grupos";
            Model.GrupoModel grupos = new Model.GrupoModel();

            try
            {
                cmd = new SqlCommand(commandtext, conn);
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //
                while (dr.Read())
                {
                    grupos.Codigo = dr.GetInt32(0);
                    grupos.Bloqueado = dr.GetString(2);
                    grupos.Grupo = dr.GetString(1);

                }
                return grupos;
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
        }*/

        public Model.GrupoModel getGrupos(int codigo)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            SqlDataReader dr;
            string commandtext;
            if (codigo != 0)
            {
                commandtext = "select * from grupos where codigo=" + codigo;
            }
            else
            {
                commandtext = "select * from grupos";
            }
            Model.GrupoModel grupo = new Model.GrupoModel();

            try
            {
                cmd = new SqlCommand(commandtext, conn);
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //
                while (dr.Read())
                {
                    grupo.Codigo = dr.GetInt32(0);
                    grupo.Grupo = dr.GetString(1);
                    grupo.Bloqueado = dr.GetString(2);

                }
                return grupo;
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
