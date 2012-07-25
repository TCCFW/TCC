using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RestauranteServidor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.CadFornecedor cadFornecedor = new View.CadFornecedor();
            cadFornecedor.ShowDialog();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.CadCidades cidades = new View.CadCidades();
            cidades.ShowDialog();
        }

        private void grupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.CadGrupo grupo = new View.CadGrupo();
            grupo.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.CadSubGrupo subGrupo = new View.CadSubGrupo();
            subGrupo.ShowDialog();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            View.CadProdutos produtos = new View.CadProdutos();
            produtos.ShowDialog();
        }

        private void relatorioCidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.Cidades.FiltroRelCidades relatorio = new Relatorios.Cidades.FiltroRelCidades();
            relatorio.Show();
        }

        private void relatórioDeFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.Fornecedores.FiltroRelFornecedores fornecedores = new Relatorios.Fornecedores.FiltroRelFornecedores();
            fornecedores.ShowDialog();
        }

        private void relatorioDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.Produtos.FiltroRelProdutos produtos = new Relatorios.Produtos.FiltroRelProdutos();
            produtos.ShowDialog();
        }
    }
}
