using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestauranteServidor.View
{
    public partial class CadFornecedor : Form
    {
        private bool Modificar = false;
        private bool Adicionar = true;
        private int Reg_Atual = 0;
        private int salvanovo = 0;

        public CadFornecedor()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            mskcelular.Clear();
            mskcep.Clear();
            mskcnpj.Clear();
            mskfax.Clear();
            mskinscricao.Clear();
            msktelefone.Clear();
            mskuf.Clear();
            mskufconsulta.Clear();
            txtbairro.Clear();
            txtcidade.Clear();
            txtcodigo.Clear();
            txtcontato.Clear();
            txtemail.Clear();
            txtendereco.Clear();
            txtfantasia.Clear();
            txtnumero.Clear();
            txtobservacao.Clear();
            txtrazao.Clear();
            rbnao.Checked = true;
            txtcodigocidade.Clear();
        }

        private void BloquearCampos()
        {
            mskcelular.Enabled = false;
            mskcep.Enabled = false;
            mskcnpj.Enabled = false;
            mskfax.Enabled = false;
            mskinscricao.Enabled = false;
            msktelefone.Enabled = false;
            mskuf.Enabled = false;
            mskufconsulta.Enabled = false;
            txtbairro.Enabled = false;
            txtcidade.Enabled = false;
            txtcodigocidade.Enabled = false;
            txtcodigo.Enabled = false;
            txtcontato.Enabled = false;
            txtemail.Enabled = false;
            txtendereco.Enabled = false;
            txtfantasia.Enabled = false;
            txtnumero.Enabled = false;
            txtobservacao.Enabled = false;
            txtrazao.Enabled = false;
            rbnao.Enabled = false;
            rbsim.Enabled = false;
        }

        private void DesbloquearCampos()
        {

            mskcelular.Enabled = true;
            mskcep.Enabled = true;
            mskcnpj.Enabled = true;
            mskfax.Enabled = true;
            mskinscricao.Enabled = true;
            msktelefone.Enabled = true;
            mskufconsulta.Enabled = true;
            txtbairro.Enabled = true;
            txtcodigocidade.Enabled = true;
            txtcontato.Enabled = true;
            txtemail.Enabled = true;
            txtendereco.Enabled = true;
            txtfantasia.Enabled = true;
            txtnumero.Enabled = true;
            txtobservacao.Enabled = true;
            txtrazao.Enabled = true;
            rbnao.Enabled = true;
            rbsim.Enabled = true;
        }

        private void CadFornecedor_Load(object sender, EventArgs e)
        {
            BloquearCampos();
            tsadicionar.Enabled = true;
            tseditar.Enabled = true;
            tsexcluir.Enabled = true;
            tssair.Enabled = true;
            tssalvar.Enabled = false;
            tsCancelar.Enabled = false;
            mskcnpj.Focus();
            RecebeUltimoFornecedor(Reg_Atual);

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tssalvar_Click(object sender, EventArgs e)
        {
            if ((txtcidade.Text != string.Empty) && (mskuf.Text != string.Empty))
            {
                salvanovo++;
                salvarFornecedor();
                tsadicionar.Enabled = true;
                tseditar.Enabled = true;
                tsexcluir.Enabled = true;
                tssair.Enabled = true;
                tssalvar.Enabled = false;
                tsCancelar.Enabled = false;
                Modificar = false;
                if (salvanovo == 2)
                {
                    RecebeUltimoFornecedor(0);
                }
                else
                {
                    RecebeUltimoFornecedor(Reg_Atual);
                }
                BloquearCampos();
                salvanovo = 0;
            }
            else
            {
                MessageBox.Show("Informe uma cidade válida antes de salvar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void salvarFornecedor()
        {
            BLL.FornecedorBLL fornecedorBLL = new BLL.FornecedorBLL();
            Model.FornecedorModel fornecedorModel = new Model.FornecedorModel();
            DAL.CidadesDAL cidadesDAL = new DAL.CidadesDAL();

            

                fornecedorModel.Endereco.Bairro = txtbairro.Text;
                if ((rbnao.Checked == false) && (rbsim.Checked == true))
                {
                    fornecedorModel.Bloqueado = "S";

                }
                if ((rbnao.Checked == true) && (rbsim.Checked == false))
                {
                    fornecedorModel.Bloqueado = "N";
                }

                fornecedorModel.Celular = mskcelular.Text;
                fornecedorModel.Endereco.Cep = mskcep.Text;
                if (txtcodigocidade.Text != string.Empty)
                {
                    fornecedorModel.Endereco.Cidade.Codigo = Convert.ToInt32(txtcodigocidade.Text);
                }

                fornecedorModel.Cnpj = mskcnpj.Text;
                fornecedorModel.Contato = txtcontato.Text;
                fornecedorModel.Email = txtemail.Text;
                fornecedorModel.Endereco.Rua = txtendereco.Text;
                fornecedorModel.Fantasia = txtfantasia.Text;
                fornecedorModel.Fax = mskfax.Text;
                fornecedorModel.Inscricao = mskinscricao.Text;
                fornecedorModel.Endereco.Numero = txtnumero.Text;
                fornecedorModel.Observacao = txtobservacao.Text;
                fornecedorModel.Razao = txtrazao.Text;
                fornecedorModel.Telefone = msktelefone.Text;

                if (Modificar == false)
                {
                    fornecedorBLL.IncluirFornecedor(fornecedorModel);
                }
                else
                {
                    fornecedorModel.Codigo = Convert.ToInt32(txtcodigo.Text);
                    fornecedorBLL.AlterarFornecedor(fornecedorModel);
                }
                MessageBox.Show("Dados Gravados com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsexcluir_Click(object sender, EventArgs e)
        {
            BLL.FornecedorBLL fornecedorBLL = new BLL.FornecedorBLL();
            Model.FornecedorModel fornecedorModel = new Model.FornecedorModel();
            if (txtcodigo.Text == String.Empty)
            {
                MessageBox.Show("selecione o fornecedor que deseja excluir", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                fornecedorModel.Codigo = Convert.ToInt32(txtcodigo.Text);
                if (MessageBox.Show("Tem certeza que deseja excluir o fornecedor codigo " + txtcodigo.Text + "?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    fornecedorBLL.Excluirfornecedor(fornecedorModel);
                    MessageBox.Show("Fornecedor excluído com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                tsCancelar.Enabled = false;
                LimparCampos();
                RecebeUltimoFornecedor(Reg_Atual);
            }
        }

        private void tsadicionar_Click(object sender, EventArgs e)
        {
            Adicionar = false;
            salvanovo++;
            if (txtcodigo.Text != string.Empty)
            {
                Reg_Atual = Convert.ToInt32(txtcodigo.Text);
            }
            LimparCampos();
            tsadicionar.Enabled = false;
            tseditar.Enabled = false;
            tsexcluir.Enabled = false;
            tssair.Enabled = false;
            tssalvar.Enabled = true;
            tsCancelar.Enabled = true;
            tbFornecedor.SelectedTab = tcCadastrar;
            DesbloquearCampos();
        }


        private void tseditar_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != string.Empty)
            {
                Reg_Atual = Convert.ToInt32(txtcodigo.Text);
            }
            tsadicionar.Enabled = false;
            tseditar.Enabled = false;
            tsexcluir.Enabled = false;
            tssair.Enabled = false;
            tssalvar.Enabled = true;
            tsCancelar.Enabled = true;
            DesbloquearCampos();
            Modificar = true;
            tbFornecedor.SelectedTab = tcCadastrar;
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
                if (txtcodigo.Text != string.Empty)
                {
                    RecebeUltimoFornecedor(Reg_Atual);
                }
                salvanovo = 0;
            }
        }

        private void txtnomeconsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    CarregarGridView();
                    break;
            }
        }

        private void CarregarGridView()
        {

            Model.FornecedorModel fornecedorModel = new Model.FornecedorModel();
            BLL.FornecedorBLL fornecedorBLL = new BLL.FornecedorBLL();
            if (rbcodconsulta.Checked == true)
            {
                if ((rbconsultanao.Checked == true)&&(rbconsultasim.Checked == false)&&(rbconsultatodos.Checked==false))
                {
                    if ((chkboxcidadeconsulta.Checked == true) && (txtcidadeconsulta.Text != string.Empty))
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("codigo", "N", txtcodcidadeconsulta.Text, txtnomeconsulta.Text);
                    }
                    else
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("codigo", "N", "", txtnomeconsulta.Text);
                    }
                }
                if ((rbconsultanao.Checked == false) && (rbconsultasim.Checked == true) && (rbconsultatodos.Checked == false))
                {
                    if ((chkboxcidadeconsulta.Checked == true) && (txtcidadeconsulta.Text != string.Empty))
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("codigo", "S", txtcodcidadeconsulta.Text, txtnomeconsulta.Text);
                    }
                    else
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("codigo", "S", "", txtnomeconsulta.Text);
                    }
                }
                if ((rbconsultanao.Checked == false) && (rbconsultasim.Checked == false) && (rbconsultatodos.Checked == true))
                {
                    if ((chkboxcidadeconsulta.Checked == true) && (txtcidadeconsulta.Text != string.Empty))
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("codigo", "T", txtcodcidadeconsulta.Text, txtnomeconsulta.Text);
                    }
                    else
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("codigo", "T", "", txtnomeconsulta.Text);
                    }
                }
            }
            if (rbnomeconsulta.Checked == true)
            {
                if (rbconsultanao.Checked == true)
                {
                    if ((chkboxcidadeconsulta.Checked == true) && (txtcidadeconsulta.Text != string.Empty))
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("razao", "N", txtcodcidadeconsulta.Text, txtnomeconsulta.Text);
                    }
                    else
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("razao", "N", "", txtnomeconsulta.Text);
                    }
                }
                if (rbconsultasim.Checked == true)
                {
                    if ((chkboxcidadeconsulta.Checked == true) && (txtcidadeconsulta.Text != string.Empty))
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("razao", "S", txtcodcidadeconsulta.Text, txtnomeconsulta.Text);
                    }
                    else
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("razao", "S", "", txtnomeconsulta.Text);
                    }
                }
                if (rbconsultatodos.Checked == true)
                {
                    if ((chkboxcidadeconsulta.Checked == true) && (txtcidadeconsulta.Text != string.Empty))
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("razao", "T", txtcodcidadeconsulta.Text, txtnomeconsulta.Text);
                    }
                    else
                    {
                        dtgconsultafornecedor.DataSource = fornecedorBLL.getFornecedores("razao", "T", "", txtnomeconsulta.Text);
                    }
                }
            }
            //dtgconsultafornecedor.Columns[0].Visible = false;
            dtgconsultafornecedor.Columns[1].Width = 300;
        }

        private void txtcodigocidade_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadCidades cidades = new View.CadCidades();
                    cidades.ShowDialog();
                    txtcodigocidade.Text = cidades.txtcodigocidade.Text;
                    break;

            }
        }

        private void CadFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                 Close();
            }
        }

        public void RecebeUltimoFornecedor(int codigo)
        {
            DAL.FornecedorDAL fornecedor = new DAL.FornecedorDAL();
            txtcodigocidade.Text = fornecedor.getFornecedores(codigo).Endereco.Cidade.Codigo.ToString();
            txtbairro.Text = fornecedor.getFornecedores(codigo).Endereco.Bairro;
            txtcidade.Text = fornecedor.getFornecedores(codigo).Endereco.Cidade.Cidade;
            mskuf.Text = fornecedor.getFornecedores(codigo).Endereco.Cidade.UF;
            txtcodigo.Text = fornecedor.getFornecedores(codigo).Codigo.ToString();
            txtcontato.Text = fornecedor.getFornecedores(codigo).Contato;
            txtemail.Text = fornecedor.getFornecedores(codigo).Email;
            txtendereco.Text = fornecedor.getFornecedores(codigo).Endereco.Rua;
            txtfantasia.Text = fornecedor.getFornecedores(codigo).Fantasia;
            txtnumero.Text = fornecedor.getFornecedores(codigo).Endereco.Numero;
            txtobservacao.Text = fornecedor.getFornecedores(codigo).Observacao;
            txtrazao.Text = fornecedor.getFornecedores(codigo).Razao;
            mskcelular.Text = fornecedor.getFornecedores(codigo).Celular;
            mskcep.Text = fornecedor.getFornecedores(codigo).Endereco.Cep;
            mskcnpj.Text = fornecedor.getFornecedores(codigo).Cnpj;
            mskfax.Text = fornecedor.getFornecedores(codigo).Fax;
            mskinscricao.Text = fornecedor.getFornecedores(codigo).Inscricao;
            msktelefone.Text = fornecedor.getFornecedores(codigo).Telefone;

            if (fornecedor.getFornecedores(codigo).Bloqueado == "N")
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
            

        private void txtcodigocidade_Leave(object sender, EventArgs e)
        {
            DAL.CidadesDAL cidades = new DAL.CidadesDAL();
            if (txtcodigocidade.Text.Contains("'"))
            {
                txtcodigocidade.Text = txtcodigocidade.Text.Replace("'", "");
            }
            txtcidade.Text = cidades.getCidades(Convert.ToInt32(txtcodigocidade.Text)).Cidade;
            mskuf.Text = cidades.getCidades(Convert.ToInt32(txtcodigocidade.Text)).UF;
        }

        private void CadFornecedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tssalvar.Enabled == true)
            {
                if (MessageBox.Show("Tem certeza que deseja sair?\nAs informações alteradas não serão salvas", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void VisualizarFornecedores()
        {
            txtcodigo.Text = dtgconsultafornecedor.CurrentRow.Cells[0].Value.ToString();
            txtrazao.Text = dtgconsultafornecedor.CurrentRow.Cells[1].Value.ToString();
            txtfantasia.Text = dtgconsultafornecedor.CurrentRow.Cells[2].Value.ToString();
            mskinscricao.Text = dtgconsultafornecedor.CurrentRow.Cells[3].Value.ToString();
            txtendereco.Text = dtgconsultafornecedor.CurrentRow.Cells[4].Value.ToString();
            txtnumero.Text = dtgconsultafornecedor.CurrentRow.Cells[5].Value.ToString();
            txtbairro.Text = dtgconsultafornecedor.CurrentRow.Cells[6].Value.ToString();
            txtcontato.Text = dtgconsultafornecedor.CurrentRow.Cells[7].Value.ToString();
            txtcodigocidade.Text = dtgconsultafornecedor.CurrentRow.Cells[8].Value.ToString();
            if (dtgconsultafornecedor.CurrentRow.Cells[9].Value.ToString() == "S")
            {
                rbnao.Checked = false;
                rbsim.Checked = true;
            }
            else
            {
                rbnao.Checked = true;
                rbsim.Checked = false;
            }
            msktelefone.Text = dtgconsultafornecedor.CurrentRow.Cells[10].Value.ToString();
            mskfax.Text = dtgconsultafornecedor.CurrentRow.Cells[11].Value.ToString();
            mskcelular.Text = dtgconsultafornecedor.CurrentRow.Cells[12].Value.ToString();
            mskcep.Text = dtgconsultafornecedor.CurrentRow.Cells[13].Value.ToString();
            txtemail.Text = dtgconsultafornecedor.CurrentRow.Cells[14].Value.ToString();
            txtobservacao.Text = dtgconsultafornecedor.CurrentRow.Cells[15].Value.ToString();
            mskcnpj.Text = dtgconsultafornecedor.CurrentRow.Cells[16].Value.ToString();
            txtcidade.Text = dtgconsultafornecedor.CurrentRow.Cells[17].Value.ToString();
            mskuf.Text = dtgconsultafornecedor.CurrentRow.Cells[18].Value.ToString();
            tbFornecedor.SelectedTab = tcCadastrar;
        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            VisualizarFornecedores();
            //Mudar de TabPage
            this.tbFornecedor.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultafornecedor.DataSource != null)
            {
                this.dtgconsultafornecedor.DataSource = null;
            }
            else
            {
                this.dtgconsultafornecedor.Rows.Clear();
            }
        }

        private void dtgconsultafornecedor_DoubleClick(object sender, EventArgs e)
        {
            VisualizarFornecedores();
            this.tbFornecedor.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultafornecedor.DataSource != null)
            {
                this.dtgconsultafornecedor.DataSource = null;
            }
            else
            {
                this.dtgconsultafornecedor.Rows.Clear();
            }
        }

        private void txtcodcidadeconsulta_Leave(object sender, EventArgs e)
        {
            DAL.CidadesDAL cidades = new DAL.CidadesDAL();
            if (txtcodcidadeconsulta.Text.Contains("'"))
            {
                txtcodcidadeconsulta.Text = txtcodigocidade.Text.Replace("'", "");
            }
            txtcidadeconsulta.Text = cidades.getCidades(Convert.ToInt32(txtcodcidadeconsulta.Text)).Cidade;
            mskufconsulta.Text = cidades.getCidades(Convert.ToInt32(txtcodcidadeconsulta.Text)).UF;
            if (txtcidade.Text == string.Empty)
            {
                MessageBox.Show("Cidade inexistente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtcodcidadeconsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadCidades cidades = new View.CadCidades();
                    cidades.ShowDialog();
                    txtcodcidadeconsulta.Text = cidades.txtcodigocidade.Text;
                    break;
            }
        }

        private void chkboxcidadeconsulta_CheckStateChanged(object sender, EventArgs e)
        {
            CarregarGridView();
        }

        private void txtcodigocidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
