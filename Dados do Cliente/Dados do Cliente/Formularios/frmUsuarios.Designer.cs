namespace Dados_do_Cliente.Formularios
{
    partial class frmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarios));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tstSalva3 = new System.Windows.Forms.ToolStripButton();
            this.tstExcluir3 = new System.Windows.Forms.ToolStripButton();
            this.tstPesquisar3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tstSair3 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboOpcao3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltro3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.txtNome3 = new System.Windows.Forms.TextBox();
            this.lblNome3 = new System.Windows.Forms.Label();
            this.txtSenha3 = new System.Windows.Forms.TextBox();
            this.lblSenha3 = new System.Windows.Forms.Label();
            this.tstAlterar3 = new System.Windows.Forms.ToolStripButton();
            this.chkbClientes = new System.Windows.Forms.CheckBox();
            this.chkbProdutos = new System.Windows.Forms.CheckBox();
            this.txtCodigo3 = new System.Windows.Forms.TextBox();
            this.lblCodigo3 = new System.Windows.Forms.Label();
            this.grpUsuarios = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.grpUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstSalva3,
            this.tstExcluir3,
            this.tstPesquisar3,
            this.tstAlterar3,
            this.toolStripSeparator1,
            this.tstSair3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(930, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tstSalva3
            // 
            this.tstSalva3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstSalva3.Image = ((System.Drawing.Image)(resources.GetObject("tstSalva3.Image")));
            this.tstSalva3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstSalva3.Name = "tstSalva3";
            this.tstSalva3.Size = new System.Drawing.Size(42, 22);
            this.tstSalva3.Text = "&Salvar";
            this.tstSalva3.Click += new System.EventHandler(this.tstSalva3_Click);
            // 
            // tstExcluir3
            // 
            this.tstExcluir3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstExcluir3.Image = ((System.Drawing.Image)(resources.GetObject("tstExcluir3.Image")));
            this.tstExcluir3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstExcluir3.Name = "tstExcluir3";
            this.tstExcluir3.Size = new System.Drawing.Size(45, 22);
            this.tstExcluir3.Text = "&Excluir";
            // 
            // tstPesquisar3
            // 
            this.tstPesquisar3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstPesquisar3.Image = ((System.Drawing.Image)(resources.GetObject("tstPesquisar3.Image")));
            this.tstPesquisar3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstPesquisar3.Name = "tstPesquisar3";
            this.tstPesquisar3.Size = new System.Drawing.Size(61, 22);
            this.tstPesquisar3.Text = "&Pesquisar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tstSair3
            // 
            this.tstSair3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstSair3.Image = ((System.Drawing.Image)(resources.GetObject("tstSair3.Image")));
            this.tstSair3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstSair3.Name = "tstSair3";
            this.tstSair3.Size = new System.Drawing.Size(30, 22);
            this.tstSair3.Text = "S&air";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(897, 297);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvUsuarios);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtFiltro3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cboOpcao3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(889, 271);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pesquisar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpUsuarios);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(889, 271);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dados do Usuário";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // cboOpcao3
            // 
            this.cboOpcao3.FormattingEnabled = true;
            this.cboOpcao3.Items.AddRange(new object[] {
            "Codigo",
            "Nome ",
            "Senha"});
            this.cboOpcao3.Location = new System.Drawing.Point(20, 53);
            this.cboOpcao3.Name = "cboOpcao3";
            this.cboOpcao3.Size = new System.Drawing.Size(148, 21);
            this.cboOpcao3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opção";
            // 
            // txtFiltro3
            // 
            this.txtFiltro3.Location = new System.Drawing.Point(203, 53);
            this.txtFiltro3.Name = "txtFiltro3";
            this.txtFiltro3.Size = new System.Drawing.Size(659, 20);
            this.txtFiltro3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filtro";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 99);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(842, 150);
            this.dgvUsuarios.TabIndex = 4;
            // 
            // txtNome3
            // 
            this.txtNome3.Location = new System.Drawing.Point(153, 74);
            this.txtNome3.Name = "txtNome3";
            this.txtNome3.Size = new System.Drawing.Size(408, 20);
            this.txtNome3.TabIndex = 0;
            // 
            // lblNome3
            // 
            this.lblNome3.AutoSize = true;
            this.lblNome3.Location = new System.Drawing.Point(150, 58);
            this.lblNome3.Name = "lblNome3";
            this.lblNome3.Size = new System.Drawing.Size(35, 13);
            this.lblNome3.TabIndex = 1;
            this.lblNome3.Text = "Nome";
            // 
            // txtSenha3
            // 
            this.txtSenha3.Location = new System.Drawing.Point(582, 74);
            this.txtSenha3.Name = "txtSenha3";
            this.txtSenha3.Size = new System.Drawing.Size(174, 20);
            this.txtSenha3.TabIndex = 2;
            // 
            // lblSenha3
            // 
            this.lblSenha3.AutoSize = true;
            this.lblSenha3.Location = new System.Drawing.Point(579, 58);
            this.lblSenha3.Name = "lblSenha3";
            this.lblSenha3.Size = new System.Drawing.Size(38, 13);
            this.lblSenha3.TabIndex = 3;
            this.lblSenha3.Text = "Senha";
            // 
            // tstAlterar3
            // 
            this.tstAlterar3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstAlterar3.Image = ((System.Drawing.Image)(resources.GetObject("tstAlterar3.Image")));
            this.tstAlterar3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstAlterar3.Name = "tstAlterar3";
            this.tstAlterar3.Size = new System.Drawing.Size(46, 22);
            this.tstAlterar3.Text = "&Alterar";
            // 
            // chkbClientes
            // 
            this.chkbClientes.AutoSize = true;
            this.chkbClientes.Location = new System.Drawing.Point(370, 130);
            this.chkbClientes.Name = "chkbClientes";
            this.chkbClientes.Size = new System.Drawing.Size(63, 17);
            this.chkbClientes.TabIndex = 4;
            this.chkbClientes.Text = "Clientes";
            this.chkbClientes.UseVisualStyleBackColor = true;
            // 
            // chkbProdutos
            // 
            this.chkbProdutos.AutoSize = true;
            this.chkbProdutos.Location = new System.Drawing.Point(370, 170);
            this.chkbProdutos.Name = "chkbProdutos";
            this.chkbProdutos.Size = new System.Drawing.Size(68, 17);
            this.chkbProdutos.TabIndex = 5;
            this.chkbProdutos.Text = "Produtos";
            this.chkbProdutos.UseVisualStyleBackColor = true;
            // 
            // txtCodigo3
            // 
            this.txtCodigo3.Location = new System.Drawing.Point(26, 74);
            this.txtCodigo3.Name = "txtCodigo3";
            this.txtCodigo3.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo3.TabIndex = 6;
            // 
            // lblCodigo3
            // 
            this.lblCodigo3.AutoSize = true;
            this.lblCodigo3.Location = new System.Drawing.Point(23, 58);
            this.lblCodigo3.Name = "lblCodigo3";
            this.lblCodigo3.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo3.TabIndex = 7;
            this.lblCodigo3.Text = "Código";
            // 
            // grpUsuarios
            // 
            this.grpUsuarios.Controls.Add(this.lblCodigo3);
            this.grpUsuarios.Controls.Add(this.chkbClientes);
            this.grpUsuarios.Controls.Add(this.lblNome3);
            this.grpUsuarios.Controls.Add(this.lblSenha3);
            this.grpUsuarios.Controls.Add(this.txtNome3);
            this.grpUsuarios.Controls.Add(this.txtSenha3);
            this.grpUsuarios.Controls.Add(this.chkbProdutos);
            this.grpUsuarios.Controls.Add(this.txtCodigo3);
            this.grpUsuarios.Location = new System.Drawing.Point(19, 33);
            this.grpUsuarios.Name = "grpUsuarios";
            this.grpUsuarios.Size = new System.Drawing.Size(864, 232);
            this.grpUsuarios.TabIndex = 2;
            this.grpUsuarios.TabStop = false;
            this.grpUsuarios.Text = "Dados do Usuário";
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 411);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmUsuarios";
            this.Text = "frmUsuarios";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.grpUsuarios.ResumeLayout(false);
            this.grpUsuarios.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tstSalva3;
        private System.Windows.Forms.ToolStripButton tstExcluir3;
        private System.Windows.Forms.ToolStripButton tstPesquisar3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tstSair3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboOpcao3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltro3;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblSenha3;
        private System.Windows.Forms.TextBox txtSenha3;
        private System.Windows.Forms.Label lblNome3;
        private System.Windows.Forms.TextBox txtNome3;
        private System.Windows.Forms.ToolStripButton tstAlterar3;
        private System.Windows.Forms.CheckBox chkbProdutos;
        private System.Windows.Forms.CheckBox chkbClientes;
        private System.Windows.Forms.TextBox txtCodigo3;
        private System.Windows.Forms.Label lblCodigo3;
        private System.Windows.Forms.GroupBox grpUsuarios;
    }
}