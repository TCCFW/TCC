using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RestauranteServidor.DAL
{
    public class SubGruposDAL
    {
        string Strconexao = @"Server = .\sqlexpress;Database=restaurante; Integrated Security = SSPI;";
        SqlConnection conn = null;

        public void salvarSubGrupos(Model.SubGrupoModel subgruposModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("insert into subgrupo(grupo, subgrupo, bloqueado)values(@grupo,@subgrupo,@bloqueado)", conn);

                cmd.Parameters.AddWithValue("@bloqueado", subgruposModel.Bloqueado);
                cmd.Parameters.AddWithValue("@grupo", subgruposModel.Grupo);
                cmd.Parameters.AddWithValue("@subgrupo", subgruposModel.Subgrupo);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar subgrupo" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        public void ExcluirSubGrupos(Model.SubGrupoModel subgrupos)
        {
            try
            {

                conn = new SqlConnection(Strconexao);
                SqlCommand comsql = new SqlCommand("delete from subgrupo where codigo=" + subgrupos.Codigo, conn);
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

        public void AlterarSubGrupos(Model.SubGrupoModel subgruposModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("update subgrupo set grupo=@grupo, subgrupo=@subgrupo, bloqueado=@bloqueado where codigo=@codigo", conn);
                cmd.Parameters.AddWithValue("@codigo", subgruposModel.Codigo);
                cmd.Parameters.AddWithValue("@grupo", subgruposModel.Grupo);
                cmd.Parameters.AddWithValue("@subgrupo", subgruposModel.Subgrupo);
                cmd.Parameters.AddWithValue("@bloqueado", subgruposModel.Bloqueado);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar subgrupo" + ex.Message);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public DataTable getSubGruposDT(string ordem, string bloqueado, string parametro)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = conn.CreateCommand();
            SqlDataAdapter da;
            if ((bloqueado == "S") || (bloqueado == "N"))
            {
                cmd.CommandText = "SELECT subgrupo.*,grupos.grupo from subgrupo join grupos on grupos.codigo = subgrupo.grupo where subgrupo.bloqueado='" + bloqueado + "' and subgrupo.subgrupo like '%"+parametro+"%' order by " + ordem;
            }
            else
            {
                cmd.CommandText = "SELECT subgrupo.*,grupos.grupo from subgrupo join grupos on grupos.codigo = subgrupo.grupo and subgrupo.subgrupo like '%" + parametro + "%' order by " + ordem;
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
        public Model.SubGrupoModel getSubGrupos()
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            SqlDataReader dr;
            string commandtext = "SELECT subgrupo.*,grupos.grupo from subgrupo join grupos on grupos.codigo = subgrupo.grupo";
            Model.SubGrupoModel subgrupos = new Model.SubGrupoModel();

            try
            {
                cmd = new SqlCommand(commandtext, conn);
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //
                while (dr.Read())
                {
                    subgrupos.Codigo = dr.GetInt32(0);
                    subgrupos.Grupo = dr.GetInt32(1);
                    subgrupos.Subgrupo = dr.GetString(2);
                    subgrupos.Bloqueado = dr.GetString(3);
                    subgrupos.Descricao_grupo = dr.GetString(4);

                }
                return subgrupos;
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

        public Model.SubGrupoModel getSubGruposPorCodigo(int codigo)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            SqlDataReader dr;
            string commandtext = "select subgrupo.*, grupos.grupo from subgrupo join grupos on grupos.codigo= subgrupo.grupo where subgrupo.codigo=" + codigo;
            Model.SubGrupoModel subgrupo = new Model.SubGrupoModel();

            try
            {
                cmd = new SqlCommand(commandtext, conn);
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //
                while (dr.Read())
                {
                    subgrupo.Codigo = dr.GetInt32(0);
                    subgrupo.Grupo = dr.GetInt32(1);
                    subgrupo.Subgrupo = dr.GetString(2);
                    subgrupo.Bloqueado = dr.GetString(3);
                    subgrupo.Descricao_grupo = dr.GetString(4);

                }
                return subgrupo;
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
