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
    public partial class CadUsuario : Form
    {
        private bool Modificar = false;
        private bool Adicionar = true;
        private int Reg_Atual = 0;
        private int salvanovo = 0;
        
        public CadUsuario()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            mskuf.Clear();
            rbnao.Checked = true;
            txtcodcidade.Clear();
            txtcidade.Clear();
            txtbairro.Clear();
            txtcodigousuario.Clear();
            txtconfsenha.Clear();
            txtemail.Clear();
            txtendereco.Clear();
            txtnome.Clear();
            txtnumero.Clear();
            txtsenha.Clear();
            txtusuario.Clear();
            mskcelular.Clear();
            mskcep.Clear();
            msktelefone.Clear();
            rbGarcom.Checked = true;
        }

        private void BloquearCampos()
        {
            mskuf.Enabled = false;
            rbnao.Enabled = false;
            rbComum.Enabled = false;
            rbintermediario.Enabled = false;
            rbsim.Enabled = false;
            rbadministrador.Enabled = false;
            rbGarcom.Enabled = false;
            txtcodcidade.Enabled = false;
            txtcidade.Enabled  = false;
            txtbairro.Enabled = false;
            txtcodigousuario.Enabled = false;
            txtconfsenha.Enabled = false;
            txtemail.Enabled = false;
            txtendereco.Enabled = false;
            txtnome.Enabled = false;
            txtnumero.Enabled = false;
            txtsenha.Enabled = false;
            txtusuario.Enabled = false;
            mskcelular.Enabled = false;
            mskcep.Enabled = false;
            msktelefone.Enabled = false;
            rbComum.Enabled = false;
        }

        private void DesbloquearCampos()
        {
            rbnao.Enabled = true;
            rbComum.Enabled = true;
            rbintermediario.Enabled = true;
            rbsim.Enabled = true;
            rbadministrador.Enabled = true;
            txtcodcidade.Enabled = true;
            txtbairro.Enabled = true;
            txtconfsenha.Enabled = true;
            txtemail.Enabled = true;
            txtendereco.Enabled = true;
            txtnome.Enabled = true;
            txtnumero.Enabled = true;
            txtsenha.Enabled = true;
            txtusuario.Enabled = true;
            mskcelular.Enabled = true;
            mskcep.Enabled = true;
            msktelefone.Enabled = true;
            rbComum.Enabled = true;
            rbGarcom.Enabled = true;
        }

        private void DesbloquearCamposSemSenha()
        {
            rbnao.Enabled = true;
            rbComum.Enabled = true;
            rbintermediario.Enabled = true;
            rbsim.Enabled = true;
            rbadministrador.Enabled = true;
            txtcodcidade.Enabled = true;
            txtbairro.Enabled = true;
            txtemail.Enabled = true;
            txtendereco.Enabled = true;
            txtnome.Enabled = true;
            txtnumero.Enabled = true;
            txtusuario.Enabled = true;
            mskcelular.Enabled = true;
            mskcep.Enabled = true;
            msktelefone.Enabled = true;
            rbComum.Enabled = true;
            rbGarcom.Enabled = true;
        }

        public void RecebeUltimoUsuario(int codigo)
        {
            DAL.UsuarioDAL usuarios = new DAL.UsuarioDAL();
            txtbairro.Text = usuarios.getUsuarios(codigo).Endereco.Bairro;
            txtcodcidade.Text = usuarios.getUsuarios(codigo).Endereco.Cidade.Codigo.ToString();
            txtcidade.Text = usuarios.getUsuarios(codigo).Endereco.Cidade.Cidade;
            txtcodigousuario.Text = usuarios.getUsuarios(codigo).Codigo.ToString();
            txtconfsenha.Text = usuarios.getUsuarios(codigo).Senha;
            txtemail.Text = usuarios.getUsuarios(codigo).Email;
            txtendereco.Text = usuarios.getUsuarios(codigo).Endereco.Rua;
            txtnome.Text = usuarios.getUsuarios(codigo).Nome;
            txtnumero.Text = usuarios.getUsuarios(codigo).Endereco.Numero;
            txtsenha.Text = usuarios.getUsuarios(codigo).Senha;
            txtusuario.Text = usuarios.getUsuarios(codigo).Usuario;
            mskcelular.Text = usuarios.getUsuarios(codigo).Celular;
            mskcep.Text = usuarios.getUsuarios(codigo).Endereco.Cep;
            msktelefone.Text = usuarios.getUsuarios(codigo).Telefone;
            mskuf.Text = usuarios.getUsuarios(codigo).Endereco.Cidade.UF;

            if (usuarios.getUsuarios(codigo).Bloqueado == "S")
            {
                rbnao.Checked = false;
                rbsim.Checked = true;
            }
            else
            {
                rbnao.Checked = true;
                rbsim.Checked = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtbairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void tssair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CadUsuario_Load(object sender, EventArgs e)
        {
            BloquearCampos();
            tsadicionar.Enabled = true;
            tseditar.Enabled = true;
            tsexcluir.Enabled = true;
            tssair.Enabled = true;
            tssalvar.Enabled = false;
            tsCancelar.Enabled = false;
            txtcidade.Focus();
            RecebeUltimoUsuario(Reg_Atual);
        }

        private void CadUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tssalvar.Enabled == true)
            {
                if (MessageBox.Show("Tem certeza que deseja sair?\nAs informações alteradas não serão salvas", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void CadUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tssalvar_Click(object sender, EventArgs e)
        {
            salvanovo++;
            salvarUsuarios();
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
                RecebeUltimoUsuario(0);
            }
            else
            {
                RecebeUltimoUsuario(Reg_Atual);
            }
            salvanovo = 0;
        }

        private void salvarUsuarios()
        {
            BLL.UsuariosBLL usuariosBLL = new BLL.UsuariosBLL();
            Model.UsuarioModel usuariosModel = new Model.UsuarioModel();

            string chave = "TCCFW";
            BLL.Criptografia crip = new BLL.Criptografia(BLL.CryptProvider.DES);
            crip.Key = chave;

            usuariosModel.Endereco.Cidade.Codigo = Convert.ToInt32(txtcodcidade.Text);
            usuariosModel.Celular = mskcelular.Text;
            usuariosModel.Cidade = Convert.ToInt32(txtcodcidade.Text);
            usuariosModel.Email = txtemail.Text;
            usuariosModel.Nome = txtnome.Text;
            usuariosModel.Telefone = msktelefone.Text;
            usuariosModel.Usuario = txtusuario.Text;
            usuariosModel.Endereco.Numero = txtnumero.Text;
            usuariosModel.Endereco.Bairro = txtbairro.Text;
            usuariosModel.Endereco.Rua = txtendereco.Text;
            usuariosModel.Endereco.Cep = mskcep.Text;

            if ((rbnao.Checked == false) && (rbsim.Checked == true))
            {
                usuariosModel.Bloqueado = "S";

            }
            if ((rbnao.Checked == true) && (rbsim.Checked == false))
            {
                usuariosModel.Bloqueado = "N";
            }
            if ((rbadministrador.Checked == false) && (rbintermediario.Checked == false) && (rbComum.Checked == false) && (rbGarcom.Checked == true))
            {
                usuariosModel.Categoria = "GA";
            }
            if ((rbadministrador.Checked == true) && (rbintermediario.Checked == false) && (rbComum.Checked == false) && (rbGarcom.Checked == false))
            {
                usuariosModel.Categoria = "AD";
            }
            if ((rbadministrador.Checked == false) && (rbintermediario.Checked == true) && (rbComum.Checked == false) && (rbGarcom.Checked == false))
            {
                usuariosModel.Categoria = "IN";
            }
            if ((rbadministrador.Checked == false) && (rbintermediario.Checked == false) && (rbComum.Checked == true) && (rbGarcom.Checked == false))
            {
                usuariosModel.Categoria = "CO";
            }
            
            if (txtsenha.Text == txtconfsenha.Text)
            {
                
                if (Modificar == false)
                {
                    usuariosModel.Senha = crip.Encrypt(txtsenha.Text);
                    usuariosBLL.IncluirUsuarios(usuariosModel);
                }
                else
                {
                    usuariosModel.Senha = crip.Encrypt(txtsenha.Text);
                    usuariosModel.Codigo = Convert.ToInt32(txtcodigousuario.Text);
                    usuariosBLL.AlterarUsuarios(usuariosModel);
                }
                MessageBox.Show("Dados Gravados com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("A senha não confere com o campo confirmar senha", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void tsexcluir_Click(object sender, EventArgs e)
        {
            BLL.UsuariosBLL usuariosBLL = new BLL.UsuariosBLL();
            Model.UsuarioModel usuariosModel = new Model.UsuarioModel();
            if (txtcodigousuario.Text == String.Empty)
            {
                MessageBox.Show("Selecione o usuario que deseja excluir", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                usuariosModel.Codigo = Convert.ToInt32(txtcodigousuario.Text);
                if (MessageBox.Show("Tem certeza que deseja excluir o usuario codigo " + txtcodigousuario.Text + "?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    usuariosBLL.ExcluirUsuarios(usuariosModel);
                    MessageBox.Show("Usuario excluído com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RecebeUltimoUsuario(0);
                }
                tsCancelar.Enabled = false;
            }
        }

        private void tsadicionar_Click(object sender, EventArgs e)
        {
            Adicionar = false;
            salvanovo++;
            if (txtcodigousuario.Text != string.Empty)
            {
                Reg_Atual = Convert.ToInt32(txtcodigousuario.Text);
            }
            LimparCampos();
            txtnome.Focus();
            tsadicionar.Enabled = false;
            tseditar.Enabled = false;
            tsexcluir.Enabled = false;
            tssair.Enabled = false;
            tssalvar.Enabled = true;
            tsCancelar.Enabled = true;
            tbUsuarios.SelectedTab = tcCadastrar;
            DesbloquearCampos();
        }

        private void tseditar_Click(object sender, EventArgs e)
        {
            if (txtcodigousuario.Text != string.Empty)
            {
                Reg_Atual = Convert.ToInt32(txtcodigousuario.Text);
            }
            tsadicionar.Enabled = false;
            tseditar.Enabled = false;
            tsexcluir.Enabled = false;
            tssair.Enabled = false;
            tssalvar.Enabled = true;
            tsCancelar.Enabled = true;
            DesbloquearCamposSemSenha();
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
                if (txtcodigousuario.Text == string.Empty)
                {
                    RecebeUltimoUsuario(Reg_Atual);
                }
                salvanovo = 0;
            }
        }

        private void txtusuarioconsulta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BLL.UsuariosBLL usuariosBLL = new BLL.UsuariosBLL();
                    if (rbcodconsulta.Checked == true)
                    {
                        if (rbconsultanao.Checked == true)
                        {
                            dtgconsultausuarios.DataSource = usuariosBLL.getCidadesDT("codigo", "N", txtusuarioconsulta.Text);
                        }
                        else
                        {
                            dtgconsultausuarios.DataSource = usuariosBLL.getCidadesDT("codigo", "S", txtusuarioconsulta.Text);
                        }
                        if (rbconsultatodos.Checked == true)
                        {
                            dtgconsultausuarios.DataSource = usuariosBLL.getCidadesDT("codigo", "T", txtusuarioconsulta.Text);
                        }
                    }
                    if (rbnomeconsulta.Checked == true)
                    {
                        if (rbconsultatodos.Checked == true)
                        {
                            dtgconsultausuarios.DataSource = usuariosBLL.getCidadesDT("usuario", "T", txtusuarioconsulta.Text);
                        }
                        if (rbconsultanao.Checked == true)
                        {
                            dtgconsultausuarios.DataSource = usuariosBLL.getCidadesDT("usuario", "N", txtusuarioconsulta.Text);
                        }
                        if (rbconsultasim.Checked == true)
                        {
                            dtgconsultausuarios.DataSource = usuariosBLL.getCidadesDT("usuario", "S", txtusuarioconsulta.Text);
                        }
                    }
                    break;
            }
        }

        private void VisualizarUsuarios()
        {
            txtcodigousuario.Text = dtgconsultausuarios.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = dtgconsultausuarios.CurrentRow.Cells[1].Value.ToString();
            txtendereco.Text = dtgconsultausuarios.CurrentRow.Cells[2].Value.ToString();
            txtnumero.Text = dtgconsultausuarios.CurrentRow.Cells[3].Value.ToString();
            txtbairro.Text = dtgconsultausuarios.CurrentRow.Cells[4].Value.ToString();
            txtcodcidade.Text = dtgconsultausuarios.CurrentRow.Cells[5].Value.ToString();
            msktelefone.Text = dtgconsultausuarios.CurrentRow.Cells[6].Value.ToString();
            mskcelular.Text = dtgconsultausuarios.CurrentRow.Cells[7].Value.ToString();
            txtusuario.Text = dtgconsultausuarios.CurrentRow.Cells[8].Value.ToString();
            txtsenha.Text = dtgconsultausuarios.CurrentRow.Cells[9].Value.ToString();
            txtconfsenha.Text = dtgconsultausuarios.CurrentRow.Cells[9].Value.ToString();
            mskcep.Text = dtgconsultausuarios.CurrentRow.Cells[10].Value.ToString();
            txtemail.Text = dtgconsultausuarios.CurrentRow.Cells[11].Value.ToString();
            if (dtgconsultausuarios.CurrentRow.Cells[12].Value.ToString()=="GA")
            {
                rbGarcom.Checked = true;
            }
            if (dtgconsultausuarios.CurrentRow.Cells[12].Value.ToString() == "AD")
            {
                rbadministrador.Checked = true;
            }
            if (dtgconsultausuarios.CurrentRow.Cells[12].Value.ToString() == "CO")
            {
                rbComum.Checked = true;
            }
            if (dtgconsultausuarios.CurrentRow.Cells[12].Value.ToString() == "IN")
            {
                rbintermediario.Checked = true;
            }
            txtcidade.Text = dtgconsultausuarios.CurrentRow.Cells[14].Value.ToString();
            mskuf.Text = dtgconsultausuarios.CurrentRow.Cells[15].Value.ToString();

            if (dtgconsultausuarios.CurrentRow.Cells[13].Value.ToString() == "S")
            {
                rbnao.Checked = false;
                rbsim.Checked = true;
            }
            else
            {
                rbnao.Checked = true;
                rbsim.Checked = false;
            }

            tbUsuarios.SelectedTab = tcCadastrar;
        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            VisualizarUsuarios();
            //Mudar de TabPage
            this.tbUsuarios.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultausuarios.DataSource != null)
            {
                this.dtgconsultausuarios.DataSource = null;
            }
            else
            {
                this.dtgconsultausuarios.Rows.Clear();
            }
        }

        private void dtgconsultausuarios_DoubleClick(object sender, EventArgs e)
        {
            VisualizarUsuarios();
            //Mudar de TabPage
            this.tbUsuarios.SelectedTab = tcCadastrar;
            //Limpar o DataGridView ao mudar de TabPage
            if (this.dtgconsultausuarios.DataSource != null)
            {
                this.dtgconsultausuarios.DataSource = null;
            }
            else
            {
                this.dtgconsultausuarios.Rows.Clear();
            }
        }

        private void txtcodcidade_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadCidades cidades = new View.CadCidades();
                    cidades.ShowDialog();
                    txtcodcidade.Text = cidades.txtcodigocidade.Text;
                    break;

            }
        }

        private void txtcodcidade_Leave(object sender, EventArgs e)
        {
            DAL.CidadesDAL cidades = new DAL.CidadesDAL();
            if (txtcodcidade.Text.Contains("'"))
            {
                txtcodcidade.Text = txtcodcidade.Text.Replace("'", "");
            }
            txtcidade.Text = cidades.getCidades(Convert.ToInt32(txtcodcidade.Text)).Cidade;
            mskuf.Text = cidades.getCidades(Convert.ToInt32(txtcodcidade.Text)).UF;
            if (txtcidade.Text == string.Empty)
            {
                MessageBox.Show("Atenção: cidade inexistente","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void txtcodcidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
