using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Referencias do Crystal Report
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace RestauranteServidor.Relatorios.Fornecedores
{
    public partial class FiltroRelFornecedores : Form
    {
        public FiltroRelFornecedores()
        {
            InitializeComponent();
        }

        private void gerarRelatorio_Click(object sender, EventArgs e)
        {
            Model.FornecedorModel fornecedor = new Model.FornecedorModel();
            if ((txtfornecedorconsulta.Text != string.Empty) || (chkTodos.Checked == true))
            {

            if (txtcodigo.Text != string.Empty)
            {
                fornecedor.Codigo = Convert.ToInt32 (txtcodigo.Text);
            }
            if ((rbnao.Checked == false) && (rbsim.Checked == true))
            {
                fornecedor.Bloqueado = "S";
            }
            if ((rbnao.Checked == true) && (rbsim.Checked == false))
            {
                fornecedor.Bloqueado = "N";
            }
            if(rbTodos.Checked == true)
            {
                fornecedor.Bloqueado = "T";
            }
            if (chkTodos.Checked == true)
            {
                fornecedor.Codigo = 0;
            }

            
                RelatorioFornecedores(fornecedor);
            }
            else
            {
                MessageBox.Show("Informe o fornecedor antes de gerar o relatorio","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RelatorioFornecedores(Model.FornecedorModel fornecedor)
        {
            ReportDocument crReportDocument = new ReportDocument();
            Relatorios.Fornecedores.frmRelFornecedores frmrelatorio = new Relatorios.Fornecedores.frmRelFornecedores();
            DAL.FornecedorDAL fornecedoresDAL = new DAL.FornecedorDAL();
            try
            {
                crReportDocument.Load(@"C:\Repositorio TCC\Servidor Desktop\RestauranteServidor\RestauranteServidor\Relatorios\Fornecedores\rptRelFornecedores.rpt");
                crReportDocument.SetDataSource(fornecedoresDAL.dtRelFornecedores(fornecedor));
                frmrelatorio.crPrintPreview.ReportSource = crReportDocument;
                frmrelatorio.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtcodigo_Leave(object sender, EventArgs e)
        {
            DAL.FornecedorDAL fornecedor = new DAL.FornecedorDAL();
            if (txtcodigo.Text.Contains("'"))
            {
                txtcodigo.Text = txtcodigo.Text.Replace("'", "");
            }
            txtfornecedorconsulta.Text = fornecedor.getFornecedores(Convert.ToInt32(txtcodigo.Text)).Razao;
        }

        private void txtcodigo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadFornecedor fornecedor = new View.CadFornecedor();
                    fornecedor.ShowDialog();
                    txtcodigo.Text = fornecedor.txtcodigo.Text;
                    break;
            }
        }

        private void FiltroRelFornecedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
