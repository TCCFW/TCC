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
    public partial class CadMesas : Form
    {
        private bool Modificar = false;
        private bool Adicionar = true;
        private int Reg_Atual = 0;
        private int salvanovo = 0;

        public CadMesas()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            rbnao.Checked = true;
            txtcodigomesa.Clear();
            txtmesas.Clear();
        }

        private void BloquearCampos()
        {
            txtmesas.Enabled = false;
            txtcodigomesa.Enabled = false;
            rbnao.Enabled = false;
            rbsim.Enabled = false;
        }

        private void DesbloquearCampos()
        {

            txtmesas.Enabled = true;
            txtcodigomesa.Enabled = true;
            rbnao.Enabled = true;
            rbsim.Enabled = true;
        }

        private void CadMesas_Load(object sender, EventArgs e)
        {
            BloquearCampos();
            tsadicionar.Enabled = true;
            tseditar.Enabled = true;
            tsexcluir.Enabled = true;
            tssair.Enabled = true;
            tssalvar.Enabled = false;
            tsCancelar.Enabled = false;
            txtmesas.Focus();
            RecebeUltimaMesa(Reg_Atual);
        }

        public void RecebeUltimaMesa(int codigo)
        {
            DAL.MesasDAL mesas = new DAL.MesasDAL();
            txtmesas.Text = mesas.getMesas(codigo).Mesa.ToString();
            txtcodigomesa.Text = mesas.getMesas(codigo).Codigo.ToString();
            if (mesas.getMesas(codigo).Bloqueado == "N")
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

        private void salvarMesas()
        {
            BLL.MesasBLL mesasBLL = new BLL.MesasBLL();
            Model.MesasModel mesasModel = new Model.MesasModel();

            mesasModel.Mesa = txtmesas.Text;
            if ((rbnao.Checked == false) && (rbsim.Checked == true))
            {
                mesasModel.Bloqueado = "S";

            }
            if ((rbnao.Checked == true) && (rbsim.Checked == false))
            {
                mesasModel.Bloqueado = "N";
            }

            if (Modificar == false)
            {
                mesasBLL.IncluirMesas(mesasModel);
            }
            else
            {
                mesasModel.Codigo = Convert.ToInt32(txtcodigomesa.Text);
                mesasBLL.AlterarMesas(mesasModel);
            }
            MessageBox.Show("Dados Gravados com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void VisualizarMesas()
        {
            txtmesas.Text = dtgconsultamesas.CurrentRow.Cells[1].Value.ToString();
            txtcodigomesa.Text = dtgconsultamesas.CurrentRow.Cells[0].Value.ToString();
            if (dtgconsultamesas.CurrentRow.Cells[2].Value.ToString() == "S")
            {
                rbnao.Checked = false;
                rbsim.Checked = true;
            }
            else
            {
                rbnao.Checked = true;
                rbsim.Checked = false;
            }
            tbMesas.SelectedTab = tcCadastrar;
        }

        private void dtgconsultamesas_DoubleClick(object sender, EventArgs e)
        {
            VisualizarMesas();
            this.tbMesas.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultamesas.DataSource != null)
            {
                this.dtgconsultamesas.DataSource = null;
            }
            else
            {
                this.dtgconsultamesas.Rows.Clear();
            }
        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            VisualizarMesas();
            this.tbMesas.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultamesas.DataSource != null)
            {
                this.dtgconsultamesas.DataSource = null;
            }
            else
            {
                this.dtgconsultamesas.Rows.Clear();
            }
        }

        private void CadMesas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tssalvar.Enabled == true)
            {
                if (MessageBox.Show("Tem certeza que deseja sair?\nAs informações alteradas não serão salvas", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void CadMesas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tssair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tssalvar_Click(object sender, EventArgs e)
        {
            salvanovo++;
            salvarMesas();
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
                RecebeUltimaMesa(0);
            }
            else
            {
                RecebeUltimaMesa(Reg_Atual);
            }
            salvanovo = 0;
        }

        private void tsexcluir_Click(object sender, EventArgs e)
        {
            BLL.MesasBLL mesasBLL = new BLL.MesasBLL();
            Model.MesasModel mesasModel = new Model.MesasModel();
            if (txtcodigomesa.Text == String.Empty)
            {
                MessageBox.Show("Selecione a cidade que deseja excluir", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mesasModel.Codigo = Convert.ToInt32(txtcodigomesa.Text);
                if (MessageBox.Show("Tem certeza que deseja excluir a cidade codigo " + txtcodigomesa.Text + "?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    mesasBLL.ExcluirMesas(mesasModel);
                    MessageBox.Show("Cidade excluída com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                tsCancelar.Enabled = false;
                LimparCampos();
                RecebeUltimaMesa(Reg_Atual);
            }
        }

        private void tsadicionar_Click(object sender, EventArgs e)
        {
            Adicionar = false;
            salvanovo++;
            if (txtcodigomesa.Text != string.Empty)
            {
                Reg_Atual = Convert.ToInt32(txtcodigomesa.Text);
            }
            LimparCampos();
            txtmesas.Focus();
            tsadicionar.Enabled = false;
            tseditar.Enabled = false;
            tsexcluir.Enabled = false;
            tssair.Enabled = false;
            tssalvar.Enabled = true;
            tsCancelar.Enabled = true;
            tbMesas.SelectedTab = tcCadastrar;
            DesbloquearCampos();
        }

        private void tseditar_Click(object sender, EventArgs e)
        {
            if (txtcodigomesa.Text != string.Empty)
            {
                Reg_Atual = Convert.ToInt32(txtcodigomesa.Text);
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
                tsadicionar.Enabled = true;
                tseditar.Enabled = true;
                tsexcluir.Enabled = true;
                tssair.Enabled = true;
                tssalvar.Enabled = false;
                tsCancelar.Enabled = false;
                if (txtcodigomesa.Text == string.Empty)
                {
                    RecebeUltimaMesa(Reg_Atual);
                }
                salvanovo = 0;
            }
        }

        private void txtmesasconsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BLL.MesasBLL mesasBLL = new BLL.MesasBLL();
                    if (rbcodconsulta.Checked == true)
                    {
                        if (rbconsultanao.Checked == true)
                        {
                            dtgconsultamesas.DataSource = mesasBLL.getMesasDT("codigo", "N", txtmesasconsulta.Text);
                        }
                        else
                        {
                            dtgconsultamesas.DataSource = mesasBLL.getMesasDT("codigo", "S", txtmesasconsulta.Text);
                        }
                        if (rbconsultatodos.Checked == true)
                        {
                            dtgconsultamesas.DataSource = mesasBLL.getMesasDT("codigo", "T", txtmesasconsulta.Text);
                        }
                    }
                    if (rbnomeconsulta.Checked == true)
                    {
                        if (rbconsultatodos.Checked == true)
                        {
                            dtgconsultamesas.DataSource = mesasBLL.getMesasDT("mesa", "T", txtmesasconsulta.Text);
                        }
                        if (rbconsultanao.Checked == true)
                        {
                            dtgconsultamesas.DataSource = mesasBLL.getMesasDT("mesa", "N", txtmesasconsulta.Text);
                        }
                        if (rbconsultasim.Checked == true)
                        {
                            dtgconsultamesas.DataSource = mesasBLL.getMesasDT("mesa", "S", txtmesasconsulta.Text);
                        }
                    }
                    break;
            }
        }
    }
}
