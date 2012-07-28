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
//Referencia da String de Conexão
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RestauranteServidor.Relatorios.Cidades
{
    public partial class frmRelCidades : Form
    {
        string Strconexao = @"Server = .\sqlexpress;Database=restaurante; Integrated Security = SSPI;";
        public frmRelCidades()
        {
            InitializeComponent();
        }

        private void frmCidades_Load(object sender, EventArgs e)
        {

        }

        private void RelatorioCidades()
        {
            ReportDocument crReportDocument = new ReportDocument();

            SqlConnection oConn = new SqlConnection();
            dsCidades oDataset = new dsCidades();
            Relatorios.Cidades.frmRelCidades frmrelatorio = new Relatorios.Cidades.frmRelCidades();
            string consulta = "SELECT codigo AS CODIGO, cidade AS CIDADE, uf AS UF FROM cidades";

            try
            {
                oConn.ConnectionString = Strconexao;
                oConn.Open();
                

                SqlDataAdapter Oda = new SqlDataAdapter(consulta, oConn);
                Oda.Fill(oDataset, "cidades");
                crReportDocument.Load(@"C:\Repositorio TCC\Servidor Desktop\RestauranteServidor\RestauranteServidor\Relatorios\Cidades\rptCidades.rpt");
                crReportDocument.SetDataSource(oDataset);
                //frmrelatorio.crPrintPreview.DisplayGroupTree = false;
                frmrelatorio.crPrintPreview.ReportSource = crReportDocument;
                frmrelatorio.ShowDialog();
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                oConn.Close();
                oDataset.Dispose();
            }
        }
    }
}
