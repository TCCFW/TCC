namespace RestauranteServidor.View
{
    partial class CadItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadItems));
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
            this.tbItens = new System.Windows.Forms.TabControl();
            this.tcCadastrar = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtcomplemento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.dtgItens = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbAndamento = new System.Windows.Forms.RadioButton();
            this.rbcancelado = new System.Windows.Forms.RadioButton();
            this.rbfinalizado = new System.Windows.Forms.RadioButton();
            this.rbaberto = new System.Windows.Forms.RadioButton();
            this.txtunidade = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mskdtfechaitem = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mskdtabitem = new System.Windows.Forms.MaskedTextBox();
            this.txtcodproduto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdescproduto = new System.Windows.Forms.TextBox();
            this.txtvaloritem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tcConsultar = new System.Windows.Forms.TabPage();
            this.toolStrip1.SuspendLayout();
            this.tbItens.SuspendLayout();
            this.tcCadastrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItens)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            // tbItens
            // 
            this.tbItens.Controls.Add(this.tcCadastrar);
            this.tbItens.Controls.Add(this.tcConsultar);
            this.tbItens.Location = new System.Drawing.Point(4, 73);
            this.tbItens.Name = "tbItens";
            this.tbItens.SelectedIndex = 0;
            this.tbItens.Size = new System.Drawing.Size(809, 337);
            this.tbItens.TabIndex = 5;
            // 
            // tcCadastrar
            // 
            this.tcCadastrar.BackColor = System.Drawing.SystemColors.Control;
            this.tcCadastrar.Controls.Add(this.label8);
            this.tcCadastrar.Controls.Add(this.txtcomplemento);
            this.tcCadastrar.Controls.Add(this.label2);
            this.tcCadastrar.Controls.Add(this.btnIncluir);
            this.tcCadastrar.Controls.Add(this.dtgItens);
            this.tcCadastrar.Controls.Add(this.groupBox3);
            this.tcCadastrar.Controls.Add(this.txtunidade);
            this.tcCadastrar.Controls.Add(this.label7);
            this.tcCadastrar.Controls.Add(this.label6);
            this.tcCadastrar.Controls.Add(this.mskdtfechaitem);
            this.tcCadastrar.Controls.Add(this.label5);
            this.tcCadastrar.Controls.Add(this.mskdtabitem);
            this.tcCadastrar.Controls.Add(this.txtcodproduto);
            this.tcCadastrar.Controls.Add(this.label3);
            this.tcCadastrar.Controls.Add(this.txtdescproduto);
            this.tcCadastrar.Controls.Add(this.txtvaloritem);
            this.tcCadastrar.Controls.Add(this.label4);
            this.tcCadastrar.Location = new System.Drawing.Point(4, 22);
            this.tcCadastrar.Name = "tcCadastrar";
            this.tcCadastrar.Padding = new System.Windows.Forms.Padding(3);
            this.tcCadastrar.Size = new System.Drawing.Size(801, 311);
            this.tcCadastrar.TabIndex = 0;
            this.tcCadastrar.Text = "Cadastrar";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(362, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 109;
            this.label8.Text = "Complemento";
            // 
            // txtcomplemento
            // 
            this.txtcomplemento.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtcomplemento.Location = new System.Drawing.Point(365, 72);
            this.txtcomplemento.MaxLength = 60;
            this.txtcomplemento.Name = "txtcomplemento";
            this.txtcomplemento.Size = new System.Drawing.Size(185, 20);
            this.txtcomplemento.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 107;
            this.label2.Text = "Descrição";
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(704, 70);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(88, 23);
            this.btnIncluir.TabIndex = 5;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            // 
            // dtgItens
            // 
            this.dtgItens.AllowUserToAddRows = false;
            this.dtgItens.AllowUserToDeleteRows = false;
            this.dtgItens.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItens.Location = new System.Drawing.Point(6, 98);
            this.dtgItens.Name = "dtgItens";
            this.dtgItens.ReadOnly = true;
            this.dtgItens.Size = new System.Drawing.Size(786, 207);
            this.dtgItens.TabIndex = 105;
            this.dtgItens.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgItens_CellFormatting);
            this.dtgItens.DoubleClick += new System.EventHandler(this.dtgItens_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbAndamento);
            this.groupBox3.Controls.Add(this.rbcancelado);
            this.groupBox3.Controls.Add(this.rbfinalizado);
            this.groupBox3.Controls.Add(this.rbaberto);
            this.groupBox3.Location = new System.Drawing.Point(232, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 42);
            this.groupBox3.TabIndex = 104;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // rbAndamento
            // 
            this.rbAndamento.AutoSize = true;
            this.rbAndamento.Location = new System.Drawing.Point(90, 19);
            this.rbAndamento.Name = "rbAndamento";
            this.rbAndamento.Size = new System.Drawing.Size(97, 17);
            this.rbAndamento.TabIndex = 17;
            this.rbAndamento.Text = "Em Andamento";
            this.rbAndamento.UseVisualStyleBackColor = true;
            // 
            // rbcancelado
            // 
            this.rbcancelado.AutoSize = true;
            this.rbcancelado.Location = new System.Drawing.Point(193, 19);
            this.rbcancelado.Name = "rbcancelado";
            this.rbcancelado.Size = new System.Drawing.Size(76, 17);
            this.rbcancelado.TabIndex = 16;
            this.rbcancelado.Text = "Cancelado";
            this.rbcancelado.UseVisualStyleBackColor = true;
            // 
            // rbfinalizado
            // 
            this.rbfinalizado.AutoSize = true;
            this.rbfinalizado.Location = new System.Drawing.Point(275, 19);
            this.rbfinalizado.Name = "rbfinalizado";
            this.rbfinalizado.Size = new System.Drawing.Size(72, 17);
            this.rbfinalizado.TabIndex = 15;
            this.rbfinalizado.Text = "Finalizado";
            this.rbfinalizado.UseVisualStyleBackColor = true;
            // 
            // rbaberto
            // 
            this.rbaberto.AutoSize = true;
            this.rbaberto.Checked = true;
            this.rbaberto.Location = new System.Drawing.Point(10, 19);
            this.rbaberto.Name = "rbaberto";
            this.rbaberto.Size = new System.Drawing.Size(74, 17);
            this.rbaberto.TabIndex = 2;
            this.rbaberto.TabStop = true;
            this.rbaberto.Text = "Em Aberto";
            this.rbaberto.UseVisualStyleBackColor = true;
            // 
            // txtunidade
            // 
            this.txtunidade.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtunidade.Location = new System.Drawing.Point(556, 72);
            this.txtunidade.MaxLength = 3;
            this.txtunidade.Name = "txtunidade";
            this.txtunidade.Size = new System.Drawing.Size(45, 20);
            this.txtunidade.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(553, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 103;
            this.label7.Text = "UN.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 101;
            this.label6.Text = "Data de Fechamento";
            // 
            // mskdtfechaitem
            // 
            this.mskdtfechaitem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mskdtfechaitem.Enabled = false;
            this.mskdtfechaitem.Location = new System.Drawing.Point(121, 24);
            this.mskdtfechaitem.Mask = "00/00/0000 90:00";
            this.mskdtfechaitem.Name = "mskdtfechaitem";
            this.mskdtfechaitem.Size = new System.Drawing.Size(105, 20);
            this.mskdtfechaitem.TabIndex = 100;
            this.mskdtfechaitem.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Data de Abertura";
            // 
            // mskdtabitem
            // 
            this.mskdtabitem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mskdtabitem.Enabled = false;
            this.mskdtabitem.Location = new System.Drawing.Point(10, 24);
            this.mskdtabitem.Mask = "00/00/0000 90:00";
            this.mskdtabitem.Name = "mskdtabitem";
            this.mskdtabitem.Size = new System.Drawing.Size(105, 20);
            this.mskdtabitem.TabIndex = 98;
            this.mskdtabitem.ValidatingType = typeof(System.DateTime);
            // 
            // txtcodproduto
            // 
            this.txtcodproduto.AcceptsReturn = true;
            this.txtcodproduto.BackColor = System.Drawing.SystemColors.Info;
            this.txtcodproduto.Location = new System.Drawing.Point(10, 72);
            this.txtcodproduto.MaxLength = 80;
            this.txtcodproduto.Name = "txtcodproduto";
            this.txtcodproduto.Size = new System.Drawing.Size(50, 20);
            this.txtcodproduto.TabIndex = 1;
            this.txtcodproduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodproduto_KeyDown);
            this.txtcodproduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodproduto_KeyPress);
            this.txtcodproduto.Leave += new System.EventHandler(this.txtcodproduto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Produto";
            // 
            // txtdescproduto
            // 
            this.txtdescproduto.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtdescproduto.Enabled = false;
            this.txtdescproduto.Location = new System.Drawing.Point(66, 72);
            this.txtdescproduto.MaxLength = 60;
            this.txtdescproduto.Name = "txtdescproduto";
            this.txtdescproduto.Size = new System.Drawing.Size(293, 20);
            this.txtdescproduto.TabIndex = 95;
            // 
            // txtvaloritem
            // 
            this.txtvaloritem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtvaloritem.Location = new System.Drawing.Point(607, 72);
            this.txtvaloritem.MaxLength = 6;
            this.txtvaloritem.Name = "txtvaloritem";
            this.txtvaloritem.Size = new System.Drawing.Size(91, 20);
            this.txtvaloritem.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(604, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 92;
            this.label4.Text = "Valor Item";
            // 
            // tcConsultar
            // 
            this.tcConsultar.BackColor = System.Drawing.SystemColors.Control;
            this.tcConsultar.Location = new System.Drawing.Point(4, 22);
            this.tcConsultar.Name = "tcConsultar";
            this.tcConsultar.Padding = new System.Windows.Forms.Padding(3);
            this.tcConsultar.Size = new System.Drawing.Size(801, 311);
            this.tcConsultar.TabIndex = 1;
            this.tcConsultar.Text = "Consultar";
            // 
            // CadItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 436);
            this.Controls.Add(this.tbItens);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(10, 45);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cadastro de Itens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadItems_FormClosing);
            this.Load += new System.EventHandler(this.CadItems_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CadItems_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tbItens.ResumeLayout(false);
            this.tcCadastrar.ResumeLayout(false);
            this.tcCadastrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItens)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.TabControl tbItens;
        private System.Windows.Forms.TabPage tcCadastrar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbAndamento;
        private System.Windows.Forms.RadioButton rbcancelado;
        private System.Windows.Forms.RadioButton rbfinalizado;
        private System.Windows.Forms.RadioButton rbaberto;
        private System.Windows.Forms.TextBox txtunidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mskdtfechaitem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mskdtabitem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdescproduto;
        private System.Windows.Forms.TextBox txtvaloritem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tcConsultar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.DataGridView dtgItens;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtcomplemento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcodproduto;
    }
}