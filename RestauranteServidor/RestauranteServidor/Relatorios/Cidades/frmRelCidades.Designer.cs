namespace RestauranteServidor.Relatorios.Cidades
{
    partial class frmRelCidades
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
            this.crPrintPreview.ShowTextSearchButton = false;
            this.crPrintPreview.Size = new System.Drawing.Size(860, 388);
            this.crPrintPreview.TabIndex = 0;
            this.crPrintPreview.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmRelCidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 388);
            this.Controls.Add(this.crPrintPreview);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelCidades";
            this.Text = "Relação de Cidades";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCidades_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crPrintPreview;

    }
}