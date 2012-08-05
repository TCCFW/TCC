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
    public partial class CadCidades : Form
    {
        private bool Modificar = false;
        private bool Adicionar = true;
        private int Reg_Atual = 0;
        private int salvanovo = 0;

        public CadCidades()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            mskuf.Clear();
            rbnao.Checked = true;
            txtcodigocidade.Clear();
            txtcidade.Clear();
        }

        private void BloquearCampos()
        {
            txtcidade.Enabled = false;
            txtcodigocidade.Enabled = false;
            rbnao.Enabled = false;
            rbsim.Enabled = false;
            mskuf.Enabled = false;
        }

        private void DesbloquearCampos()
        {

            txtcidade.Enabled = true;
            rbnao.Enabled = true;
            rbsim.Enabled = true;
            mskuf.Enabled = true;
        }

        private void CadCidades_Load(object sender, EventArgs e)
        {
            BloquearCampos();
            tsadicionar.Enabled = true;
            tseditar.Enabled = true;
            tsexcluir.Enabled = true;
            tssair.Enabled = true;
            tssalvar.Enabled = false;
            tsCancelar.Enabled = false;
            txtcidade.Focus();
            RecebeUltimaCidade(Reg_Atual);
        }

        public void RecebeUltimaCidade(int codigo)
        {
            DAL.CidadesDAL cidades = new DAL.CidadesDAL();
            txtcidade.Text = cidades.getCidades(codigo).Cidade.ToString();
            txtcodigocidade.Text = cidades.getCidades(codigo).Codigo.ToString();
            mskuf.Text = cidades.getCidades(codigo).UF;
            if (cidades.getCidades(codigo).Bloqueado == "N")
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

        private void tssair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tssalvar_Click(object sender, EventArgs e)
        {
            salvanovo++;
            salvarCidades();
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
                RecebeUltimaCidade(0);
            }
            else
            {
                RecebeUltimaCidade(Reg_Atual);
            }
            salvanovo = 0;
        }

        private void salvarCidades()
        {
            BLL.CidadesBLL cidadesBLL = new BLL.CidadesBLL();
            Model.CidadeModel cidadesModel = new Model.CidadeModel();

            cidadesModel.Cidade = txtcidade.Text;
            if ((rbnao.Checked == false) && (rbsim.Checked == true))
            {
                cidadesModel.Bloqueado = "S";

            }
            if ((rbnao.Checked == true) && (rbsim.Checked == false))
            {
                cidadesModel.Bloqueado = "N";
            }

            cidadesModel.UF = mskuf.Text;

            if (Modificar == false)
            {
                cidadesBLL.IncluirCidades(cidadesModel);
            }
            else
            {
                cidadesModel.Codigo = Convert.ToInt32(txtcodigocidade.Text);
                cidadesBLL.AlterarCidades(cidadesModel);
            }
            MessageBox.Show("Dados Gravados com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tsexcluir_Click(object sender, EventArgs e)
        {
            BLL.CidadesBLL cidadesBLL = new BLL.CidadesBLL();
            Model.CidadeModel cidadesModel = new Model.CidadeModel();
            if (txtcodigocidade.Text == String.Empty)
            {
                MessageBox.Show("Selecione a cidade que deseja excluir", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cidadesModel.Codigo = Convert.ToInt32(txtcodigocidade.Text);
                if (MessageBox.Show("Tem certeza que deseja excluir a cidade codigo " + txtcodigocidade.Text + "?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cidadesBLL.ExcluirCidades(cidadesModel);
                    MessageBox.Show("Cidade excluída com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RecebeUltimaCidade(0);
                }
                else
                {
                    tsCancelar.Enabled = false;
                }
            }
        }

        private void tsadicionar_Click(object sender, EventArgs e)
        {
            Adicionar = false;
            salvanovo++;
            if (txtcodigocidade.Text != string.Empty)
            {
                Reg_Atual = Convert.ToInt32(txtcodigocidade.Text);
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

        private void tseditar_Click(object sender, EventArgs e)
        {
            if (txtcodigocidade.Text != string.Empty)
            {
                Reg_Atual = Convert.ToInt32(txtcodigocidade.Text);
            }
            tsadicionar.Enabled = false;
            tseditar.Enabled = false;
            tsexcluir.Enabled = false;
            tssair.Enabled = false;
            tssalvar.Enabled = true;
            tsCancelar.Enabled = true;
            DesbloquearCampos();
            Modificar = true;
        }

        private void tsCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja cancelar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                BloquearCampos();
                LimparCampos();
                tsadicionar.Enabled = true;
                tseditar.Enabled = true;
                tsexcluir.Enabled = true;
                tssair.Enabled = true;
                tssalvar.Enabled = false;
                tsCancelar.Enabled = false;
                if (txtcodigocidade.Text == string.Empty)
                {
                    RecebeUltimaCidade(Reg_Atual);
                }
                salvanovo = 0;
            }
        }

        private void txtcidadeconsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BLL.CidadesBLL cidadesBLL = new BLL.CidadesBLL();
                    if (rbcodconsulta.Checked == true)
                    {
                        if (rbconsultanao.Checked == true)
                        {
                            dtgconsultacidades.DataSource = cidadesBLL.getCidadesDT("codigo", "N", txtcidadeconsulta.Text);
                        }
                        else
                        {
                            dtgconsultacidades.DataSource = cidadesBLL.getCidadesDT("codigo", "S", txtcidadeconsulta.Text);
                        }
                        if (rbconsultatodos.Checked == true)
                        {
                            dtgconsultacidades.DataSource = cidadesBLL.getCidadesDT("codigo", "T", txtcidadeconsulta.Text);
                        }
                    }
                    if (rbnomeconsulta.Checked == true)
                    {
                        if (rbconsultatodos.Checked == true)
                        {
                            dtgconsultacidades.DataSource = cidadesBLL.getCidadesDT("cidade", "T", txtcidadeconsulta.Text);
                        }
                        if (rbconsultanao.Checked == true)
                        {
                            dtgconsultacidades.DataSource = cidadesBLL.getCidadesDT("cidade", "N", txtcidadeconsulta.Text);
                        }
                        if (rbconsultasim.Checked == true)
                        {
                            dtgconsultacidades.DataSource = cidadesBLL.getCidadesDT("cidade", "S", txtcidadeconsulta.Text);
                        }
                    }
                    break;
            }
        }

        private void CadCidades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            VisualizarCidades();
            //Mudar de TabPage
            this.tbCidades.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultacidades.DataSource != null)
            {
                this.dtgconsultacidades.DataSource = null;
            }
            else
            {
                this.dtgconsultacidades.Rows.Clear();
            }
        }

        private void VisualizarCidades()
        {
            txtcidade.Text = dtgconsultacidades.CurrentRow.Cells[1].Value.ToString();
            txtcodigocidade.Text = dtgconsultacidades.CurrentRow.Cells[0].Value.ToString();
            mskuf.Text = dtgconsultacidades.CurrentRow.Cells[2].Value.ToString();
            if (dtgconsultacidades.CurrentRow.Cells[3].Value.ToString() == "S")
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

        private void dtgconsultacidades_DoubleClick(object sender, EventArgs e)
        {
            VisualizarCidades();
            //Mudar de TabPage
            this.tbCidades.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultacidades.DataSource != null)
            {
                this.dtgconsultacidades.DataSource = null;
            }
            else
            {
                this.dtgconsultacidades.Rows.Clear();
            }
        }

        private void CadCidades_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tssalvar.Enabled == true)
            {
                if (MessageBox.Show("Tem certeza que deseja sair?\nAs informações alteradas não serão salvas", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
