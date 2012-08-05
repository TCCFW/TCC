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
    public partial class CadItems : Form
    {

        private bool Modificar = false;
        private bool Adicionar = true;
        private int Reg_Atual = 0;
        private int salvanovo = 0;
        private int codigoPedido = 0;

        public int CodigoPedido
        {
            get { return codigoPedido; }
            set { codigoPedido = value; }
        }

        public CadItems()
        {
            InitializeComponent();
        }

        private void LimparCampos()
        {
            mskdtabitem.Clear();
            mskdtfechaitem.Clear();
            rbaberto.Checked = true;
            txtcodproduto.Clear();
            txtcomplemento.Clear();
            txtcomplemento.Clear();
            txtvaloritem.Clear();
            txtunidade.Clear();
            txtdescproduto.Clear();
        }

        private void BloquearCampos()
        {
            mskdtabitem.Enabled = false;
            mskdtfechaitem.Enabled = false;
            mskdtabitem.Enabled = false;
            rbaberto.Enabled = false;
            rbcancelado.Enabled = false;
            rbfinalizado.Enabled = false;
            rbAndamento.Enabled = false;
            txtcodproduto.Enabled = false;
            txtcomplemento.Enabled = false;
            txtvaloritem.Enabled = false;
            txtunidade.Enabled = false;
        }

        private void DesbloquearCampos()
        {
            rbcancelado.Enabled = true;
            rbfinalizado.Enabled = true;
            rbAndamento.Enabled = true;
            rbaberto.Enabled = true;
            txtcodproduto.Enabled = true;
            txtcomplemento.Enabled = true;
            txtvaloritem.Enabled = true;
            txtunidade.Enabled = true;
        }

        private void CadItems_Load(object sender, EventArgs e)
        {
            BloquearCampos();
            tsadicionar.Enabled = true;
            tseditar.Enabled = true;
            tsexcluir.Enabled = true;
            tssair.Enabled = true;
            tssalvar.Enabled = false;
            tsCancelar.Enabled = false;
            txtcodproduto.Focus();
            BLL.ItensPedidos itensBLL = new BLL.ItensPedidos();
            dtgItens.DataSource = itensBLL.getItensDT();
            dtgItens.Columns[5].Visible = false;
            dtgItens.Columns[6].Visible = false;
            dtgItens.Columns[7].Visible = false;
            dtgItens.Columns[8].Visible = false;
            dtgItens.Columns[1].Width = 300;
            dtgItens.Columns[2].Width = 300;
            //dtgItens.Columns[0].Visible = false;
        }

        private void tssair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtcodproduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtcodproduto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadProdutos produtos = new View.CadProdutos();
                    produtos.ShowDialog();
                    txtcodproduto.Text = produtos.txtcodProduto.Text;
                    break;
            }
        }

        private void txtcodproduto_Leave(object sender, EventArgs e)
        {
            DAL.ProdutosDAL produtos = new DAL.ProdutosDAL();
            CadProdutos cadprodutos = new CadProdutos();
            if (txtcodproduto.Text != string.Empty)
            {
                if (produtos.getProdutos(Convert.ToInt32(txtcodproduto.Text)).Codigo == txtcodproduto.Text)
                {
                    txtdescproduto.Text = produtos.getProdutos(Convert.ToInt32(txtcodproduto.Text)).Descricao;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void CadItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CadItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tssalvar.Enabled == true)
            {
                if (MessageBox.Show("Tem certeza que deseja sair?\nAs informações alteradas não serão salvas", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void tsadicionar_Click(object sender, EventArgs e)
        {
            DAL.PedidoDAL pedidos = new DAL.PedidoDAL();
            if ((pedidos.getPedidos(CodigoPedido).Status == "AB") || (pedidos.getPedidos(CodigoPedido).Status == "AN"))
            {
                Adicionar = false;
                salvanovo++;
                if (txtcodproduto.Text != string.Empty)
                {
                    Reg_Atual = Convert.ToInt32(txtcodproduto.Text);
                }
                LimparCampos();
                tsadicionar.Enabled = false;
                tseditar.Enabled = false;
                tsexcluir.Enabled = false;
                tssair.Enabled = false;
                tssalvar.Enabled = true;
                tsCancelar.Enabled = true;
                mskdtabitem.Text = DateTime.Now.ToString();
                tbItens.SelectedTab = tcCadastrar;
                DesbloquearCampos();
            }
            else
            {
                MessageBox.Show("Pedido Cancelado ou Finalizado\nNão é possível lançar novos itens","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
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
                salvanovo = 0;
            }
        }

        private void tseditar_Click(object sender, EventArgs e)
        {
            if ((dtgItens.CurrentRow.Cells[8].Value.ToString() == "AB") || (dtgItens.CurrentRow.Cells[8].Value.ToString() == "AN"))
            {
                tsadicionar.Enabled = false;
                tseditar.Enabled = false;
                tsexcluir.Enabled = false;
                tssair.Enabled = false;
                tssalvar.Enabled = true;
                tsCancelar.Enabled = true;
                DesbloquearCampos();
                Modificar = true;
            }
            else
            {
              MessageBox.Show("Item cancelado ou finalizado\nNão é possivel realizar alterações", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsexcluir_Click(object sender, EventArgs e)
        {
            BLL.ItensPedidos itenspedidosBLL = new BLL.ItensPedidos();
            Model.ItemPedidoModel itensModel = new Model.ItemPedidoModel();
            if (txtcodproduto.Text == String.Empty)
            {
                MessageBox.Show("Selecione o produto que deseja excluir", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (CodigoPedido != 0)
                {
                    itensModel.Codigo = CodigoPedido;
                    if (MessageBox.Show("Tem certeza que deseja excluir o produto codigo " + txtcodproduto.Text + "?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        itenspedidosBLL.ExcluirItens(itensModel);
                        MessageBox.Show("Produto excluído com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //RecebeUltimoPedido(0);

                        LimparCampos();
                        dtgItens.DataSource = itenspedidosBLL.getItensDT();
                        dtgItens.Columns[5].Visible = false;
                        dtgItens.Columns[6].Visible = false;
                        dtgItens.Columns[7].Visible = false;
                        dtgItens.Columns[8].Visible = false;
                        dtgItens.Columns[1].Width = 300;
                        dtgItens.Columns[2].Width = 300;
                    }
                }
                if (CodigoPedido == 0)
                {
                    MessageBox.Show("Selecione o produto que deseja excluir", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tsCancelar.Enabled = false;
                }
            }
        }

        private void tssalvar_Click(object sender, EventArgs e)
        {
            salvanovo++;
            salvarItens();
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
                //RecebeUltimoItem(0);
            }
            else
            {
                //RecebeUltimoItem(Reg_Atual);
            }
            salvanovo = 0;

        }

        private void VisualizarItensCampos()
        {
            txtcodproduto.Text = dtgItens.CurrentRow.Cells[1].Value.ToString();
            txtdescproduto.Text = dtgItens.CurrentRow.Cells[2].Value.ToString();
            txtcomplemento.Text = dtgItens.CurrentRow.Cells[3].Value.ToString();
            txtunidade.Text = dtgItens.CurrentRow.Cells[4].Value.ToString();
            txtvaloritem.Text = dtgItens.CurrentRow.Cells[5].Value.ToString();
            mskdtabitem.Text = dtgItens.CurrentRow.Cells[7].Value.ToString();
            mskdtfechaitem.Text = dtgItens.CurrentRow.Cells[8].Value.ToString();
            if (dtgItens.CurrentRow.Cells[0].Value.ToString() == "AB")
            {
                rbaberto.Checked = true;
            }
            if (dtgItens.CurrentRow.Cells[0].Value.ToString() == "AN")
            {
                rbAndamento.Checked = true;
            }
            if (dtgItens.CurrentRow.Cells[0].Value.ToString() == "CA")
            {
                rbcancelado.Checked = true;
            }
            if (dtgItens.CurrentRow.Cells[0].Value.ToString() == "FI")
            {
                rbfinalizado.Checked = true;
            }
        }

        private void salvarItens()
        {
            BLL.ItensPedidos itensBLL = new BLL.ItensPedidos();
            Model.ItemPedidoModel itensModel = new Model.ItemPedidoModel();

            itensModel.Produto = txtcodproduto.Text;
            itensModel.Qtd = Convert.ToInt32(txtunidade.Text);
            itensModel.HoraAbertura = Convert.ToDateTime(mskdtabitem.Text);
            itensModel.Complemento = txtcomplemento.Text;
            itensModel.Pedido = CodigoPedido;
            itensModel.Valor = Convert.ToDecimal(txtvaloritem.Text);

            if ((rbaberto.Checked == true) && (rbAndamento.Checked == false) && (rbcancelado.Checked == false) && (rbfinalizado.Checked == false))
            {
                itensModel.Status = "AB";
                mskdtfechaitem.Clear();
            }

            if ((rbaberto.Checked == false) && (rbAndamento.Checked == true) && (rbcancelado.Checked == false) && (rbfinalizado.Checked == false))
            {
                itensModel.Status = "AN";
                mskdtfechaitem.Clear();
            }

            if ((rbaberto.Checked == false) && (rbAndamento.Checked == false) && (rbcancelado.Checked == true) && (rbfinalizado.Checked == false))
            {
                itensModel.Status = "CA";
                mskdtfechaitem.Text = DateTime.Now.ToString();
                itensModel.Horafechamento = Convert.ToDateTime(mskdtfechaitem.Text);
                MessageBox.Show("Item cancelado com sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if ((rbaberto.Checked == false) && (rbAndamento.Checked == false) && (rbcancelado.Checked == false) && (rbfinalizado.Checked == true))
            {
                itensModel.Status = "FI";
                mskdtfechaitem.Text = DateTime.Now.ToString();
                itensModel.Horafechamento = Convert.ToDateTime(mskdtfechaitem.Text);
                MessageBox.Show("Item finalizado com sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (Modificar == false)
            {
                itensBLL.IncluirItens(itensModel);
            }
            else
            {
                if (dtgItens.CurrentRow.Cells[5].Value.ToString() != null)
                {
                    itensModel.Codigo = int.Parse(dtgItens.CurrentRow.Cells[5].Value.ToString());
                    itensBLL.AlterarItens(itensModel);
                }
                else
                {
                    MessageBox.Show("Informe o codigo do item", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            MessageBox.Show("Dados Gravados com Sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dtgItens.DataSource = itensBLL.getItensDT();
        }

        private void dtgItens_DoubleClick(object sender, EventArgs e)
        {
            VisualizarItensCampos();
        }

        private void dtgItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dtgItens.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            if (e.Value != null && e.Value.Equals("CA"))
            {
                dtgItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
            if (e.Value != null && e.Value.Equals("FI"))
            {
                dtgItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
            }

        }
    }
}
