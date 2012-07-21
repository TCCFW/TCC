namespace RestauranteServidor.View
{
    partial class CadGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadGrupo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsadicionar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tssalvar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tseditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsexcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tssair = new System.Windows.Forms.ToolStripButton();
            this.tbGrupos = new System.Windows.Forms.TabControl();
            this.tcCadastrar = new System.Windows.Forms.TabPage();
            this.txtcodigogrupo = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtgrupo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbnao = new System.Windows.Forms.RadioButton();
            this.rbsim = new System.Windows.Forms.RadioButton();
            this.tcConsultar = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbconsultatodos = new System.Windows.Forms.RadioButton();
            this.rbconsultanao = new System.Windows.Forms.RadioButton();
            this.rbconsultasim = new System.Windows.Forms.RadioButton();
            this.txtcodgrupoconsulta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnfinalizar = new System.Windows.Forms.Button();
            this.dtgconsultagrupos = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.txtgrupoconsulta = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbnomeconsulta = new System.Windows.Forms.RadioButton();
            this.rbcodconsulta = new System.Windows.Forms.RadioButton();
            this.toolStrip1.SuspendLayout();
            this.tbGrupos.SuspendLayout();
            this.tcCadastrar.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tcConsultar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgconsultagrupos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsadicionar,
            this.toolStripSeparator1,
            this.tssalvar,
            this.toolStripSeparator2,
            this.tseditar,
            this.toolStripSeparator5,
            this.tsCancelar,
            this.toolStripSeparator4,
            this.tsexcluir,
            this.toolStripSeparator3,
            this.tssair});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(813, 70);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsadicionar
            // 
            this.tsadicionar.Image = ((System.Drawing.Image)(resources.GetObject("tsadicionar.Image")));
            this.tsadicionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsadicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsadicionar.Name = "tsadicionar";
            this.tsadicionar.Size = new System.Drawing.Size(62, 67);
            this.tsadicionar.Text = "Adicionar";
            this.tsadicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsadicionar.Click += new System.EventHandler(this.tsadicionar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 70);
            // 
            // tssalvar
            // 
            this.tssalvar.Image = ((System.Drawing.Image)(resources.GetObject("tssalvar.Image")));
            this.tssalvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tssalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssalvar.Name = "tssalvar";
            this.tssalvar.Size = new System.Drawing.Size(52, 67);
            this.tssalvar.Text = "Salvar";
            this.tssalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tssalvar.Click += new System.EventHandler(this.tssalvar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 70);
            // 
            // tseditar
            // 
            this.tseditar.Image = ((System.Drawing.Image)(resources.GetObject("tseditar.Image")));
            this.tseditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tseditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tseditar.Name = "tseditar";
            this.tseditar.Size = new System.Drawing.Size(52, 67);
            this.tseditar.Text = "Editar";
            this.tseditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tseditar.Click += new System.EventHandler(this.tseditar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 70);
            // 
            // tsCancelar
            // 
            this.tsCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tsCancelar.Image")));
            this.tsCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCancelar.Name = "tsCancelar";
            this.tsCancelar.Size = new System.Drawing.Size(57, 67);
            this.tsCancelar.Text = "Cancelar";
            this.tsCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsCancelar.Click += new System.EventHandler(this.tsCancelar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 70);
            // 
            // tsexcluir
            // 
            this.tsexcluir.Image = ((System.Drawing.Image)(resources.GetObject("tsexcluir.Image")));
            this.tsexcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsexcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsexcluir.Name = "tsexcluir";
            this.tsexcluir.Size = new System.Drawing.Size(52, 67);
            this.tsexcluir.Text = "Excluir";
            this.tsexcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsexcluir.Click += new System.EventHandler(this.tsexcluir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 70);
            // 
            // tssair
            // 
            this.tssair.Image = ((System.Drawing.Image)(resources.GetObject("tssair.Image")));
            this.tssair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tssair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssair.Name = "tssair";
            this.tssair.Size = new System.Drawing.Size(52, 67);
            this.tssair.Text = "Sair";
            this.tssair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tssair.Click += new System.EventHandler(this.tssair_Click);
            // 
            // tbGrupos
            // 
            this.tbGrupos.Controls.Add(this.tcCadastrar);
            this.tbGrupos.Controls.Add(this.tcConsultar);
            this.tbGrupos.Location = new System.Drawing.Point(4, 73);
            this.tbGrupos.Name = "tbGrupos";
            this.tbGrupos.SelectedIndex = 0;
            this.tbGrupos.Size = new System.Drawing.Size(809, 337);
            this.tbGrupos.TabIndex = 3;
            // 
            // tcCadastrar
            // 
            this.tcCadastrar.BackColor = System.Drawing.SystemColors.Control;
            this.tcCadastrar.Controls.Add(this.txtcodigogrupo);
            this.tcCadastrar.Controls.Add(this.label28);
            this.tcCadastrar.Controls.Add(this.txtgrupo);
            this.tcCadastrar.Controls.Add(this.label7);
            this.tcCadastrar.Controls.Add(this.groupBox5);
            this.tcCadastrar.Location = new System.Drawing.Point(4, 22);
            this.tcCadastrar.Name = "tcCadastrar";
            this.tcCadastrar.Padding = new System.Windows.Forms.Padding(3);
            this.tcCadastrar.Size = new System.Drawing.Size(801, 311);
            this.tcCadastrar.TabIndex = 0;
            this.tcCadastrar.Text = "Cadastrar";
            // 
            // txtcodigogrupo
            // 
            this.txtcodigogrupo.BackColor = System.Drawing.SystemColors.Info;
            this.txtcodigogrupo.Location = new System.Drawing.Point(8, 37);
            this.txtcodigogrupo.MaxLength = 80;
            this.txtcodigogrupo.Name = "txtcodigogrupo";
            this.txtcodigogrupo.Size = new System.Drawing.Size(37, 20);
            this.txtcodigogrupo.TabIndex = 9;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(5, 21);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(40, 13);
            this.label28.TabIndex = 64;
            this.label28.Text = "Codigo";
            // 
            // txtgrupo
            // 
            this.txtgrupo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtgrupo.Location = new System.Drawing.Point(50, 37);
            this.txtgrupo.MaxLength = 80;
            this.txtgrupo.Name = "txtgrupo";
            this.txtgrupo.Size = new System.Drawing.Size(352, 20);
            this.txtgrupo.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Grupo";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbnao);
            this.groupBox5.Controls.Add(this.rbsim);
            this.groupBox5.Location = new System.Drawing.Point(417, 17);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(114, 40);
            this.groupBox5.TabIndex = 50;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Bloqueado";
            // 
            // rbnao
            // 
            this.rbnao.AutoSize = true;
            this.rbnao.Checked = true;
            this.rbnao.Location = new System.Drawing.Point(60, 20);
            this.rbnao.Name = "rbnao";
            this.rbnao.Size = new System.Drawing.Size(45, 17);
            this.rbnao.TabIndex = 15;
            this.rbnao.TabStop = true;
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
            // tcConsultar
            // 
            this.tcConsultar.BackColor = System.Drawing.SystemColors.Control;
            this.tcConsultar.Controls.Add(this.groupBox1);
            this.tcConsultar.Controls.Add(this.txtcodgrupoconsulta);
            this.tcConsultar.Controls.Add(this.label1);
            this.tcConsultar.Controls.Add(this.btnfinalizar);
            this.tcConsultar.Controls.Add(this.dtgconsultagrupos);
            this.tcConsultar.Controls.Add(this.label21);
            this.tcConsultar.Controls.Add(this.txtgrupoconsulta);
            this.tcConsultar.Controls.Add(this.groupBox2);
            this.tcConsultar.Location = new System.Drawing.Point(4, 22);
            this.tcConsultar.Name = "tcConsultar";
            this.tcConsultar.Padding = new System.Windows.Forms.Padding(3);
            this.tcConsultar.Size = new System.Drawing.Size(801, 311);
            this.tcConsultar.TabIndex = 1;
            this.tcConsultar.Text = "Consultar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbconsultatodos);
            this.groupBox1.Controls.Add(this.rbconsultanao);
            this.groupBox1.Controls.Add(this.rbconsultasim);
            this.groupBox1.Location = new System.Drawing.Point(156, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 39);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mostrar Bloqueados";
            // 
            // rbconsultatodos
            // 
            this.rbconsultatodos.AutoSize = true;
            this.rbconsultatodos.Checked = true;
            this.rbconsultatodos.Location = new System.Drawing.Point(114, 16);
            this.rbconsultatodos.Name = "rbconsultatodos";
            this.rbconsultatodos.Size = new System.Drawing.Size(55, 17);
            this.rbconsultatodos.TabIndex = 2;
            this.rbconsultatodos.TabStop = true;
            this.rbconsultatodos.Text = "Todos";
            this.rbconsultatodos.UseVisualStyleBackColor = true;
            // 
            // rbconsultanao
            // 
            this.rbconsultanao.AutoSize = true;
            this.rbconsultanao.Location = new System.Drawing.Point(63, 16);
            this.rbconsultanao.Name = "rbconsultanao";
            this.rbconsultanao.Size = new System.Drawing.Size(45, 17);
            this.rbconsultanao.TabIndex = 1;
            this.rbconsultanao.Text = "Não";
            this.rbconsultanao.UseVisualStyleBackColor = true;
            // 
            // rbconsultasim
            // 
            this.rbconsultasim.AutoSize = true;
            this.rbconsultasim.Location = new System.Drawing.Point(10, 16);
            this.rbconsultasim.Name = "rbconsultasim";
            this.rbconsultasim.Size = new System.Drawing.Size(42, 17);
            this.rbconsultasim.TabIndex = 0;
            this.rbconsultasim.Text = "Sim";
            this.rbconsultasim.UseVisualStyleBackColor = true;
            // 
            // txtcodgrupoconsulta
            // 
            this.txtcodgrupoconsulta.BackColor = System.Drawing.SystemColors.Info;
            this.txtcodgrupoconsulta.Location = new System.Drawing.Point(18, 76);
            this.txtcodgrupoconsulta.Name = "txtcodgrupoconsulta";
            this.txtcodgrupoconsulta.Size = new System.Drawing.Size(49, 20);
            this.txtcodgrupoconsulta.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Codigo";
            // 
            // btnfinalizar
            // 
            this.btnfinalizar.Location = new System.Drawing.Point(431, 73);
            this.btnfinalizar.Name = "btnfinalizar";
            this.btnfinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnfinalizar.TabIndex = 34;
            this.btnfinalizar.Text = "&Finalizar";
            this.btnfinalizar.UseVisualStyleBackColor = true;
            this.btnfinalizar.Click += new System.EventHandler(this.btnfinalizar_Click);
            // 
            // dtgconsultagrupos
            // 
            this.dtgconsultagrupos.AllowUserToAddRows = false;
            this.dtgconsultagrupos.AllowUserToDeleteRows = false;
            this.dtgconsultagrupos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgconsultagrupos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgconsultagrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgconsultagrupos.Location = new System.Drawing.Point(18, 102);
            this.dtgconsultagrupos.Name = "dtgconsultagrupos";
            this.dtgconsultagrupos.ReadOnly = true;
            this.dtgconsultagrupos.Size = new System.Drawing.Size(765, 197);
            this.dtgconsultagrupos.TabIndex = 33;
            this.dtgconsultagrupos.DoubleClick += new System.EventHandler(this.dtgconsultagrupos_DoubleClick);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(70, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(36, 13);
            this.label21.TabIndex = 30;
            this.label21.Text = "Grupo";
            // 
            // txtgrupoconsulta
            // 
            this.txtgrupoconsulta.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtgrupoconsulta.Location = new System.Drawing.Point(73, 76);
            this.txtgrupoconsulta.MaxLength = 40;
            this.txtgrupoconsulta.Name = "txtgrupoconsulta";
            this.txtgrupoconsulta.Size = new System.Drawing.Size(352, 20);
            this.txtgrupoconsulta.TabIndex = 28;
            this.txtgrupoconsulta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtgrupoconsulta_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbnomeconsulta);
            this.groupBox2.Controls.Add(this.rbcodconsulta);
            this.groupBox2.Location = new System.Drawing.Point(10, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 39);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordenar Por";
            // 
            // rbnomeconsulta
            // 
            this.rbnomeconsulta.AutoSize = true;
            this.rbnomeconsulta.Location = new System.Drawing.Point(71, 16);
            this.rbnomeconsulta.Name = "rbnomeconsulta";
            this.rbnomeconsulta.Size = new System.Drawing.Size(53, 17);
            this.rbnomeconsulta.TabIndex = 1;
            this.rbnomeconsulta.Text = "Nome";
            this.rbnomeconsulta.UseVisualStyleBackColor = true;
            // 
            // rbcodconsulta
            // 
            this.rbcodconsulta.AutoSize = true;
            this.rbcodconsulta.Checked = true;
            this.rbcodconsulta.Location = new System.Drawing.Point(7, 16);
            this.rbcodconsulta.Name = "rbcodconsulta";
            this.rbcodconsulta.Size = new System.Drawing.Size(58, 17);
            this.rbcodconsulta.TabIndex = 0;
            this.rbcodconsulta.TabStop = true;
            this.rbcodconsulta.Text = "Codigo";
            this.rbcodconsulta.UseVisualStyleBackColor = true;
            // 
            // CadGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 436);
            this.Controls.Add(this.tbGrupos);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(10, 45);
            this.Name = "CadGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cadastro de Grupos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadGrupo_FormClosing);
            this.Load += new System.EventHandler(this.CadGrupo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CadGrupo_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tbGrupos.ResumeLayout(false);
            this.tcCadastrar.ResumeLayout(false);
            this.tcCadastrar.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tcConsultar.ResumeLayout(false);
            this.tcConsultar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgconsultagrupos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsadicionar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tssalvar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tseditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsexcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tssair;
        private System.Windows.Forms.TabControl tbGrupos;
        private System.Windows.Forms.TabPage tcCadastrar;
        public System.Windows.Forms.TextBox txtcodigogrupo;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtgrupo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbnao;
        private System.Windows.Forms.RadioButton rbsim;
        private System.Windows.Forms.TabPage tcConsultar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbconsultatodos;
        private System.Windows.Forms.RadioButton rbconsultanao;
        private System.Windows.Forms.RadioButton rbconsultasim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnfinalizar;
        private System.Windows.Forms.DataGridView dtgconsultagrupos;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtgrupoconsulta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbnomeconsulta;
        private System.Windows.Forms.RadioButton rbcodconsulta;
        public System.Windows.Forms.TextBox txtcodgrupoconsulta;
    }
}