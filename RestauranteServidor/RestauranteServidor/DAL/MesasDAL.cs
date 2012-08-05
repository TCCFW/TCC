using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RestauranteServidor.DAL
{
    public class MesasDAL
    {
        string Strconexao = @"Server=.\sqlexpress;Database=restaurante; Integrated Security = SSPI;";
        SqlConnection conn = null;

        public void salvarMesas(Model.MesasModel mesasModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("insert into mesas(mesa,bloqueado)values(@mesa,@bloqueado)", conn);

                cmd.Parameters.AddWithValue("@mesa", mesasModel.Mesa);
                cmd.Parameters.AddWithValue("@bloqueado", mesasModel.Bloqueado);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar mesa" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }
        
        public void ExcluirMesas(Model.MesasModel mesa)
        {
            try
            {

                conn = new SqlConnection(Strconexao);
                SqlCommand comsql = new SqlCommand("delete from mesas where codigo=" + mesa.Codigo, conn);
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

        public void AlterarMesas(Model.MesasModel mesasModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("update mesas set mesa=@mesa, bloqueado=@bloqueado where codigo=@codigo", conn);
                cmd.Parameters.AddWithValue("@codigo", mesasModel.Codigo);
                cmd.Parameters.AddWithValue("@mesa", mesasModel.Mesa);
                cmd.Parameters.AddWithValue("@bloqueado", mesasModel.Bloqueado);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar mesa" + ex.Message);
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
        public DataTable getMesasDT(string ordem, string bloqueado, string parametro)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = conn.CreateCommand();
            SqlDataAdapter da;
            if ((bloqueado == "S") || (bloqueado == "N"))
            {
                cmd.CommandText = "SELECT * from mesas where bloqueado='" + bloqueado + "' and mesa like '%" + parametro + "%' order by " + ordem;
            }
            else
            {
                cmd.CommandText = "SELECT * from mesas where mesa like '%" + parametro + "%' order by " + ordem;
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

        public Model.MesasModel getMesas(int codigo)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            SqlDataReader dr;
            string commandtext;

            if (codigo != 0)
            {
                commandtext = "select * from mesas where codigo=" + codigo;
            }
            else
            {
                commandtext = "select * from mesas";
            }
            Model.MesasModel mesas = new Model.MesasModel();

            try
            {
                cmd = new SqlCommand(commandtext, conn);
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //
                while (dr.Read())
                {
                    mesas.Codigo = dr.GetInt32(0);
                    mesas.Mesa = dr.GetString(1);
                    mesas.Bloqueado = dr.GetString(2);

                }
                return mesas;
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
