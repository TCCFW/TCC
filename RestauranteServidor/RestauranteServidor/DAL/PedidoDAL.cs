using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RestauranteServidor.DAL
{
   public class PedidoDAL
    {
        private string Strconexao = @"Server = .\sqlexpress;Database=restaurante; Integrated Security = SSPI;";
        SqlConnection conn = null;

        public void salvarPedidos(Model.PedidoModel pedidoModel)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            try
            {
                if (pedidoModel.Status == "AB")
                {

                    cmd = new SqlCommand("insert into pedido(mesa, garcom,status,databertura,valor,vlrcomissao)values(@mesa, @garcom,@status,@databertura,@valor,@vlrcomissao)", conn);
                    cmd.Parameters.AddWithValue("@mesa", pedidoModel.Mesa);
                    cmd.Parameters.AddWithValue("@garcom", pedidoModel.Garcom);
                    cmd.Parameters.AddWithValue("@status", pedidoModel.Status);
                    cmd.Parameters.AddWithValue("@databertura", pedidoModel.Databertura);
                    cmd.Parameters.AddWithValue("@valor", pedidoModel.Valor);
                    cmd.Parameters.AddWithValue("@vlrcomissao", pedidoModel.Vlrcomissao);
                }
                else
                {
                    cmd = new SqlCommand("insert into pedido(mesa, garcom,status,databertura,datafechamento,valor,vlrcomissao)values(@mesa, @garcom,@status,@databertura,@datafechamento,@valor,@vlrcomissao)", conn);
                    cmd.Parameters.AddWithValue("@mesa", pedidoModel.Mesa);
                    cmd.Parameters.AddWithValue("@garcom", pedidoModel.Garcom);
                    cmd.Parameters.AddWithValue("@status", pedidoModel.Status);
                    cmd.Parameters.AddWithValue("@databertura", pedidoModel.Databertura);
                    cmd.Parameters.AddWithValue("@datafechamento", pedidoModel.Data_fechamento);
                    cmd.Parameters.AddWithValue("@valor", pedidoModel.Valor);
                    cmd.Parameters.AddWithValue("@vlrcomissao", pedidoModel.Vlrcomissao);
                }
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar pedido " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        public void ExcluirPedidos(Model.PedidoModel pedidos)
        {
            try
            {

                conn = new SqlConnection(Strconexao);
                SqlCommand comsql = new SqlCommand("delete from pedido where codigo=" + pedidos.Codigo, conn);
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

        public void AlterarPedidos(Model.PedidoModel pedidoModel)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            try
            {
                if (pedidoModel.Status == "AB")
                {
                    cmd = new SqlCommand("update pedido set mesa=@mesa, garcom=@garcom,status=@status,valor=@valor,vlrcomissao=@vlrcomissao where codigo=@codigo", conn);
                    cmd.Parameters.AddWithValue("@codigo", pedidoModel.Codigo);
                    cmd.Parameters.AddWithValue("@mesa", pedidoModel.Mesa);
                    cmd.Parameters.AddWithValue("@garcom", pedidoModel.Garcom);
                    cmd.Parameters.AddWithValue("@status", pedidoModel.Status);
                    //cmd.Parameters.AddWithValue("@databertura", pedidoModel.Databertura);
                    //cmd.Parameters.AddWithValue("@datafechamento", pedidoModel.Data_fechamento);
                    cmd.Parameters.AddWithValue("@valor", pedidoModel.Valor);
                    cmd.Parameters.AddWithValue("@vlrcomissao", pedidoModel.Vlrcomissao);
                }
                else
                {
                    cmd = new SqlCommand("update pedido set mesa=@mesa, garcom=@garcom,status=@status,valor=@valor,vlrcomissao=@vlrcomissao, datafechamento=@datafechamento where codigo=@codigo", conn);
                    cmd.Parameters.AddWithValue("@codigo", pedidoModel.Codigo);
                    cmd.Parameters.AddWithValue("@mesa", pedidoModel.Mesa);
                    cmd.Parameters.AddWithValue("@garcom", pedidoModel.Garcom);
                    cmd.Parameters.AddWithValue("@status", pedidoModel.Status);
                    cmd.Parameters.AddWithValue("@datafechamento", pedidoModel.Data_fechamento);
                    cmd.Parameters.AddWithValue("@valor", pedidoModel.Valor);
                    cmd.Parameters.AddWithValue("@vlrcomissao", pedidoModel.Vlrcomissao);
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar pedido " + ex.Message);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public Model.PedidoModel getPedidos(int codigo)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            SqlDataReader dr;
            string commandtext;

            if (codigo != 0)
            {
                commandtext = "select pedido.*, usuarios.usuario, mesas.mesa from pedido join mesas on pedido.mesa = mesas.codigo join usuarios on usuarios.codigo = pedido.garcom where pedido.codigo=" + codigo;
            }
            else
            {
                commandtext = "select pedido.*, usuarios.usuario, mesas.mesa from pedido join mesas on pedido.mesa = mesas.codigo join usuarios on usuarios.codigo = pedido.garcom";
            }
            Model.PedidoModel pedidos = new Model.PedidoModel();

            try
            {
                cmd = new SqlCommand(commandtext, conn);
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //
                while (dr.Read())
                {
                    pedidos.Codigo = dr.GetInt32(0);
                    pedidos.Mesa = dr.GetInt32(1);
                    pedidos.Garcom = dr.GetInt32(2);
                    pedidos.Status = dr.GetString(3);
                    pedidos.Databertura = dr.GetDateTime(4);
                    //pedidos.Data_fechamento = dr.GetDateTime(5);
                    pedidos.Valor = dr.GetDecimal(6);
                    pedidos.Vlrcomissao = dr.GetDecimal(7);
                    pedidos.Desusuario = dr.GetString(8);
                    pedidos.Desmesa = dr.GetString(9);
                }
                return pedidos;
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
