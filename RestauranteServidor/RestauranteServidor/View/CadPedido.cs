using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestauranteServidor.View
{
    public partial class CadPedido : Form
    {
        private bool Modificar = false;
        private bool Adicionar = true;
        private int Reg_Atual = 0;
        private int salvanovo = 0;
        private string codigoPedido;

        public String CodigoPedido()
        {
            if (codigoPedido != string.Empty)
            {
                codigoPedido = txtcodigo.Text;
                return codigoPedido;
            }
            else
            {
                return null;
            }
        }

        public CadPedido()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            mskdtabertura.Clear();
            mskdtfechamento.Clear();
            rbaberto.Checked = true;
            txtcodgarcom.Clear();
            txtcodigo.Clear();
            txtcodmesa.Clear();
            txtcodigo.Clear();
            txtvalorpedido.Clear();
            txtcomissao.Clear();
            txtmesa.Clear();
            txtgarcom.Clear();
        }

        private void BloquearCampos()
        {
            mskdtabertura.Enabled = false;
            mskdtfechamento.Enabled = false;
            rbaberto.Enabled = false;
            rbcancelado.Enabled = false;
            rbfinalizado.Enabled = false;
            txtcodgarcom.Enabled = false;
            txtcodigo.Enabled = false;
            txtcodmesa.Enabled = false;
            txtcodigo.Enabled = false;
            txtvalorpedido.Enabled = false;
            txtcomissao.Enabled = false;
            txtmesa.Enabled = false;
        }

        private void DesbloquearCampos()
        {
            rbaberto.Enabled = true;
            rbcancelado.Enabled = true;
            rbfinalizado.Enabled = true;
            txtcodgarcom.Enabled = true;
            txtcodmesa.Enabled = true;
        }

        public void RecebeUltimoPedido(int codigo)
        {
            DAL.PedidoDAL pedidos = new DAL.PedidoDAL();
            txtcodigo.Text = pedidos.getPedidos(codigo).Codigo.ToString();
            txtcodmesa.Text = pedidos.getPedidos(codigo).Mesa.ToString();
            txtcomissao.Text = pedidos.getPedidos(codigo).Vlrcomissao.ToString();
            txtgarcom.Text = pedidos.getPedidos(codigo).Desusuario;
            txtmesa.Text = pedidos.getPedidos(codigo).Desmesa;
            txtcodgarcom.Text = pedidos.getPedidos(codigo).Garcom.ToString();
            txtvalorpedido.Text = pedidos.getPedidos(codigo).Valor.ToString();
            if (pedidos.getPedidos(codigo).Databertura.ToString() == null)
            {
                mskdtabertura.Text = "00/00/0000 00:00";
            }
            else
            {
                mskdtabertura.Text = pedidos.getPedidos(codigo).Databertura.ToString();
            }
            
            if (pedidos.getPedidos(codigo).Status == "AB")
            {
                rbaberto.Checked = true;
            }
            if (pedidos.getPedidos(codigo).Status == "CA")
            {
                rbcancelado.Checked = true;
                mskdtfechamento.Text = pedidos.getPedidos(codigo).Data_fechamento.ToString();
            }
            if (pedidos.getPedidos(codigo).Status == "FI")
            {
                rbfinalizado.Checked = true;
                mskdtfechamento.Text = pedidos.getPedidos(codigo).Data_fechamento.ToString();
            }
            
        }

        private void salvarPedidos()
        {
            BLL.PedidosBLL pedidosBLL = new BLL.PedidosBLL();
            Model.PedidoModel pedidosModel = new Model.PedidoModel();

            if ((txtmesa.Text == string.Empty))
            {
                MessageBox.Show("Informe uma mesa válida","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtgarcom.Text == String.Empty)
            {
                MessageBox.Show("Informe um usuário válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            pedidosModel.Databertura = DateTime.Now;
            pedidosModel.Data_fechamento = DateTime.Now;
            pedidosModel.Garcom = int.Parse(txtcodgarcom.Text);
            pedidosModel.Mesa = int.Parse(txtcodmesa.Text);
            
            if (txtvalorpedido.Text != string.Empty)
            {
                pedidosModel.Valor = Decimal.Parse(txtvalorpedido.Text);
            }
            else
            {
                pedidosModel.Valor = 0;
            }
            if (txtcomissao.Text != string.Empty)
            {
                pedidosModel.Vlrcomissao = Decimal.Parse(txtcomissao.Text);
            }
            else
            {
                pedidosModel.Vlrcomissao = 0;
            }

            if(rbaberto.Checked == true)
            {
                pedidosModel.Status = "AB";
                mskdtfechamento.Clear();
            }
            if (rbcancelado.Checked == true)
            {
                pedidosModel.Status = "CA";
                pedidosModel.Data_fechamento = DateTime.Now;
            }
            if(rbfinalizado.Checked == true)
            {
                pedidosModel.Status = "FI";
                pedidosModel.Data_fechamento = DateTime.Now;
            }

            if (Modificar == false)
            {
                pedidosBLL.IncluirPedidos(pedidosModel);
            }
            else
            {
                pedidosModel.Codigo = Convert.ToInt32(txtcodigo.Text);
                pedidosBLL.AlterarPedidos(pedidosModel);
            }
            MessageBox.Show("Dados Gravados com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtcodigousuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void CadPedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CadPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tssalvar.Enabled == true)
            {
                if (MessageBox.Show("Tem certeza que deseja sair?\nAs informações alteradas não serão salvas", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void tssair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CadPedido_Load(object sender, EventArgs e)
        {
            BloquearCampos();
            tsadicionar.Enabled = true;
            tseditar.Enabled = true;
            tsexcluir.Enabled = true;
            tsPedidos.Enabled = true;
            tssair.Enabled = true;
            tssalvar.Enabled = false;
            tsCancelar.Enabled = false;
            txtmesa.Focus();
            RecebeUltimoPedido(Reg_Atual);
            if (txtmesa.Text == string.Empty)
            {
                mskdtabertura.Clear();
            }
        }

        private void txtcodmesa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtcodgarcom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtcodmesa_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadMesas mesas = new View.CadMesas();
                    mesas.ShowDialog();
                    txtcodmesa.Text = mesas.txtcodigomesa.Text;
                    break;
            }
        }

        private void txtcodmesa_Leave(object sender, EventArgs e)
        {
            DAL.MesasDAL mesas = new DAL.MesasDAL();
            if (txtcodmesa.Text.Contains("'"))
            {
                txtcodmesa.Text = txtcodmesa.Text.Replace("'", "");
            }
            if (txtcodmesa.Text != string.Empty)
            {
                txtmesa.Text = mesas.getMesas(Convert.ToInt32(txtcodmesa.Text)).Mesa;
            }
        }

        private void txtcodgarcom_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadUsuario usuarios = new View.CadUsuario();
                    usuarios.ShowDialog();
                    txtcodgarcom.Text = usuarios.txtcodigousuario.Text;
                    break;
            }
        }

        private void txtcodgarcom_Leave(object sender, EventArgs e)
        {
            DAL.UsuarioDAL usuarios = new DAL.UsuarioDAL();
            if (txtcodgarcom.Text.Contains("'"))
            {
                txtcodgarcom.Text = txtcodgarcom.Text.Replace("'", "");
            }
            if (txtcodgarcom.Text != string.Empty)
            {
                txtgarcom.Text = usuarios.getUsuarios(Convert.ToInt32(txtcodgarcom.Text)).Usuario;
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
            tsPedidos.Enabled = false;
            tssair.Enabled = false;
            tssalvar.Enabled = true;
            tsCancelar.Enabled = true;
            mskdtabertura.Text = DateTime.Now.ToString();
            tbPedidos.SelectedTab = tcCadastrar;
            DesbloquearCampos();
        }

        private void tssalvar_Click(object sender, EventArgs e)
        {
            salvanovo++;
            salvarPedidos();
            tsadicionar.Enabled = true;
            tseditar.Enabled = true;
            tsexcluir.Enabled = true;
            tsPedidos.Enabled = true;
            tssair.Enabled = true;
            tssalvar.Enabled = false;
            tsCancelar.Enabled = false;
            Modificar = false;
            BloquearCampos();
            if (salvanovo == 2)
            {
                RecebeUltimoPedido(0);
            }
            else
            {
                RecebeUltimoPedido(Reg_Atual);
            }
            salvanovo = 0;
        }

        private void tsCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja cancelar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                BloquearCampos();
                tsadicionar.Enabled = true;
                tseditar.Enabled = true;
                tsPedidos.Enabled = true;
                tsexcluir.Enabled = true;
                tssair.Enabled = true;
                tssalvar.Enabled = false;
                tsCancelar.Enabled = false;
                if (txtcodigo.Text == string.Empty)
                {
                    RecebeUltimoPedido(Reg_Atual);
                }
                salvanovo = 0;
            }
        }

        private void tsexcluir_Click(object sender, EventArgs e)
        {
            BLL.PedidosBLL pedidosBLL = new BLL.PedidosBLL();
            Model.PedidoModel pedidosModel = new Model.PedidoModel();
            if (txtcodigo.Text == String.Empty)
            {
                MessageBox.Show("Selecione o pedido que deseja excluir", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                pedidosModel.Codigo = Convert.ToInt32(txtcodigo.Text);
                if (MessageBox.Show("Tem certeza que deseja excluir o pedido codigo " + txtcodigo.Text + "?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    pedidosBLL.ExcluirPedidos(pedidosModel);
                    MessageBox.Show("Pedido excluído com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RecebeUltimoPedido(0);
                }
                else
                {
                    tsCancelar.Enabled = false;
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
            tsPedidos.Enabled = false;
            tssair.Enabled = false;
            tssalvar.Enabled = true;
            tsCancelar.Enabled = true;
            DesbloquearCampos();
            Modificar = true;
        }

        private void tsPedidos_Click(object sender, EventArgs e)
        {
            if (txtmesa.Text != string.Empty)
            {
                View.CadItems itens = new CadItems();
                itens.CodigoPedido = int.Parse(txtcodigo.Text);
                itens.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Informe os dados do pedido antes de lançar os itens","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
        }
    }
}
