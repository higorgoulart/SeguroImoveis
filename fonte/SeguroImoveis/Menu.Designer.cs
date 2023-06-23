namespace SeguroImoveis
{
    partial class Menu
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
            btCadastroApolice = new Button();
            btEditarApolice = new Button();
            btExcluirApolice = new Button();
            btRelatorio = new Button();
            SuspendLayout();
            // 
            // btCadastroApolice
            // 
            btCadastroApolice.Location = new Point(17, 20);
            btCadastroApolice.Margin = new Padding(4, 5, 4, 5);
            btCadastroApolice.Name = "btCadastroApolice";
            btCadastroApolice.Size = new Size(200, 63);
            btCadastroApolice.TabIndex = 0;
            btCadastroApolice.Text = "Cadastrar apólice";
            btCadastroApolice.UseVisualStyleBackColor = true;
            btCadastroApolice.Click += btCadastroApolice_Click;
            // 
            // btEditarApolice
            // 
            btEditarApolice.Location = new Point(226, 20);
            btEditarApolice.Margin = new Padding(4, 5, 4, 5);
            btEditarApolice.Name = "btEditarApolice";
            btEditarApolice.Size = new Size(200, 63);
            btEditarApolice.TabIndex = 1;
            btEditarApolice.Text = "Editar apólice";
            btEditarApolice.UseVisualStyleBackColor = true;
            btEditarApolice.Click += btEditarApolice_Click;
            // 
            // btExcluirApolice
            // 
            btExcluirApolice.Location = new Point(434, 20);
            btExcluirApolice.Margin = new Padding(4, 5, 4, 5);
            btExcluirApolice.Name = "btExcluirApolice";
            btExcluirApolice.Size = new Size(200, 63);
            btExcluirApolice.TabIndex = 2;
            btExcluirApolice.Text = "Excluir apólice";
            btExcluirApolice.UseVisualStyleBackColor = true;
            // 
            // btRelatorio
            // 
            btRelatorio.Location = new Point(643, 20);
            btRelatorio.Margin = new Padding(4, 5, 4, 5);
            btRelatorio.Name = "btRelatorio";
            btRelatorio.Size = new Size(200, 63);
            btRelatorio.TabIndex = 3;
            btRelatorio.Text = "Relatório";
            btRelatorio.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 103);
            Controls.Add(btRelatorio);
            Controls.Add(btExcluirApolice);
            Controls.Add(btEditarApolice);
            Controls.Add(btCadastroApolice);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btCadastroApolice;
        private Button btEditarApolice;
        private Button btExcluirApolice;
        private Button btRelatorio;
    }
}