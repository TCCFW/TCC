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
    public partial class CadSubGrupo : Form
    {
        private bool Modificar = false;
        private bool Adicionar = true;
        private int Reg_Atual = 0;
        private int salvanovo = 0;

        public CadSubGrupo()
        {
            InitializeComponent();
        }

        private void tssair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimparCampos()
        {
            txtcodigo.Clear();
            txtgrupo.Clear();
            txtsubgrupo.Clear();
            txtcodgrupo.Clear();
        }

        private void DesbloquearCampos()
        {
            txtcodgrupo.Enabled = true;
            txtsubgrupo.Enabled = true;
            rbnao.Enabled = true;
            rbsim.Enabled = true;
        }

        private void BloquearCampos()
        {
            txtcodgrupo.Enabled = false;
            txtsubgrupo.Enabled = false;
            rbnao.Enabled = false;
            rbsim.Enabled = false;
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
            tbSubGrupos.SelectedTab = tcCadastrar;
            DesbloquearCampos();
        }

        private void VisualizarSubGrupos()
        {
            txtcodigo.Text = dtgconsultasubgrupos.CurrentRow.Cells[0].Value.ToString();
            txtcodgrupo.Text = dtgconsultasubgrupos.CurrentRow.Cells[1].Value.ToString();
            txtsubgrupo.Text = dtgconsultasubgrupos.CurrentRow.Cells[2].Value.ToString();
            txtgrupo.Text = dtgconsultasubgrupos.CurrentRow.Cells[4].Value.ToString();
            

            if (dtgconsultasubgrupos.CurrentRow.Cells[3].Value.ToString() == "S")
            {
                rbnao.Checked = false;
                rbsim.Checked = true;
            }
            else
            {
                rbnao.Checked = true;
                rbsim.Checked = false;
            }
            tbSubGrupos.SelectedTab = tcCadastrar;
        }

        private void CadSubGrupo_Load(object sender, EventArgs e)
        {
            BloquearCampos();
            tsadicionar.Enabled = true;
            tseditar.Enabled = true;
            tsexcluir.Enabled = true;
            tssair.Enabled = true;
            tssalvar.Enabled = false;
            tsCancelar.Enabled = false;
            txtgrupo.Focus();
            rbnao.Checked = true;
            rbsim.Checked = false;
            RecebeUltimoSubGrupo(Reg_Atual);
        }

        private void CadSubGrupo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tssalvar.Enabled == true)
            {
                if (MessageBox.Show("Tem certeza que deseja sair?\nAs informações alteradas não serão salvas", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void CadSubGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void RecebeUltimoSubGrupo(int codigo)
        {
            DAL.SubGruposDAL subgrupos = new DAL.SubGruposDAL();
            if (codigo != 0)
            {
                txtgrupo.Text = subgrupos.getSubGruposPorCodigo(codigo).Descricao_grupo;
                txtcodigo.Text = subgrupos.getSubGruposPorCodigo(codigo).Codigo.ToString();
                txtsubgrupo.Text = subgrupos.getSubGruposPorCodigo(codigo).Subgrupo;
                txtcodgrupo.Text = subgrupos.getSubGruposPorCodigo(codigo).Grupo.ToString();
                if (subgrupos.getSubGruposPorCodigo(codigo).Bloqueado == "N")
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
            else
            {
                txtgrupo.Text = subgrupos.getSubGrupos().Descricao_grupo;
                txtcodigo.Text = subgrupos.getSubGrupos().Codigo.ToString();
                txtsubgrupo.Text = subgrupos.getSubGrupos().Subgrupo;
                txtcodgrupo.Text = subgrupos.getSubGrupos().Grupo.ToString();
                if (subgrupos.getSubGrupos().Bloqueado == "N")
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
                if (txtcodigo.Text == string.Empty)
                {
                    RecebeUltimoSubGrupo(Reg_Atual);
                }
                salvanovo = 0;
            }
        }

        private void tsexcluir_Click(object sender, EventArgs e)
        {
            BLL.SubGruposBLL subgruposBLL = new BLL.SubGruposBLL();
            Model.SubGrupoModel subgruposModel = new Model.SubGrupoModel();
            if (txtcodigo.Text == String.Empty)
            {
                MessageBox.Show("Selecione o subgrupo que deseja excluir", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                subgruposModel.Codigo = Convert.ToInt32(txtcodigo.Text);
                if (MessageBox.Show("Tem certeza que deseja excluir o grupo codigo " + txtcodigo.Text + "?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    subgruposBLL.ExcluirSubGrupos(subgruposModel);
                    MessageBox.Show("SubGrupo excluído com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RecebeUltimoSubGrupo(0);
                }
                tsCancelar.Enabled = false;
            }
        }

        private void txtgrupoconsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BLL.SubGruposBLL subgruposDAL = new BLL.SubGruposBLL();
                    if (rbcodconsulta.Checked == true)
                    {
                        if (rbconsultanao.Checked == true)
                        {
                            dtgconsultasubgrupos.DataSource = subgruposDAL.getSubGruposDT("codigo", "N", txtsubgrupoconsulta.Text);
                        }
                        else
                        {
                            dtgconsultasubgrupos.DataSource = subgruposDAL.getSubGruposDT("codigo", "S", txtsubgrupoconsulta.Text);
                        }
                        if (rbconsultatodos.Checked == true)
                        {
                            dtgconsultasubgrupos.DataSource = subgruposDAL.getSubGruposDT("codigo", "T", txtsubgrupoconsulta.Text);
                        }
                    }
                    if (rbnomeconsulta.Checked == true)
                    {
                        if (rbconsultatodos.Checked == true)
                        {
                            dtgconsultasubgrupos.DataSource = subgruposDAL.getSubGruposDT("subgrupo", "T", txtsubgrupoconsulta.Text);
                        }
                        if (rbconsultanao.Checked == true)
                        {
                            dtgconsultasubgrupos.DataSource = subgruposDAL.getSubGruposDT("subgrupo", "N", txtsubgrupoconsulta.Text);
                        }
                        if (rbconsultasim.Checked == true)
                        {
                            dtgconsultasubgrupos.DataSource = subgruposDAL.getSubGruposDT("subgrupo", "S", txtsubgrupoconsulta.Text);
                        }
                    }
                    break;
            }
        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            VisualizarSubGrupos();
            //Mudar de TabPage
            this.tbSubGrupos.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultasubgrupos.DataSource != null)
            {
                this.dtgconsultasubgrupos.DataSource = null;
            }
            else
            {
                this.dtgconsultasubgrupos.Rows.Clear();
            }
        }

        private void dtgconsultasubgrupos_DoubleClick(object sender, EventArgs e)
        {
            VisualizarSubGrupos();
            //Mudar de TabPage
            this.tbSubGrupos.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultasubgrupos.DataSource != null)
            {
                this.dtgconsultasubgrupos.DataSource = null;
            }
            else
            {
                this.dtgconsultasubgrupos.Rows.Clear();
            }
        }

        private void tssalvar_Click(object sender, EventArgs e)
        {
            salvanovo++;
            salvarSubGrupos();
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
                RecebeUltimoSubGrupo(0);
            }
            else
            {
                RecebeUltimoSubGrupo(Reg_Atual);
            }
            salvanovo = 0;
        }

        private void salvarSubGrupos()
        {
            if ((txtgrupo.Text != string.Empty) && (txtsubgrupo.Text != String.Empty))
            {
                BLL.SubGruposBLL subgruposBLL = new BLL.SubGruposBLL();
                Model.SubGrupoModel subgruposModel = new Model.SubGrupoModel();

                subgruposModel.Grupo = Convert.ToInt32(txtcodgrupo.Text);
                subgruposModel.Subgrupo = txtsubgrupo.Text;
                if ((rbnao.Checked == false) && (rbsim.Checked == true))
                {
                    subgruposModel.Bloqueado = "S";

                }
                if ((rbnao.Checked == true) && (rbsim.Checked == false))
                {
                    subgruposModel.Bloqueado = "N";
                }

                if (Modificar == false)
                {
                    subgruposBLL.IncluirSubGrupos(subgruposModel);
                }
                else
                {
                    subgruposModel.Codigo = Convert.ToInt32(txtcodigo.Text);
                    subgruposBLL.AlterarSubGrupos(subgruposModel);
                }
                MessageBox.Show("Dados Gravados com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("informe o grupo e subgrupo antes de salvar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtcodgrupo_Leave(object sender, EventArgs e)
        {
            DAL.GruposDAL grupos = new DAL.GruposDAL();
            if (txtgrupo.Text != string.Empty)
            {
                txtgrupo.Text = grupos.getGrupos(Convert.ToInt32(txtcodgrupo.Text)).Grupo;
            }
        }

        private void txtcodgrupo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadGrupo subgrupo = new View.CadGrupo();
                    subgrupo.ShowDialog();
                    txtcodgrupo.Text = subgrupo.txtcodigogrupo.Text;
                    break;
            }
        }

        private void txtcodgrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
