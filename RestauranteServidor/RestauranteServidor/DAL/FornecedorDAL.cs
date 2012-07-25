using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RestauranteServidor.DAL
{
    public class FornecedorDAL
    {
        string Strconexao = @"Server = .\sqlexpress;Database=restaurante; Integrated Security = SSPI;";
        SqlConnection conn = null;
        /*
        public void Incluir(Model.FornecedorModel fornecedor)
        {

            try
            {
                conn.ConnectionString = Strconexao;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //NOME DA STOREPROCEDURE
                cmd.CommandText = "inserirfornecedor";

                //PARAMATROS DA STORE PROCEDURE
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter prazao = new SqlParameter("@razao", SqlDbType.VarChar, 100);
                prazao.Value = fornecedor.Razao;
                cmd.Parameters.Add(prazao);

                SqlParameter pfantasia = new SqlParameter("@fantasia", SqlDbType.VarChar, 100);
                pfantasia.Value = fornecedor.Fantasia;
                cmd.Parameters.Add(pfantasia);

                SqlParameter pinscricao = new SqlParameter("@inscricao", SqlDbType.VarChar, 20);
                pinscricao.Value = fornecedor.Inscricao;
                cmd.Parameters.Add(pinscricao);

                SqlParameter pendereco = new SqlParameter("@endereco", SqlDbType.VarChar, 80);
                pendereco.Value = fornecedor.Endereco;
                cmd.Parameters.Add(pendereco);

                SqlParameter pnumero = new SqlParameter("@numero", SqlDbType.VarChar, 7);
                pnumero.Value = fornecedor.Numero;
                cmd.Parameters.Add(pnumero);

                SqlParameter pbairro = new SqlParameter("@bairro", SqlDbType.VarChar, 60);
                pbairro.Value = fornecedor.Bairro;
                cmd.Parameters.Add(pbairro);

                SqlParameter pcontato = new SqlParameter("@contato", SqlDbType.VarChar, 50);
                pcontato.Value = fornecedor.Contato;
                cmd.Parameters.Add(pcontato);

                SqlParameter pcidade = new SqlParameter("@cidade", SqlDbType.Int, 4);
                pcidade.Value = fornecedor.CidadeCodigo;
                cmd.Parameters.Add(pcidade);

                SqlParameter pbloqueado = new SqlParameter("@bloqueado", SqlDbType.Char, 1);
                pbloqueado.Value = fornecedor.Bloqueado;
                cmd.Parameters.Add(pbloqueado);

                SqlParameter pfax = new SqlParameter("@fax", SqlDbType.VarChar, 15);
                pfax.Value = fornecedor.Fax;
                cmd.Parameters.Add(pfax);

                SqlParameter pcelular = new SqlParameter("@celular", SqlDbType.VarChar, 15);
                pcelular.Value = fornecedor.Celular;
                cmd.Parameters.Add(pcelular);

                SqlParameter pcep = new SqlParameter("@cep", SqlDbType.VarChar, 10);
                pcep.Value = fornecedor.Cep;
                cmd.Parameters.Add(pcep);

                SqlParameter pemail = new SqlParameter("@email", SqlDbType.VarChar, 70);
                pemail.Value = fornecedor.Email;
                cmd.Parameters.Add(pemail);

                SqlParameter pobservacao = new SqlParameter("@observavao", SqlDbType.VarChar, 300);
                pobservacao.Value = fornecedor.Observacao;
                cmd.Parameters.Add(pobservacao);

                conn.Open();
                cmd.ExecuteNonQuery();

                //fornecedor.Codigo = (Int32)cmd.Parameters["@codigo"].Value;
            }
            
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        */
        public void salvarFornecedor(Model.FornecedorModel fornecedorModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {  
                SqlCommand cmd = new SqlCommand("insert into fornecedor(razao, fantasia, inscricao, endereco, numero, bairro, contato, cidade, bloqueado, telefone,fax, celular, cep,email,observacao,cnpj)values(@razao, @fantasia, @inscricao, @endereco, @numero, @bairro, @contato, @cidade, @bloqueado, @telefone,@fax, @celular, @cep,@email,@observacao,@cnpj)", conn);

                cmd.Parameters.AddWithValue("@razao", fornecedorModel.Razao);
                cmd.Parameters.AddWithValue("@fantasia", fornecedorModel.Fantasia);
                cmd.Parameters.AddWithValue("@inscricao", fornecedorModel.Inscricao);
                cmd.Parameters.AddWithValue("@endereco", fornecedorModel.Endereco.Rua);
                cmd.Parameters.AddWithValue("@numero", fornecedorModel.Endereco.Numero);
                cmd.Parameters.AddWithValue("@bairro", fornecedorModel.Endereco.Bairro);
                cmd.Parameters.AddWithValue("@contato", fornecedorModel.Contato);
                cmd.Parameters.AddWithValue("@cidade", fornecedorModel.Endereco.Cidade.Codigo);
                cmd.Parameters.AddWithValue("@bloqueado", fornecedorModel.Bloqueado);
                cmd.Parameters.AddWithValue("@telefone", fornecedorModel.Telefone);
                cmd.Parameters.AddWithValue("@fax", fornecedorModel.Fax);
                cmd.Parameters.AddWithValue("@celular", fornecedorModel.Celular);
                cmd.Parameters.AddWithValue("@cep", fornecedorModel.Endereco.Cep);
                cmd.Parameters.AddWithValue("@email", fornecedorModel.Email);
                cmd.Parameters.AddWithValue("@observacao", fornecedorModel.Observacao);
                cmd.Parameters.AddWithValue("@cnpj", fornecedorModel.Cnpj);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar fornecedor" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }

        public void ExcluirFornecedores(Model.FornecedorModel fornecedor)
        {
            try
            {

                conn = new SqlConnection(Strconexao);
                SqlCommand comsql = new SqlCommand("delete from fornecedor where codigo=" + fornecedor.Codigo, conn);
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

        public void AlterarFornecedor(Model.FornecedorModel fornecedorModel)
        {
            conn = new SqlConnection(Strconexao);
            try
            {
                SqlCommand cmd = new SqlCommand("update fornecedor set razao=@razao, fantasia=@fantasia, inscricao=@inscricao, endereco=@endereco, numero=@numero, bairro=@bairro, contato=@contato, cidade=@cidade, bloqueado=@bloqueado, telefone=@telefone,fax=@fax, celular=@celular, cep=@cep,email=@email,observacao=@observacao, cnpj=@cnpj where codigo=@codigo",conn);
                cmd.Parameters.AddWithValue("@codigo",fornecedorModel.Codigo);
                cmd.Parameters.AddWithValue("@razao", fornecedorModel.Razao);
                cmd.Parameters.AddWithValue("@fantasia", fornecedorModel.Fantasia);
                cmd.Parameters.AddWithValue("@inscricao", fornecedorModel.Inscricao);
                cmd.Parameters.AddWithValue("@endereco", fornecedorModel.Endereco.Rua);
                cmd.Parameters.AddWithValue("@numero", fornecedorModel.Endereco.Numero);
                cmd.Parameters.AddWithValue("@bairro", fornecedorModel.Endereco.Bairro);
                cmd.Parameters.AddWithValue("@contato", fornecedorModel.Contato);
                cmd.Parameters.AddWithValue("@cidade", fornecedorModel.Endereco.Cidade.Codigo);
                cmd.Parameters.AddWithValue("@bloqueado", fornecedorModel.Bloqueado);
                cmd.Parameters.AddWithValue("@telefone", fornecedorModel.Telefone);
                cmd.Parameters.AddWithValue("@fax", fornecedorModel.Fax);
                cmd.Parameters.AddWithValue("@celular", fornecedorModel.Celular);
                cmd.Parameters.AddWithValue("@cep", fornecedorModel.Endereco.Cep);
                cmd.Parameters.AddWithValue("@email", fornecedorModel.Email);
                cmd.Parameters.AddWithValue("@observacao", fornecedorModel.Observacao);
                cmd.Parameters.AddWithValue("@cnpj",fornecedorModel.Cnpj);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            catch(Exception ex)
            {
                throw new Exception("Erro ao alterar fornecedor"+ex.Message);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }

        }

        public Model.FornecedorModel RecebeUltimoFornecedor()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Model.FornecedorModel fornecedor = new Model.FornecedorModel();
            try
            {
                conn = new SqlConnection(Strconexao);
                string commanText = "select * from fornecedor";
                cmd = new SqlCommand(commanText, conn);
                
                conn.Open();

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    fornecedor.Codigo = dr.GetInt32(0);
                    fornecedor.Razao = dr.GetString(1);
                    fornecedor.Fantasia = dr.GetString(2);
                    fornecedor.Inscricao = dr.GetString(3);
                    fornecedor.Endereco.Rua = dr.GetString(4);
                    fornecedor.Endereco.Numero = dr.GetString(5);
                    fornecedor.Endereco.Bairro = dr.GetString(6);
                    fornecedor.Contato = dr.GetString(7);
                    fornecedor.Endereco.Cidade.Codigo = dr.GetInt32(8);
                    if (dr.GetString(9) == "S")
                    {
                        fornecedor.Bloqueado = "S";
                    }
                    else
                    {
                        fornecedor.Bloqueado = "N";
                    }
                    fornecedor.Telefone = dr.GetString(10);
                    fornecedor.Fax = dr.GetString(11);
                    fornecedor.Celular = dr.GetString(12);
                    fornecedor.Endereco.Cep = dr.GetString(13);
                    fornecedor.Email = dr.GetString(14);
                    fornecedor.Observacao = dr.GetString(15);
                    fornecedor.Cnpj = dr.GetString(16);
                }
                return fornecedor;
            }
            catch(SqlException ex)
            {
                throw new Exception("Erro ao retornar ultimo registro. "+ex.Message);

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                dr.Close();
            }
        }

        public DataSet dtRelFornecedores(Model.FornecedorModel fornecedor)
        {
            try
            {
                conn = new SqlConnection(Strconexao);
                Relatorios.Cidades.dsCidades oDataset = new Relatorios.Cidades.dsCidades();
                string consulta = "SELECT fornecedor.codigo, fornecedor.razao, fornecedor.cnpj, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade = cidades.codigo";

                if (fornecedor.Codigo >0)
                {
                    consulta = "SELECT fornecedor.codigo, fornecedor.razao, fornecedor.cnpj, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade = cidades.codigo where fornecedor.codigo="+fornecedor.Codigo;

                    if (fornecedor.Bloqueado == "S")
                    {
                        consulta = "SELECT fornecedor.codigo, fornecedor.razao, fornecedor.cnpj, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade = cidades.codigo where fornecedor.codigo=" + fornecedor.Codigo + " and fornecedor.bloqueado='S'";
                    }
                    if (fornecedor.Bloqueado == "N")
                    {
                        consulta = "SELECT fornecedor.codigo, fornecedor.razao, fornecedor.cnpj, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade = cidades.codigo where fornecedor.codigo=" + fornecedor.Codigo + " and fornecedor.bloqueado='N'";
                    }
                    if (fornecedor.Bloqueado == "T")
                    {
                        consulta = "SELECT fornecedor.codigo, fornecedor.razao, fornecedor.cnpj, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade = cidades.codigo where fornecedor.codigo=" + fornecedor.Codigo;
                    }
                }

                if (fornecedor.Codigo == 0)
                {
                    consulta = "SELECT fornecedor.codigo, fornecedor.razao, fornecedor.cnpj, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade = cidades.codigo";

                    if (fornecedor.Bloqueado == "S")
                    {
                        consulta = "SELECT fornecedor.codigo, fornecedor.razao, fornecedor.cnpj, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade = cidades.codigo where fornecedor.bloqueado='S'";
                    }
                    if (fornecedor.Bloqueado == "N")
                    {
                        consulta = "SELECT fornecedor.codigo, fornecedor.razao, fornecedor.cnpj, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade = cidades.codigo where fornecedor.bloqueado='N'";
                    }
                    if (fornecedor.Bloqueado == "T")
                    {
                        consulta = "SELECT fornecedor.codigo, fornecedor.razao, fornecedor.cnpj, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade = cidades.codigo";
                    }
                }

                conn.Open();
                SqlDataAdapter Oda = new SqlDataAdapter(consulta, conn);
                Oda.Fill(oDataset, "fornecedores");
                return oDataset;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao gerar relatorio de fornecedores" + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        public DataTable getFornecedores(String ordem, String bloqueado, string cidade,string parametro)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = conn.CreateCommand();
            SqlDataAdapter da;

            if (bloqueado == "T")
            {
                if (cidade != string.Empty)
                {
                    cmd.CommandText = "SELECT fornecedor.*, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade=cidades.codigo where cidades.codigo = '" + cidade + "' and fornecedor.razao like '%"+parametro+"%' order by fornecedor." + ordem;
                }
                else
                {
                    cmd.CommandText = "SELECT fornecedor.*, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade=cidades.codigo and fornecedor.razao like '%" + parametro + "%'  order by " + ordem;
                }
            }
            if (bloqueado == "S")
            {
                if (cidade != string.Empty)
                {
                    cmd.CommandText = "SELECT fornecedor.*, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade=cidades.codigo where cidades.codigo = '" + cidade + "' and fornecedor.bloqueado = '" + bloqueado + "' and fornecedor.razao like '%" + parametro + "%'  order by fornecedor." + ordem;
                }
                else
                {
                    cmd.CommandText = "SELECT fornecedor.*, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade=cidades.codigo where fornecedor.bloqueado='" + bloqueado + "' and fornecedor.razao like '%" + parametro + "%'  order by fornecedor." + ordem;
                }
            }
            if (bloqueado == "N")
            {
                if (cidade != string.Empty)
                {
                    cmd.CommandText = "SELECT fornecedor.*, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade=cidades.codigo where cidades.codigo = '" + cidade + "' and fornecedor.bloqueado = '" + bloqueado + "' and fornecedor.razao like '%" + parametro + "%'  order by fornecedor." + ordem;
                }
                else
                {
                    cmd.CommandText = "SELECT fornecedor.*, cidades.cidade, cidades.uf from fornecedor join cidades on fornecedor.cidade=cidades.codigo where fornecedor.bloqueado='" + bloqueado + "' and fornecedor.razao like '%" + parametro + "%'  order by fornecedor." + ordem;
                }
            }

            try
            {
                conn.Open();
                cmd = new SqlCommand(cmd.CommandText, conn);
                da = new SqlDataAdapter(cmd);
                //
                DataTable dtFornecedor = new DataTable();
                da.Fill(dtFornecedor);
                return dtFornecedor;
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

        public Model.FornecedorModel getFornecedores(int codigo)
        {
            conn = new SqlConnection(Strconexao);
            SqlCommand cmd = null;
            SqlDataReader dr;
            string commandtext;
            if (codigo != 0)
            {
                commandtext = "select fornecedor.*, cidades.cidade, cidades.uf from fornecedor join cidades on cidades.codigo=fornecedor.cidade where fornecedor.codigo="+codigo;
            }
            else
            {
                commandtext = "select fornecedor.*, cidades.cidade, cidades.uf from fornecedor join cidades on cidades.codigo=fornecedor.cidade";
            }
            Model.FornecedorModel fornecedor = new Model.FornecedorModel();

            try
            {
                cmd = new SqlCommand(commandtext, conn);
                conn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //
                while (dr.Read())
                {
                    fornecedor.Codigo = dr.GetInt32(0);
                    fornecedor.Razao = dr.GetString(1);
                    fornecedor.Fantasia = dr.GetString(2);
                    fornecedor.Inscricao = dr.GetString(3);
                    fornecedor.Endereco.Rua = dr.GetString(4);
                    fornecedor.Endereco.Numero = dr.GetString(5);
                    fornecedor.Endereco.Bairro = dr.GetString(6);
                    fornecedor.Contato = dr.GetString(7);
                    fornecedor.Endereco.Cidade.Codigo = dr.GetInt32(8);
                    fornecedor.Bloqueado = dr.GetString(9);
                    fornecedor.Telefone = dr.GetString(10);
                    fornecedor.Fax = dr.GetString(11);
                    fornecedor.Celular = dr.GetString(12);
                    fornecedor.Endereco.Cep = dr.GetString(13);
                    fornecedor.Email = dr.GetString(14);
                    fornecedor.Observacao = dr.GetString(15);
                    fornecedor.Cnpj = dr.GetString(16);
                    fornecedor.Endereco.Cidade.Cidade = dr.GetString(17);
                    fornecedor.Endereco.Cidade.UF = dr.GetString(18);
                }
                return fornecedor;
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
