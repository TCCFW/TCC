using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RestauranteServidor.DAL
{
    public class ItemDAL
    {
        private string Strconexao = @"Server = .\sqlexpress;Database=restaurante; Integrated Security = SSPI;";
        SqlConnection conn = null;

        public void salvarItens(Model.ItemPedidoModel itemModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("insert into itempedido(status, pedido, produto, valor, quantidade, hora, complemento)values(@status, @pedido, @produto, @valor, @quantidade, @hora, @complemento)", conn);

                cmd.Parameters.AddWithValue("@status", itemModel.Status);
                cmd.Parameters.AddWithValue("@pedido",itemModel.Pedido);
                cmd.Parameters.AddWithValue("@produto", itemModel.Produto);
                cmd.Parameters.AddWithValue("@valor", itemModel.Valor);
                cmd.Parameters.AddWithValue("@quantidade", itemModel.Qtd);
                cmd.Parameters.AddWithValue("@hora", itemModel.HoraAbertura);
                cmd.Parameters.AddWithValue("@complemento", itemModel.Complemento);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar itens" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        public void ExcluirItens(Model.ItemPedidoModel itens)
        {
            try
            {

                conn = new SqlConnection(Strconexao);
                SqlCommand comsql = new SqlCommand("delete from itempedido where codigo=" + itens.Codigo, conn);
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

        public void AlterarItens(Model.ItemPedidoModel itensModel)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            try
            {
                if (itensModel.Horafechamento != null)
                {
                    cmd = new SqlCommand("update itempedido set status=@status, pedido=@pedido, produto=@produto, valor=@valor, quantidade=@quantidade, hora=@hora, complemento=@complemento,horafechamento=@horafechamento where codigo=@codigo", conn);
                    cmd.Parameters.AddWithValue("@codigo", itensModel.Codigo);
                    cmd.Parameters.AddWithValue("@status", itensModel.Status);
                    cmd.Parameters.AddWithValue("@pedido", itensModel.Pedido);
                    cmd.Parameters.AddWithValue("@produto", itensModel.Produto);
                    cmd.Parameters.AddWithValue("@valor", itensModel.Valor);
                    cmd.Parameters.AddWithValue("@quantidade", itensModel.Qtd);
                    cmd.Parameters.AddWithValue("@hora", itensModel.HoraAbertura);
                    cmd.Parameters.AddWithValue("@horafechamento", itensModel.Horafechamento);
                    cmd.Parameters.AddWithValue("@complemento", itensModel.Complemento);
                }
                else
                {
                    cmd = new SqlCommand("update itempedido set status=@status, pedido=@pedido, produto=@produto, valor=@valor, quantidade=@quantidade, hora=@hora, complemento=@complemento where codigo=@codigo", conn);
                    cmd.Parameters.AddWithValue("@codigo", itensModel.Codigo);
                    cmd.Parameters.AddWithValue("@status", itensModel.Status);
                    cmd.Parameters.AddWithValue("@pedido", itensModel.Pedido);
                    cmd.Parameters.AddWithValue("@produto", itensModel.Produto);
                    cmd.Parameters.AddWithValue("@valor", itensModel.Valor);
                    cmd.Parameters.AddWithValue("@quantidade", itensModel.Qtd);
                    cmd.Parameters.AddWithValue("@hora", itensModel.HoraAbertura);
                    cmd.Parameters.AddWithValue("@complemento", itensModel.Complemento);
                }
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar itens" + ex.Message);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        public Model.ItemPedidoModel getItens(int codigo)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            SqlDataReader dr;
            string commandtext;

            if (codigo != 0)
            {
                commandtext = "select itempedido.*, produtos.descricao from itempedido join produtos on produtos.id = itempedido.produto where itempedido.codigo=" + codigo;
            }
            else
            {
                commandtext = "select itempedido.*, produtos.descricao from itempedido join produtos on produtos.id = itempedido.produto";
            }
            Model.ItemPedidoModel itens = new Model.ItemPedidoModel();

            try
            {
                cmd = new SqlCommand(commandtext, conn);
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //
                while (dr.Read())
                {
                    itens.Codigo = dr.GetInt32(0);
                    itens.Status = dr.GetString(1);
                    itens.Pedido = dr.GetInt32(2);
                    itens.Produto = dr.GetString(3);
                    itens.Valor = dr.GetDecimal(4);
                    itens.Qtd = dr.GetInt32(5);
                    itens.HoraAbertura = dr.GetDateTime(6);
                    itens.Complemento = dr.GetString(7);
                    itens.DesProduto = dr.GetString(8);
                }
                return itens;
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
        //função usada para preenchimento do DataGridView
        public DataTable getItensDT()
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = conn.CreateCommand();
            SqlDataAdapter da;
            cmd.CommandText = "select itempedido.status, itempedido.produto, produtos.descricao, itempedido.complemento, itempedido.quantidade, itempedido.valor,itempedido.codigo, itempedido.hora, itempedido.horafechamento from itempedido join produtos on itempedido.produto = produtos.id";
            try
            {
                conn.Open();
                cmd = new SqlCommand(cmd.CommandText, conn);
                da = new SqlDataAdapter(cmd);
                //
                DataTable dtItens = new DataTable();
                da.Fill(dtItens);
                return dtItens;
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
