namespace RestauranteServidor.Relatorios.Fornecedores
{
    partial class frmRelFornecedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crPrintPreview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crPrintPreview
            // 
            this.crPrintPreview.ActiveViewIndex = -1;
            this.crPrintPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crPrintPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.crPrintPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crPrintPreview.Location = new System.Drawing.Point(0, 0);
            this.crPrintPreview.Name = "crPrintPreview";
            this.crPrintPreview.ShowCloseButton = false;
            this.crPrintPreview.ShowGroupTreeButton = false;
            this.crPrintPreview.ShowParameterPanelButton = false;
            this.crPrintPreview.ShowRefreshButton = false;
            this.crPrintPreview.Size = new System.Drawing.Size(742, 314);
            this.crPrintPreview.TabIndex = 0;
            this.crPrintPreview.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmRelFornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 314);
            this.Controls.Add(this.crPrintPreview);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelFornecedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relação de Fornecedores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crPrintPreview;

    }
}