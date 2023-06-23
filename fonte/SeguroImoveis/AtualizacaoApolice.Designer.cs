namespace SeguroImoveis
{
    partial class AtualizacaoApolice
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
            dtTermino = new DateTimePicker();
            dtInicio = new DateTimePicker();
            tbValor = new TextBox();
            lbValor = new Label();
            lbDtTermino = new Label();
            lbDtInicio = new Label();
            tbIdImovel = new TextBox();
            lbIdImovel = new Label();
            tbIdApolice = new TextBox();
            lbIdApolice = new Label();
            btAtualizar = new Button();
            btPesquisar = new Button();
            SuspendLayout();
            // 
            // dtTermino
            // 
            dtTermino.Enabled = false;
            dtTermino.Format = DateTimePickerFormat.Short;
            dtTermino.Location = new Point(110, 119);
            dtTermino.Name = "dtTermino";
            dtTermino.Size = new Size(235, 23);
            dtTermino.TabIndex = 15;
            // 
            // dtInicio
            // 
            dtInicio.Enabled = false;
            dtInicio.Format = DateTimePickerFormat.Short;
            dtInicio.Location = new Point(109, 90);
            dtInicio.Name = "dtInicio";
            dtInicio.Size = new Size(235, 23);
            dtInicio.TabIndex = 14;
            // 
            // tbValor
            // 
            tbValor.Enabled = false;
            tbValor.Location = new Point(109, 148);
            tbValor.Name = "tbValor";
            tbValor.Size = new Size(238, 23);
            tbValor.TabIndex = 16;
            // 
            // lbValor
            // 
            lbValor.AutoSize = true;
            lbValor.Location = new Point(12, 151);
            lbValor.Name = "lbValor";
            lbValor.Size = new Size(33, 15);
            lbValor.TabIndex = 6;
            lbValor.Text = "Valor";
            // 
            // lbDtTermino
            // 
            lbDtTermino.AutoSize = true;
            lbDtTermino.Location = new Point(12, 122);
            lbDtTermino.Name = "lbDtTermino";
            lbDtTermino.Size = new Size(92, 15);
            lbDtTermino.TabIndex = 7;
            lbDtTermino.Text = "Data de término";
            // 
            // lbDtInicio
            // 
            lbDtInicio.AutoSize = true;
            lbDtInicio.Location = new Point(12, 93);
            lbDtInicio.Name = "lbDtInicio";
            lbDtInicio.Size = new Size(79, 15);
            lbDtInicio.TabIndex = 8;
            lbDtInicio.Text = "Data de início";
            // 
            // tbIdImovel
            // 
            tbIdImovel.Enabled = false;
            tbIdImovel.Location = new Point(109, 61);
            tbIdImovel.Name = "tbIdImovel";
            tbIdImovel.Size = new Size(238, 23);
            tbIdImovel.TabIndex = 13;
            // 
            // lbIdImovel
            // 
            lbIdImovel.AutoSize = true;
            lbIdImovel.Location = new Point(12, 64);
            lbIdImovel.Name = "lbIdImovel";
            lbIdImovel.Size = new Size(74, 15);
            lbIdImovel.TabIndex = 9;
            lbIdImovel.Text = "ID do imóvel";
            // 
            // tbIdApolice
            // 
            tbIdApolice.Location = new Point(109, 6);
            tbIdApolice.Name = "tbIdApolice";
            tbIdApolice.Size = new Size(238, 23);
            tbIdApolice.TabIndex = 12;
            // 
            // lbIdApolice
            // 
            lbIdApolice.AutoSize = true;
            lbIdApolice.Location = new Point(12, 9);
            lbIdApolice.Name = "lbIdApolice";
            lbIdApolice.Size = new Size(75, 15);
            lbIdApolice.TabIndex = 10;
            lbIdApolice.Text = "ID da apólice";
            // 
            // btAdicionar
            // 
            btAtualizar.Enabled = false;
            btAtualizar.Location = new Point(353, 148);
            btAtualizar.Name = "btAdicionar";
            btAtualizar.Size = new Size(149, 44);
            btAtualizar.TabIndex = 11;
            btAtualizar.Text = "Atualizar";
            btAtualizar.UseVisualStyleBackColor = true;
            btAtualizar.Click += btAtualizar_Click;
            // 
            // btPesquisar
            // 
            btPesquisar.Location = new Point(353, 6);
            btPesquisar.Name = "btPesquisar";
            btPesquisar.Size = new Size(149, 44);
            btPesquisar.TabIndex = 17;
            btPesquisar.Text = "Pesquisar";
            btPesquisar.UseVisualStyleBackColor = true;
            btPesquisar.Click += btPesquisar_Click;
            // 
            // AtualizacaoApolice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 202);
            Controls.Add(btPesquisar);
            Controls.Add(dtTermino);
            Controls.Add(dtInicio);
            Controls.Add(tbValor);
            Controls.Add(lbValor);
            Controls.Add(lbDtTermino);
            Controls.Add(lbDtInicio);
            Controls.Add(tbIdImovel);
            Controls.Add(lbIdImovel);
            Controls.Add(tbIdApolice);
            Controls.Add(lbIdApolice);
            Controls.Add(btAtualizar);
            Name = "AtualizacaoApolice";
            Text = "AtualizacaoApolice";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtTermino;
        private DateTimePicker dtInicio;
        private TextBox tbValor;
        private Label lbValor;
        private Label lbDtTermino;
        private Label lbDtInicio;
        private TextBox tbIdImovel;
        private Label lbIdImovel;
        private TextBox tbIdApolice;
        private Label lbIdApolice;
        private Button btAtualizar;
        private Button btPesquisar;
    }
}