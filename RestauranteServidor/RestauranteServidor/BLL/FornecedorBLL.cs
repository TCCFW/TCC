using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RestauranteServidor.BLL
{
    public class FornecedorBLL
    {
        public void IncluirFornecedor(Model.FornecedorModel fornecedor)
        {
            if(fornecedor.Razao.Trim().Length==0){
                throw new Exception("A razão social é Obrigatória");
            }

            fornecedor.Email = fornecedor.Email.ToLower();
            DAL.FornecedorDAL fornecedorDal = new DAL.FornecedorDAL();

            //fornecedorDal.Incluir(fornecedor);
            fornecedorDal.salvarFornecedor(fornecedor);
        }

        public void Excluirfornecedor(Model.FornecedorModel fornecedor)
        {
            if (fornecedor.Codigo >= 1)
            {
                DAL.FornecedorDAL fornecedorDal = new DAL.FornecedorDAL();
                fornecedorDal.ExcluirFornecedores(fornecedor);
            }
            else
            {
                throw new Exception("Informe o codigo antes de excluir");
            }
        }

        public void AlterarFornecedor(Model.FornecedorModel fornecedor)
        {
            if (fornecedor.Codigo >=1)
            {
                DAL.FornecedorDAL fornecedorDAL = new DAL.FornecedorDAL();
                fornecedorDAL.AlterarFornecedor(fornecedor);
            }
            else
            {
                throw new Exception("Informe o codigo antes de alterar");
            }

        }

        public DataTable getFornecedores(String ordem, String bloqueado, string cidade, string parametro)
        {
            DAL.FornecedorDAL fornecedores = new DAL.FornecedorDAL();
            return fornecedores.getFornecedores(ordem, bloqueado,cidade,parametro);
        }

    }
}
