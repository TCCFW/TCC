using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RestauranteServidor.DAL
{
    public class ProdutosDAL
    {

        string Strconexao = @"Server = .\sqlexpress;Database=restaurante; Integrated Security = SSPI;";
        SqlConnection conn = null;

        public void salvarProdutos(Model.ProdutosModel produtosModel)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            try
            {
                        cmd = new SqlCommand("insert into produtos(id, descricao,fornecedor,subgrupo,estoque,cod_barra,bloqueado,preco)values(@id, @descricao,@fornecedor,@subgrupo,@estoque,@cod_barra,@bloqueado,@preco)", conn);
                        cmd.Parameters.AddWithValue("@id", produtosModel.Codigo);
                        cmd.Parameters.AddWithValue("@descricao", produtosModel.Descricao);
                        cmd.Parameters.AddWithValue("@fornecedor", produtosModel.Fornecedor);
                        cmd.Parameters.AddWithValue("@subgrupo", produtosModel.Cod_Subgrupo);
                        cmd.Parameters.AddWithValue("@estoque", produtosModel.Estoque);
                        cmd.Parameters.AddWithValue("@cod_barra", produtosModel.Cod_barras);
                        cmd.Parameters.AddWithValue("@bloqueado", produtosModel.Bloqueado);
                        cmd.Parameters.AddWithValue("@preco", produtosModel.Preco);
                        conn.Open();
                        cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar produtos " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        public void ExcluirProdutos(Model.ProdutosModel produtos)
        {
            try
            {

                conn = new SqlConnection(Strconexao);
                SqlCommand comsql = new SqlCommand("delete from produtos where id=" + produtos.Codigo, conn);
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

        public void AlterarProdutos(Model.ProdutosModel produtosModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("update produtos set descricao=@descricao, fornecedor=@fornecedor, subgrupo=@subgrupo,estoque=@estoque,cod_barra=@cod_barra,bloqueado=@bloqueado,preco=@preco where id=@id", conn);
                cmd.Parameters.AddWithValue("@id", produtosModel.Codigo);
                cmd.Parameters.AddWithValue("@descricao", produtosModel.Descricao);
                cmd.Parameters.AddWithValue("@fornecedor", produtosModel.Fornecedor);
                cmd.Parameters.AddWithValue("@subgrupo", produtosModel.Cod_Subgrupo);
                cmd.Parameters.AddWithValue("@estoque", produtosModel.Estoque);
                cmd.Parameters.AddWithValue("@cod_barra", produtosModel.Cod_barras);
                cmd.Parameters.AddWithValue("@bloqueado", produtosModel.Bloqueado);
                cmd.Parameters.AddWithValue("@preco", produtosModel.Preco);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao alterar produtos" + ex.Message);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        public Model.ProdutosModel getProdutos(int codigo)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            SqlDataReader dr;
            string commandtext;

            if (codigo != 0)
            {
                commandtext = "select produtos.id, produtos.descricao, produtos.fornecedor, produtos.estoque, produtos.cod_barra, produtos.bloqueado, produtos.preco, fornecedor.razao, subgrupo.codigo, subgrupo.subgrupo from produtos join fornecedor on fornecedor.codigo = produtos.fornecedor join subgrupo on subgrupo.codigo = produtos.subgrupo where produtos.id=" + codigo;
            }
            else
            {
                commandtext = "select produtos.id, produtos.descricao, produtos.fornecedor, produtos.estoque, produtos.cod_barra, produtos.bloqueado, produtos.preco, fornecedor.razao, subgrupo.codigo, subgrupo.subgrupo from produtos join fornecedor on fornecedor.codigo = produtos.fornecedor join subgrupo on subgrupo.codigo = produtos.subgrupo";
            }
            Model.ProdutosModel produtos = new Model.ProdutosModel();

            try
            {
                cmd = new SqlCommand(commandtext, conn);
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    produtos.Codigo = dr.GetInt32(0);
                    produtos.Descricao = dr.GetString(1);
                    produtos.Fornecedor = dr.GetInt32(2);
                    produtos.Estoque = dr.GetInt32(3);
                    produtos.Cod_barras = dr.GetString(4);
                    produtos.Bloqueado = dr.GetString(5);
                    produtos.Preco = dr.GetDecimal(6);
                    produtos.Razao = dr.GetString(7);
                    produtos.Cod_Subgrupo = dr.GetInt32(8);
                    produtos.Desc_Subgrupo = dr.GetString(9);
                }
                return produtos;
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

        // retorna datatable para popular GridView
        public DataTable getProdutosDT(string ordem, string bloqueado, string parametro)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = conn.CreateCommand();
            SqlDataAdapter da;
            if ((bloqueado == "S") || (bloqueado == "N"))
            {
                cmd.CommandText = "select produtos.id, produtos.descricao, produtos.fornecedor, produtos.estoque, produtos.cod_barra, produtos.bloqueado, produtos.preco, fornecedor.razao, subgrupo.codigo, subgrupo.subgrupo from produtos join fornecedor on fornecedor.codigo = produtos.fornecedor join subgrupo on subgrupo.codigo = produtos.subgrupo where produtos.bloqueado='" + bloqueado + "' and descricao like '%" + parametro + "%' order by " + ordem;
            }
            else
            {
                cmd.CommandText = "select produtos.id, produtos.descricao, produtos.fornecedor, produtos.estoque, produtos.cod_barra, produtos.bloqueado, produtos.preco, fornecedor.razao, subgrupo.codigo, subgrupo.subgrupo from produtos join fornecedor on fornecedor.codigo = produtos.fornecedor join subgrupo on subgrupo.codigo = produtos.subgrupo where produtos.descricao like '%" + parametro + "%' order by " + ordem;
            }

            try
            {
                conn.Open();
                cmd = new SqlCommand(cmd.CommandText, conn);
                da = new SqlDataAdapter(cmd);
                //
                DataTable dtProdutos = new DataTable();
                da.Fill(dtProdutos);
                return dtProdutos;
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

        public DataTable getProdutosDT(String ordem, String bloqueado, string fornecedor, string parametro)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = conn.CreateCommand();
            SqlDataAdapter da;

            if (bloqueado == "T")
            {
                if (fornecedor != string.Empty)
                {
                    cmd.CommandText = "select produtos.id, produtos.descricao, produtos.fornecedor, produtos.estoque, produtos.cod_barra, produtos.bloqueado, produtos.preco, fornecedor.razao, subgrupo.codigo, subgrupo.subgrupo from produtos join fornecedor on fornecedor.codigo = produtos.fornecedor join subgrupo on subgrupo.codigo = produtos.subgrupo where fornecedor.codigo = '" + fornecedor + "' and produtos.descricao like '%" + parametro + "%' order by produtos." + ordem;
                }
                else
                {
                    cmd.CommandText = "select produtos.id, produtos.descricao, produtos.fornecedor, produtos.estoque, produtos.cod_barra, produtos.bloqueado, produtos.preco, fornecedor.razao, subgrupo.codigo, subgrupo.subgrupo from produtos join fornecedor on fornecedor.codigo = produtos.fornecedor join subgrupo on subgrupo.codigo = produtos.subgrupo and produtos.descricao like '%" + parametro + "%'  order by " + ordem;
                }
            }
            if (bloqueado == "S")
            {
                if (fornecedor != string.Empty)
                {
                    cmd.CommandText = "select produtos.id, produtos.descricao, produtos.fornecedor, produtos.estoque, produtos.cod_barra, produtos.bloqueado, produtos.preco, fornecedor.razao, subgrupo.codigo, subgrupo.subgrupo from produtos join fornecedor on fornecedor.codigo = produtos.fornecedor join subgrupo on subgrupo.codigo = produtos.subgrupo where fornecedor.codigo = '" + fornecedor + "' and produtos.bloqueado = '" + bloqueado + "' and produtos.descricao like '%" + parametro + "%'  order by produtos." + ordem;
                }
                else
                {
                    cmd.CommandText = "select produtos.id, produtos.descricao, produtos.fornecedor, produtos.estoque, produtos.cod_barra, produtos.bloqueado, produtos.preco, fornecedor.razao, subgrupo.codigo, subgrupo.subgrupo from produtos join fornecedor on fornecedor.codigo = produtos.fornecedor join subgrupo on subgrupo.codigo = produtos.subgrupo where produtos.bloqueado='" + bloqueado + "' and produtos.descricao like '%" + parametro + "%'  order by produtos." + ordem;
                }
            }
            if (bloqueado == "N")
            {
                if (fornecedor != string.Empty)
                {
                    cmd.CommandText = "select produtos.id, produtos.descricao, produtos.fornecedor, produtos.estoque, produtos.cod_barra, produtos.bloqueado, produtos.preco, fornecedor.razao, subgrupo.codigo, subgrupo.subgrupo from produtos join fornecedor on fornecedor.codigo = produtos.fornecedor join subgrupo on subgrupo.codigo = produtos.subgrupo where fornecedor.codigo = '" + fornecedor + "' and produtos.bloqueado = '" + bloqueado + "' and produtos.descricao like '%" + parametro + "%'  order by produtos." + ordem;
                }
                else
                {
                    cmd.CommandText = "select produtos.id, produtos.descricao, produtos.fornecedor, produtos.estoque, produtos.cod_barra, produtos.bloqueado, produtos.preco, fornecedor.razao, subgrupo.codigo, subgrupo.subgrupo from produtos join fornecedor on fornecedor.codigo = produtos.fornecedor join subgrupo on subgrupo.codigo = produtos.subgrupo where produtos.bloqueado='" + bloqueado + "' and produtos.descricao like '%" + parametro + "%'  order by produtos." + ordem;
                }
            }

            try
            {
                conn.Open();
                cmd = new SqlCommand(cmd.CommandText, conn);
                da = new SqlDataAdapter(cmd);
                //
                DataTable dtProdutos = new DataTable();
                da.Fill(dtProdutos);
                return dtProdutos;
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
