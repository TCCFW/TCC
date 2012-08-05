namespace RestauranteServidor.Relatorios.Cidades
{
    partial class FiltroRelCidades
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
            this.gerarRelatorio = new System.Windows.Forms.Button();
            this.txtcidadeconsulta = new System.Windows.Forms.TextBox();
            this.mskuf = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbnao = new System.Windows.Forms.RadioButton();
            this.rbsim = new System.Windows.Forms.RadioButton();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // gerarRelatorio
            // 
            this.gerarRelatorio.Location = new System.Drawing.Point(213, 66);
            this.gerarRelatorio.Name = "gerarRelatorio";
            this.gerarRelatorio.Size = new System.Drawing.Size(93, 23);
            this.gerarRelatorio.TabIndex = 0;
            this.gerarRelatorio.Text = "Gerar Relatorio";
            this.gerarRelatorio.UseVisualStyleBackColor = true;
            this.gerarRelatorio.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtcidadeconsulta
            // 
            this.txtcidadeconsulta.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtcidadeconsulta.Enabled = false;
            this.txtcidadeconsulta.Location = new System.Drawing.Point(53, 29);
            this.txtcidadeconsulta.MaxLength = 80;
            this.txtcidadeconsulta.Name = "txtcidadeconsulta";
            this.txtcidadeconsulta.Size = new System.Drawing.Size(215, 20);
            this.txtcidadeconsulta.TabIndex = 69;
            // 
            // mskuf
            // 
            this.mskuf.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mskuf.Enabled = false;
            this.mskuf.Location = new System.Drawing.Point(274, 29);
            this.mskuf.Mask = "AA";
            this.mskuf.Name = "mskuf";
            this.mskuf.Size = new System.Drawing.Size(32, 20);
            this.mskuf.TabIndex = 70;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(271, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "UF";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Cidade";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbTodos);
            this.groupBox5.Controls.Add(this.rbnao);
            this.groupBox5.Controls.Add(this.rbsim);
            this.groupBox5.Location = new System.Drawing.Point(312, 9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(164, 40);
            this.groupBox5.TabIndex = 66;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Bloqueado";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(107, 19);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(55, 17);
            this.rbTodos.TabIndex = 16;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbnao
            // 
            this.rbnao.AutoSize = true;
            this.rbnao.Location = new System.Drawing.Point(60, 20);
            this.rbnao.Name = "rbnao";
            this.rbnao.Size = new System.Drawing.Size(45, 17);
            this.rbnao.TabIndex = 15;
            this.rbnao.Text = "Não";
            this.rbnao.UseVisualStyleBackColor = true;
            // 
            // rbsim
            // 
            this.rbsim.AutoSize = true;
            this.rbsim.Location = new System.Drawing.Point(10, 19);
            this.rbsim.Name = "rbsim";
            this.rbsim.Size = new System.Drawing.Size(42, 17);
            this.rbsim.TabIndex = 2;
            this.rbsim.Text = "Sim";
            this.rbsim.UseVisualStyleBackColor = true;
            // 
            // txtcodigo
            // 
            this.txtcodigo.BackColor = System.Drawing.SystemColors.Info;
            this.txtcodigo.Location = new System.Drawing.Point(7, 29);
            this.txtcodigo.MaxLength = 80;
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(40, 20);
            this.txtcodigo.TabIndex = 72;
            this.txtcodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodigo_KeyDown);
            this.txtcodigo.Leave += new System.EventHandler(this.txtcodigo_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 81;
            this.label2.Text = "F10 - CONSULTAR";
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(212, 9);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(56, 17);
            this.chkTodos.TabIndex = 82;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            // 
            // FiltroRelCidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 132);
            this.Controls.Add(this.chkTodos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcidadeconsulta);
            this.Controls.Add(this.mskuf);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gerarRelatorio);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(10, 70);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FiltroRelCidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Gerar Relatorio de Cidades";
            this.Load += new System.EventHandler(this.FiltroRelCidades_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FiltroRelCidades_KeyDown);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gerarRelatorio;
        private System.Windows.Forms.TextBox txtcidadeconsulta;
        private System.Windows.Forms.MaskedTextBox mskuf;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbnao;
        private System.Windows.Forms.RadioButton rbsim;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTodos;
    }
}