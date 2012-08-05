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

namespace RestauranteServidor.Relatorios.Cidades
{
    public partial class FiltroRelCidades : Form
    {
        public FiltroRelCidades()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.CidadeModel cidades = new Model.CidadeModel();
            if ((txtcidadeconsulta.Text != string.Empty) || (chkTodos.Checked == true))
            {

            if (txtcodigo.Text != string.Empty)
            {
                cidades.Codigo = Convert.ToInt32 (txtcodigo.Text);
            }
            if ((rbnao.Checked == false) && (rbsim.Checked == true))
            {
                cidades.Bloqueado = "S";
            }
            if ((rbnao.Checked == true) && (rbsim.Checked == false))
            {
                cidades.Bloqueado = "N";
            }
            if(rbTodos.Checked == true)
            {
                cidades.Bloqueado = "T";
            }
            if (chkTodos.Checked == true)
            {
                cidades.Codigo = 0;
            }
            RelatorioCidades(cidades);

            }
            else
            {
                MessageBox.Show("Informe a cidade antes de gerar o relatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RelatorioCidades(Model.CidadeModel cidades)
        {
            ReportDocument crReportDocument = new ReportDocument();
            Relatorios.Cidades.frmRelCidades frmrelatorio = new Relatorios.Cidades.frmRelCidades();
            DAL.CidadesDAL cidadesDAL = new DAL.CidadesDAL();
            try
            {
                crReportDocument.Load(@"C:\Repositorio TCC\Servidor Desktop\RestauranteServidor\RestauranteServidor\Relatorios\Cidades\rptCidades.rpt");
                crReportDocument.SetDataSource(cidadesDAL.dtRelCidades(cidades));
                frmrelatorio.crPrintPreview.ReportSource = crReportDocument;
                frmrelatorio.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbUF_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void FiltroRelCidades_Load(object sender, EventArgs e)
        {
            txtcodigo.Focus();
        }

        private void txtcodigo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    View.CadCidades cidades = new View.CadCidades();
                    cidades.ShowDialog();
                    txtcodigo.Text = cidades.txtcodigocidade.Text;
                    break;

            }
        }

        private void txtcodigo_Leave(object sender, EventArgs e)
        {
            DAL.CidadesDAL cidades = new DAL.CidadesDAL();
            if (txtcodigo.Text.Contains("'"))
            {
                txtcodigo.Text = txtcodigo.Text.Replace("'", "");
            }
            txtcidadeconsulta.Text = cidades.getCidades(Convert.ToInt32(txtcodigo.Text)).Cidade;
            mskuf.Text = cidades.getCidades(Convert.ToInt32(txtcodigo.Text)).UF;
        }

        private void FiltroRelCidades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
