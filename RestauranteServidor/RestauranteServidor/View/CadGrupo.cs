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
    public partial class CadGrupo : Form
    {
        private bool Modificar = false;
        private bool Adicionar = true;
        private int Reg_Atual = 0;
        private int salvanovo = 0;

        public CadGrupo()
        {
            InitializeComponent();
        }

        private void CadGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        private void VisualizarGrupos()
        {
            txtgrupo.Text = dtgconsultagrupos.CurrentRow.Cells[1].Value.ToString();
            txtcodigogrupo.Text = dtgconsultagrupos.CurrentRow.Cells[0].Value.ToString();
            if (dtgconsultagrupos.CurrentRow.Cells[2].Value.ToString() == "S")
            {
                rbnao.Checked = false;
                rbsim.Checked = true;
            }
            else
            {
                rbnao.Checked = true;
                rbsim.Checked = false;
            }
            tbGrupos.SelectedTab = tcCadastrar;
        }

        private void CadGrupo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tssalvar.Enabled == true)
            {
                if (MessageBox.Show("Tem certeza que deseja sair?\nAs informações alteradas não serão salvas", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void CadGrupo_Load(object sender, EventArgs e)
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
            RecebeUltimoGrupo(Reg_Atual);
        }

        private void RecebeUltimoGrupo(int codigo)
        {
            DAL.GruposDAL grupos = new DAL.GruposDAL();

            txtgrupo.Text = grupos.getGrupos(codigo).Grupo.ToString();
            txtgrupo.Text = grupos.getGrupos(codigo).Grupo;
            txtcodigogrupo.Text = grupos.getGrupos(codigo).Codigo.ToString();
            if (grupos.getGrupos(codigo).Bloqueado == "N")
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

        private void BloquearCampos()
        {
            txtcodigogrupo.Enabled = false;
            txtgrupo.Enabled = false;
            rbnao.Enabled = false;
            rbsim.Enabled = false;
        }

        private void DesbloquearCampos()
        {
            txtgrupo.Enabled = true;
            rbnao.Enabled = true;
            rbsim.Enabled = true;
        }

          private void LimparCampos()
          {
            txtcodigogrupo.Clear();
            txtgrupo.Clear();
            rbnao.Checked = true;
          }

          private void tsadicionar_Click(object sender, EventArgs e)
          {
              Adicionar = false;
              salvanovo++;
              if (txtcodigogrupo.Text != string.Empty)
              {
                  Reg_Atual = Convert.ToInt32(txtcodigogrupo.Text);
              }
              LimparCampos();
              tsadicionar.Enabled = false;
              tseditar.Enabled = false;
              tsexcluir.Enabled = false;
              tssair.Enabled = false;
              tssalvar.Enabled = true;
              tsCancelar.Enabled = true;
              tbGrupos.SelectedTab = tcCadastrar;
              DesbloquearCampos();
          }

          private void tseditar_Click(object sender, EventArgs e)
          {
              if (txtcodigogrupo.Text != string.Empty)
              {
                  Reg_Atual = Convert.ToInt32(txtcodigogrupo.Text);
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
                  Adicionar = false;
                  BloquearCampos();
                  tsadicionar.Enabled = true;
                  tseditar.Enabled = true;
                  tsexcluir.Enabled = true;
                  tssair.Enabled = true;
                  tssalvar.Enabled = false;
                  tsCancelar.Enabled = false;
                  if (txtcodigogrupo.Text != string.Empty)
                  {
                      RecebeUltimoGrupo(Reg_Atual);
                  }
                  salvanovo = 0;
              }
          }

          private void tsexcluir_Click(object sender, EventArgs e)
          {
              BLL.GruposBLL gruposBLL = new BLL.GruposBLL();
              Model.GrupoModel gruposModel = new Model.GrupoModel();
              if (txtcodigogrupo.Text == String.Empty)
              {
                  MessageBox.Show("Selecione o grupo que deseja excluir", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
              else
              {
                  gruposModel.Codigo = Convert.ToInt32(txtcodigogrupo.Text);
                  if (MessageBox.Show("Tem certeza que deseja excluir o grupo codigo " + txtcodigogrupo.Text + "?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                  {
                      gruposBLL.ExcluirGrupos(gruposModel);
                      MessageBox.Show("Grupo excluído com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                  tsCancelar.Enabled = false;
                  LimparCampos();
                  RecebeUltimoGrupo(Reg_Atual);
              }
          }

          private void tssair_Click(object sender, EventArgs e)
          {
              this.Close();
          }

          private void txtgrupoconsulta_KeyDown(object sender, KeyEventArgs e)
          {
              switch (e.KeyCode)
              {
                  case Keys.Enter:

                      BLL.GruposBLL gruposBLL = new BLL.GruposBLL();
                      if (rbcodconsulta.Checked == true)
                      {
                          if (rbconsultanao.Checked == true)
                          {
                              dtgconsultagrupos.DataSource = gruposBLL.getGruposDT("codigo", "N", txtgrupoconsulta.Text);
                          }
                          else
                          {
                              dtgconsultagrupos.DataSource = gruposBLL.getGruposDT("codigo", "S", txtgrupoconsulta.Text);
                          }
                          if (rbconsultatodos.Checked == true)
                          {
                              dtgconsultagrupos.DataSource = gruposBLL.getGruposDT("codigo", "T", txtgrupoconsulta.Text);
                          }
                      }
                      if (rbnomeconsulta.Checked == true)
                      {
                          if (rbconsultatodos.Checked == true)
                          {
                              dtgconsultagrupos.DataSource = gruposBLL.getGruposDT("grupo", "T", txtgrupoconsulta.Text);
                          }
                          if (rbconsultanao.Checked == true)
                          {
                              dtgconsultagrupos.DataSource = gruposBLL.getGruposDT("grupo", "N", txtgrupoconsulta.Text);
                          }
                          if (rbconsultasim.Checked == true)
                          {
                              dtgconsultagrupos.DataSource = gruposBLL.getGruposDT("grupo", "S", txtgrupoconsulta.Text);
                          }
                      }
                      break;
              }
          }

          private void btnfinalizar_Click(object sender, EventArgs e)
          {
              VisualizarGrupos();
              //Mudar de TabPage
              this.tbGrupos.SelectedTab = tcCadastrar;
              //Limpar o DataGridView ao mudar de TabPage
              if (this.dtgconsultagrupos.DataSource != null)
              {
                  this.dtgconsultagrupos.DataSource = null;
              }
              else
              {
                  this.dtgconsultagrupos.Rows.Clear();
              }
          }

          private void tssalvar_Click(object sender, EventArgs e)
          {
              salvanovo++;
              salvarGrupos();
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
                  RecebeUltimoGrupo(0);
              }
              else
              {
                  RecebeUltimoGrupo(Reg_Atual);
              }
              salvanovo = 0;
          }

          private void salvarGrupos()
          {
              BLL.GruposBLL gruposBLL = new BLL.GruposBLL();
              Model.GrupoModel gruposModel = new Model.GrupoModel();

              gruposModel.Grupo = txtgrupo.Text;
              if ((rbnao.Checked == false) && (rbsim.Checked == true))
              {
                  gruposModel.Bloqueado = "S";

              }
              if ((rbnao.Checked == true) && (rbsim.Checked == false))
              {
                  gruposModel.Bloqueado = "N";
              }

              if (Modificar == false)
              {
                  gruposBLL.IncluirGrupos(gruposModel);
              }
              else
              {
                  gruposModel.Codigo = Convert.ToInt32(txtcodigogrupo.Text);
                  gruposBLL.AlterarGrupos(gruposModel);
              }
              MessageBox.Show("Dados Gravados com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

          }

          private void dtgconsultagrupos_DoubleClick(object sender, EventArgs e)
          {
              VisualizarGrupos();
              //Mudar de TabPage
              this.tbGrupos.SelectedTab = tcCadastrar;
              //Limpar o DataGridView ao mudar de TabPage
              if (this.dtgconsultagrupos.DataSource != null)
              {
                  this.dtgconsultagrupos.DataSource = null;
              }
              else
              {
                  this.dtgconsultagrupos.Rows.Clear();
              }
          }
    }
}
