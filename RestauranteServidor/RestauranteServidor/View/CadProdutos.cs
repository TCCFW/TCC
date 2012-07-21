using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestauranteServidor.View
{
    public partial class CadProdutos : Form
    {
        private bool Modificar = false;
        private bool Adicionar = true;
        private int Reg_Atual = 0;
        private int salvanovo = 0;

        private void LimparCampos()
        {
            txtcodbarras.Clear();
            rbnao.Checked = true;
            txtcodigofornecedor.Clear();
            txtfornecedores.Clear();
            txtcodProduto.Clear();
            txtcodsubgrupo.Clear();
            txtestoque.Clear();
            txtpreco.Clear();
            txtProduto.Clear();
            txtsubgrupo.Clear();
        }

        private void BloquearCampos()
        {
            txtcodbarras.Enabled = false; ;
            rbnao.Enabled = false;
            txtcodigofornecedor.Enabled = false; ;
            txtfornecedores.Enabled = false; ;
            txtcodProduto.Enabled = false; ;
            txtcodsubgrupo.Enabled = false; ;
            txtestoque.Enabled = false; ;
            txtpreco.Enabled = false; ;
            txtProduto.Enabled = false; ;
            txtsubgrupo.Enabled = false; ;
            rbsim.Enabled = false;
        }

        private void DesbloquearCampos()
        {
            txtcodbarras.Enabled = true; ;
            rbnao.Enabled = true;
            txtcodigofornecedor.Enabled = true;
            txtcodProduto.Enabled = true;
            txtcodsubgrupo.Enabled = true;
            txtestoque.Enabled = true;
            txtpreco.Enabled = true;
            txtProduto.Enabled = true;
            rbsim.Enabled = true;
        }

        public CadProdutos()
        {
            InitializeComponent();
        }

        public void RecebeUltimoProduto(int codigo)
        {
            DAL.ProdutosDAL produtos = new DAL.ProdutosDAL();
            txtcodProduto.Text = produtos.getProdutos(codigo).Codigo.ToString();
            txtProduto.Text = produtos.getProdutos(codigo).Descricao;
            txtcodigofornecedor.Text = produtos.getProdutos(codigo).Fornecedor.ToString();
            txtcodsubgrupo.Text = produtos.getProdutos(codigo).Cod_Subgrupo.ToString();
            txtestoque.Text = produtos.getProdutos(codigo).Estoque.ToString();
            txtcodbarras.Text = produtos.getProdutos(codigo).Cod_barras;
            txtpreco.Text = produtos.getProdutos(codigo).Preco.ToString();
            txtsubgrupo.Text = produtos.getProdutos(codigo).Desc_Subgrupo;
            txtfornecedores.Text = produtos.getProdutos(codigo).Razao;
            if (produtos.getProdutos(codigo).Bloqueado == "N")
            {
                rbnao.Checked = true;
                rbsim.Checked = false;
            }
            else
            {
                rbnao.Checked = false;
                rbsim.Checked = true;
            }
        }

        private void salvarProdutos()
        {
            BLL.ProdutosBLL produtosBLL = new BLL.ProdutosBLL();
            Model.ProdutosModel produtosModel = new Model.ProdutosModel();

            produtosModel.Cod_barras = txtcodbarras.Text;
            produtosModel.Cod_Subgrupo = Convert.ToInt32(txtcodsubgrupo.Text);
            produtosModel.Codigo = Convert.ToInt32(txtcodProduto.Text);
            produtosModel.Desc_Subgrupo = txtsubgrupo.Text;
            produtosModel.Descricao = txtProduto.Text;
            produtosModel.Estoque = Convert.ToInt32(txtestoque.Text);
            produtosModel.Fornecedor = Convert.ToInt32(txtcodigofornecedor.Text);
            produtosModel.Preco = Convert.ToDecimal(txtpreco.Text);
            produtosModel.Razao = txtfornecedores.Text;
            if ((rbnao.Checked == false) && (rbsim.Checked == true))
            {
                produtosModel.Bloqueado = "S";

            }
            if ((rbnao.Checked == true) && (rbsim.Checked == false))
            {
                produtosModel.Bloqueado = "N";
            }
                if (Modificar == false)
                {

                    produtosBLL.IncluirProdutos(produtosModel);
                }
                else
                {
                    produtosModel.Codigo = Convert.ToInt32(txtcodProduto.Text);
                    produtosBLL.AlterarProdutos(produtosModel);
                }

                MessageBox.Show("Dados Gravados com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void VisualizarProdutos()
        {
            txtcodProduto.Text = dtgconsultaprodutos.CurrentRow.Cells[0].Value.ToString();
            txtProduto.Text = dtgconsultaprodutos.CurrentRow.Cells[1].Value.ToString();
            txtcodigofornecedor.Text = dtgconsultaprodutos.CurrentRow.Cells[2].Value.ToString();
            txtestoque.Text = dtgconsultaprodutos.CurrentRow.Cells[3].Value.ToString();
            txtcodbarras.Text = dtgconsultaprodutos.CurrentRow.Cells[4].Value.ToString();
            txtpreco.Text = dtgconsultaprodutos.CurrentRow.Cells[6].Value.ToString();
            txtfornecedores.Text = dtgconsultaprodutos.CurrentRow.Cells[7].Value.ToString();
            txtcodsubgrupo.Text = dtgconsultaprodutos.CurrentRow.Cells[8].Value.ToString();
            txtsubgrupo.Text = dtgconsultaprodutos.CurrentRow.Cells[9].Value.ToString();
            if (dtgconsultaprodutos.CurrentRow.Cells[5].Value.ToString() == "S")
            {
                rbnao.Checked = false;
                rbsim.Checked = true;
            }
            else
            {
                rbnao.Checked = true;
                rbsim.Checked = false;
            }
            tbCidades.SelectedTab = tcCadastrar;
        }

        private void txtcodigofornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void CadProdutos_Load(object sender, EventArgs e)
        {
            BloquearCampos();
            tsadicionar.Enabled = true;
            tseditar.Enabled = true;
            tsexcluir.Enabled = true;
            tssair.Enabled = true;
            tssalvar.Enabled = false;
            tsCancelar.Enabled = false;
            txtProduto.Focus();
            RecebeUltimoProduto(Reg_Atual);
        }

        private void CadProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tssalvar.Enabled == true)
            {
                if (MessageBox.Show("Tem certeza que deseja sair?\nAs informações alteradas não serão salvas", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void dtgconsultaprodutos_DoubleClick(object sender, EventArgs e)
        {
            VisualizarProdutos();
            //Mudar de TabPage
            this.tbCidades.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultaprodutos.DataSource != null)
            {
                this.dtgconsultaprodutos.DataSource = null;
            }
            else
            {
                this.dtgconsultaprodutos.Rows.Clear();
            }
        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            VisualizarProdutos();
            //Mudar de TabPage
            this.tbCidades.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultaprodutos.DataSource != null)
            {
                this.dtgconsultaprodutos.DataSource = null;
            }
            else
            {
                this.dtgconsultaprodutos.Rows.Clear();
            }
        }

        private void CadProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtprodutosconsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    /*BLL.ProdutosBLL produtosBLL = new BLL.ProdutosBLL();
                    DAL.ProdutosDAL produtos = new DAL.ProdutosDAL();
                    if (rbcodconsulta.Checked == true)
                    {
                        if (rbconsultanao.Checked == true)
                        {
                            dtgconsultaprodutos.DataSource = produtosBLL.getProdutosDT("id", "N", txtprodutosconsulta.Text);
                        }
                        else
                        {
                            dtgconsultaprodutos.DataSource = produtosBLL.getProdutosDT("id", "S", txtprodutosconsulta.Text);
                        }
                        if (rbconsultatodos.Checked == true)
                        {
                            dtgconsultaprodutos.DataSource = produtosBLL.getProdutosDT("id", "T", txtprodutosconsulta.Text);
                        }
                    }
                    if (rbnomeconsulta.Checked == true)
                    {
                        if (rbconsultatodos.Checked == true)
                        {
                            dtgconsultaprodutos.DataSource = produtosBLL.getProdutosDT("descricao", "T", txtprodutosconsulta.Text);
                        }
                        if (rbconsultanao.Checked == true)
                        {
                            dtgconsultaprodutos.DataSource = produtosBLL.getProdutosDT("descricao", "N", txtprodutosconsulta.Text);
                        }
                        if (rbconsultasim.Checked == true)
                        {
                            dtgconsultaprodutos.DataSource = produtosBLL.getProdutosDT("descricao", "S", txtprodutosconsulta.Text);
                        }
                    }*/
                    CarregarGridView();
                    break;
            }
        }

        private void tsCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja cancelar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                BloquearCampos();
                tsadicionar.Enabled = true;
                tseditar.Enabled = true;
                tsexcluir.Enabled = true;
                tssair.Enabled = true;
                tssalvar.Enabled = false;
                tsCancelar.Enabled = false;
                if (txtcodProduto.Text != string.Empty)
                {
                    RecebeUltimoProduto(Reg_Atual);
                }
                salvanovo = 0;
            }
        }

        private void tseditar_Click(object sender, EventArgs e)
        {
            if (txtcodProduto.Text != string.Empty)
            {
                Reg_Atual = Convert.ToInt32(txtcodProduto.Text);
            }
            tsadicionar.Enabled = false;
            tseditar.Enabled = false;
            tsexcluir.Enabled = false;
            tssair.Enabled = false;
            tssalvar.Enabled = true;
            tsCancelar.Enabled = true;
            DesbloquearCampos();
            txtcodProduto.Enabled = false;
            Modificar = true;
        }

        private void tsadicionar_Click(object sender, EventArgs e)
        {
            Adicionar = false;
            salvanovo++;
            if (txtcodProduto.Text != string.Empty)
            {
                Reg_Atual = Convert.ToInt32(txtcodProduto.Text);
            }
            LimparCampos();
            tsadicionar.Enabled = false;
            tseditar.Enabled = false;
            tsexcluir.Enabled = false;
            tssair.Enabled = false;
            tssalvar.Enabled = true;
            tsCancelar.Enabled = true;
            tbCidades.SelectedTab = tcCadastrar;
            DesbloquearCampos();
        }

        private void tsexcluir_Click(object sender, EventArgs e)
        {
            BLL.ProdutosBLL produtosBLL = new BLL.ProdutosBLL();
            Model.ProdutosModel produtosModel = new Model.ProdutosModel();
            if (txtcodProduto.Text == String.Empty)
            {
                MessageBox.Show("Selecione o produto que deseja excluir", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                produtosModel.Codigo = Convert.ToInt32(txtcodProduto.Text);
                if (MessageBox.Show("Tem certeza que deseja excluir o produto?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    produtosBLL.ExcluirProdutos(produtosModel);
                    MessageBox.Show("Produto excluído com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                tsCancelar.Enabled = false;
                LimparCampos();
                RecebeUltimoProduto(Reg_Atual);
            }
        }

        private void tssalvar_Click(object sender, EventArgs e)
        {
            salvanovo++;
            BLL.ProdutosBLL produtos = new BLL.ProdutosBLL();
            salvarProdutos();
            tsadicionar.Enabled = true;
            tseditar.Enabled = true;
            tsexcluir.Enabled = true;
            tssair.Enabled = true;
            tssalvar.Enabled = false;
            tsCancelar.Enabled = false;
            Modificar = false;
            BloquearCampos();
            if (salvanovo == 2)
            {
                RecebeUltimoProduto(0);
            }
            else
            {
                RecebeUltimoProduto(Reg_Atual);
            }
            salvanovo = 0;
        }

        private void tssair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtcodigofornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadFornecedor fornecedor = new View.CadFornecedor();
                    fornecedor.ShowDialog();
                    txtcodigofornecedor.Text = fornecedor.txtcodigo.Text;
                    break;
            }
        }

        private void txtcodigofornecedor_Leave(object sender, EventArgs e)
        {
            DAL.FornecedorDAL fornecedor = new DAL.FornecedorDAL();
            if (txtcodigofornecedor.Text.Contains("'"))
            {
                txtcodigofornecedor.Text = txtcodigofornecedor.Text.Replace("'", "");
            }
            txtfornecedores.Text = fornecedor.getFornecedores(Convert.ToInt32(txtcodigofornecedor.Text)).Razao;
        }

        private void txtcodsubgrupo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadSubGrupo subgrupos = new View.CadSubGrupo();
                    subgrupos.ShowDialog();
                    txtcodigofornecedor.Text = subgrupos.txtcodigo.Text;
                    break;
            }
        }

        private void txtcodsubgrupo_Leave(object sender, EventArgs e)
        {
            DAL.SubGruposDAL subgrupos = new DAL.SubGruposDAL();
            if (txtcodsubgrupo.Text.Contains("'"))
            {
                txtcodsubgrupo.Text = txtcodsubgrupo.Text.Replace("'", "");
            }
            txtsubgrupo.Text = subgrupos.getSubGruposPorCodigo(Convert.ToInt32(txtcodsubgrupo.Text)).Subgrupo;
        }

        private void CarregarGridView()
        {

            Model.ProdutosModel produtoModel = new Model.ProdutosModel();
            DAL.ProdutosDAL produtoDAL = new DAL.ProdutosDAL();
            if (rbcodconsulta.Checked == true)
            {
                if ((rbconsultanao.Checked == true) && (rbconsultasim.Checked == false) && (rbconsultatodos.Checked == false))
                {
                    if ((chkFornecedor.Checked == true) && (txtconsultafornecedor.Text != string.Empty))
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("id", "N", txtcodfornecedorconsulta.Text, txtprodutosconsulta.Text);
                    }
                    else
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("id", "N", "", txtprodutosconsulta.Text);
                    }
                }
                if ((rbconsultanao.Checked == false) && (rbconsultasim.Checked == true) && (rbconsultatodos.Checked == false))
                {
                    if ((chkFornecedor.Checked == true) && (txtconsultafornecedor.Text != string.Empty))
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("id", "S", txtcodfornecedorconsulta.Text, txtprodutosconsulta.Text);
                    }
                    else
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("id", "S", "", txtprodutosconsulta.Text);
                    }
                }
                if ((rbconsultanao.Checked == false) && (rbconsultasim.Checked == false) && (rbconsultatodos.Checked == true))
                {
                    if ((chkFornecedor.Checked == true) && (txtconsultafornecedor.Text != string.Empty))
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("id", "T", txtcodfornecedorconsulta.Text, txtprodutosconsulta.Text);
                    }
                    else
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("id", "T", "", txtprodutosconsulta.Text);
                    }
                }
            }
            if (rbnomeconsulta.Checked == true)
            {
                if (rbconsultanao.Checked == true)
                {
                    if ((chkFornecedor.Checked == true) && (txtconsultafornecedor.Text != string.Empty))
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("descricao", "N", txtcodfornecedorconsulta.Text, txtprodutosconsulta.Text);
                    }
                    else
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("descricao", "N", "", txtprodutosconsulta.Text);
                    }
                }
                if (rbconsultasim.Checked == true)
                {
                    if ((chkFornecedor.Checked == true) && (txtconsultafornecedor.Text != string.Empty))
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("descricao", "S", txtcodfornecedorconsulta.Text, txtprodutosconsulta.Text);
                    }
                    else
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("descricao", "S", "", txtprodutosconsulta.Text);
                    }
                }
                if (rbconsultatodos.Checked == true)
                {
                    if ((chkFornecedor.Checked == true) && (txtconsultafornecedor.Text != string.Empty))
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("descricao", "T", txtcodfornecedorconsulta.Text, txtprodutosconsulta.Text);
                    }
                    else
                    {
                        dtgconsultaprodutos.DataSource = produtoDAL.getProdutosDT("descricao", "T", "", txtprodutosconsulta.Text);
                    }
                }
            }
            //dtgconsultafornecedor.Columns[0].Visible = false;
            dtgconsultaprodutos.Columns[1].Width = 300;
        }

        private void txtcodProduto_Leave(object sender, EventArgs e)
        {
            BLL.ProdutosBLL produtos = new BLL.ProdutosBLL();
            int valor = produtos.verificarProdRepetido(txtcodigofornecedor.Text, txtcodProduto.Text);

            if (valor == 1)
            {
                MessageBox.Show("O codigo informado já existe para outro produto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtcodfornecedorconsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadFornecedor fornecedor = new View.CadFornecedor();
                    fornecedor.ShowDialog();
                    txtcodigofornecedor.Text = fornecedor.txtcodigo.Text;
                    break;
            }
        }

        private void txtcodfornecedorconsulta_Leave(object sender, EventArgs e)
        {
            DAL.FornecedorDAL fornecedor = new DAL.FornecedorDAL();
            if (txtcodfornecedorconsulta.Text.Contains("'"))
            {
                txtcodfornecedorconsulta.Text = txtcodfornecedorconsulta.Text.Replace("'", "");
            }
            txtconsultafornecedor.Text = fornecedor.getFornecedores(Convert.ToInt32(txtcodfornecedorconsulta.Text)).Razao;
        }

        private void chkFornecedor_CheckStateChanged(object sender, EventArgs e)
        {
            CarregarGridView();
        }

        private void txtcodProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
