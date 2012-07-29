using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RestauranteServidor.DAL
{
    public class CidadesDAL
    {
        private string Strconexao = @"Server = .\sqlexpress;Database=restaurante; Integrated Security = SSPI;";
        SqlConnection conn = null;

        public void salvarCidades(Model.CidadeModel cidadeModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("insert into cidades(cidade, uf,bloqueado)values(@cidade,@uf,@bloqueado)", conn);

                cmd.Parameters.AddWithValue("@cidade", cidadeModel.Cidade);
                cmd.Parameters.AddWithValue("@uf", cidadeModel.UF);
                cmd.Parameters.AddWithValue("@bloqueado", cidadeModel.Bloqueado);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar cidade" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        public void ExcluirCidades(Model.CidadeModel cidades)
        {
            try
            {

                conn = new SqlConnection(Strconexao);
                SqlCommand comsql = new SqlCommand("delete from cidades where codigo=" + cidades.Codigo, conn);
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

        public void AlterarCidades(Model.CidadeModel cidadesModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("update cidades set cidade=@cidade, uf=@uf, bloqueado=@bloqueado where codigo=@codigo", conn);
                cmd.Parameters.AddWithValue("@codigo", cidadesModel.Codigo);
                cmd.Parameters.AddWithValue("@cidade", cidadesModel.Cidade);
                cmd.Parameters.AddWithValue("@uf", cidadesModel.UF);
                cmd.Parameters.AddWithValue("@bloqueado", cidadesModel.Bloqueado);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar cidade" + ex.Message);
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
        public DataTable getCidadesDT(string ordem, string bloqueado, string parametro)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = conn.CreateCommand();
            SqlDataAdapter da;
            if ((bloqueado == "S") || (bloqueado == "N"))
            {
                cmd.CommandText = "SELECT * from cidades where bloqueado='" + bloqueado + "' and cidade like '%" + parametro + "%' order by " + ordem;
            }
            else
            {
                cmd.CommandText = "SELECT * from cidades where cidade like '%" + parametro + "%' order by " + ordem;
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

        public DataSet dtRelCidades(Model.CidadeModel cidades)
        {
            try
            {
                conn = new SqlConnection(Strconexao);
                Relatorios.Cidades.dsCidades oDataset = new Relatorios.Cidades.dsCidades();
                string consulta = "SELECT codigo, cidade, uf FROM cidades";
                if (cidades.Codigo > 0)
                {
                    consulta = "SELECT codigo, cidade, uf FROM cidades where codigo=" + cidades.Codigo;

                    if (cidades.Bloqueado == "S")
                    {
                        consulta = "SELECT codigo, cidade, uf FROM cidades where codigo=" + cidades.Codigo + " and bloqueado='S'";
                    }
                    if (cidades.Bloqueado == "N")
                    {
                        consulta = "SELECT codigo, cidade, uf FROM cidades where codigo=" + cidades.Codigo + " and bloqueado='N'";
                    }
                    if (cidades.Bloqueado == "T")
                    {
                        consulta = "SELECT codigo, cidade, uf FROM cidades where codigo=" + cidades.Codigo;
                    }
                }

                if (cidades.Codigo == 0)
                {
                    consulta = "SELECT codigo, cidade, uf FROM cidades";

                    if (cidades.Bloqueado == "S")
                    {
                        consulta = "SELECT codigo, cidade, uf FROM cidades where bloqueado='S'";
                    }
                    if (cidades.Bloqueado == "N")
                    {
                        consulta = "SELECT codigo, cidade, uf FROM cidades where bloqueado='N'";
                    }
                    if (cidades.Bloqueado == "T")
                    {
                        consulta = "SELECT codigo, cidade, uf FROM cidades";
                    }
                }
                conn.Open();
                SqlDataAdapter Oda = new SqlDataAdapter(consulta, conn);
                Oda.Fill(oDataset, "cidades");
                return oDataset;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao gerar relatorio de cidades" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        public Model.CidadeModel getCidades(int codigo)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            SqlDataReader dr;
            string commandtext;

            if (codigo != 0)
            {
                commandtext = "select * from cidades where codigo=" + codigo;
            }
            else
            {
                commandtext = "select * from cidades";
            }
            Model.CidadeModel cidades = new Model.CidadeModel();

            try
            {
                cmd = new SqlCommand(commandtext, conn);
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //
                while (dr.Read())
                {
                    cidades.Codigo = dr.GetInt32(0);
                    cidades.Cidade = dr.GetString(1);
                    cidades.UF = dr.GetString(2);
                    cidades.Bloqueado = dr.GetString(3);

                }
                return cidades;
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
