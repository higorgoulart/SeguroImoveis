using MySql.Data.MySqlClient;
using SeguroImoveis.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SeguroImoveis
{
    public partial class CadastroApolice : Form
    {
        private Button btAdicionar;
        private Label lbIdApolice;
        private TextBox tbIdApolice;
        private TextBox tbIdImovel;
        private Label lbIdImovel;
        private TextBox tbDtInicio;
        private Label lbDtInicio;
        private TextBox tbDtTermino;
        private Label lbDtTermino;
        private TextBox tbValor;
        private Label lbValor;
        private DateTimePicker dtInicio;
        private DateTimePicker dtTermino;

        private readonly MySqlConnection _conexao;

        public CadastroApolice(MySqlConnection conexao)
        {
            _conexao = conexao;

            InitializeComponent();
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var script = $@"
                    INSERT INTO apolice (id_apolice, id_imovel, dt_inicio, dt_termino, valor_apolice) 
                    VALUES ({tbIdApolice.Text}, {tbIdImovel.Text}, '{DatabaseUtils.FormatToDate(dtInicio.Text)}', '{DatabaseUtils.FormatToDate(dtTermino.Text)}', {tbValor.Text})";

                var command = new MySqlCommand(script, _conexao);

                _conexao.Open();

                command.ExecuteReader();

                MessageBox.Show("Tudo certo!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conexao.Close();
            }
        }

        private void InitializeComponent()
        {
            btAdicionar = new Button();
            lbIdApolice = new Label();
            tbIdApolice = new TextBox();
            lbIdImovel = new Label();
            tbIdImovel = new TextBox();
            lbDtInicio = new Label();
            lbDtTermino = new Label();
            lbValor = new Label();
            tbValor = new TextBox();
            dtInicio = new DateTimePicker();
            dtTermino = new DateTimePicker();
            this.SuspendLayout();
            // 
            // btAdicionar
            // 
            btAdicionar.Location = new Point(198, 160);
            btAdicionar.Name = "btAdicionar";
            btAdicionar.Size = new Size(149, 44);
            btAdicionar.TabIndex = 0;
            btAdicionar.Text = "Salvar";
            btAdicionar.UseVisualStyleBackColor = true;
            btAdicionar.Click += btAdicionar_Click;
            // 
            // lbIdApolice
            // 
            lbIdApolice.AutoSize = true;
            lbIdApolice.Location = new Point(12, 9);
            lbIdApolice.Name = "lbIdApolice";
            lbIdApolice.Size = new Size(75, 15);
            lbIdApolice.TabIndex = 0;
            lbIdApolice.Text = "ID da apólice";
            // 
            // tbIdApolice
            // 
            tbIdApolice.Location = new Point(109, 6);
            tbIdApolice.Name = "tbIdApolice";
            tbIdApolice.Size = new Size(238, 23);
            tbIdApolice.TabIndex = 1;
            // 
            // lbIdImovel
            // 
            lbIdImovel.AutoSize = true;
            lbIdImovel.Location = new Point(12, 38);
            lbIdImovel.Name = "lbIdImovel";
            lbIdImovel.Size = new Size(74, 15);
            lbIdImovel.TabIndex = 0;
            lbIdImovel.Text = "ID do imóvel";
            // 
            // tbIdImovel
            // 
            tbIdImovel.Location = new Point(109, 35);
            tbIdImovel.Name = "tbIdImovel";
            tbIdImovel.Size = new Size(238, 23);
            tbIdImovel.TabIndex = 2;
            // 
            // lbDtInicio
            // 
            lbDtInicio.AutoSize = true;
            lbDtInicio.Location = new Point(12, 67);
            lbDtInicio.Name = "lbDtInicio";
            lbDtInicio.Size = new Size(79, 15);
            lbDtInicio.TabIndex = 0;
            lbDtInicio.Text = "Data de início";
            // 
            // lbDtTermino
            // 
            lbDtTermino.AutoSize = true;
            lbDtTermino.Location = new Point(12, 96);
            lbDtTermino.Name = "lbDtTermino";
            lbDtTermino.Size = new Size(92, 15);
            lbDtTermino.TabIndex = 0;
            lbDtTermino.Text = "Data de término";
            // 
            // lbValor
            // 
            lbValor.AutoSize = true;
            lbValor.Location = new Point(12, 125);
            lbValor.Name = "lbValor";
            lbValor.Size = new Size(33, 15);
            lbValor.TabIndex = 0;
            lbValor.Text = "Valor";
            // 
            // tbValor
            // 
            tbValor.Location = new Point(109, 122);
            tbValor.Name = "tbValor";
            tbValor.Size = new Size(238, 23);
            tbValor.TabIndex = 5;
            // 
            // dtInicio
            // 
            dtInicio.Format = DateTimePickerFormat.Short;
            dtInicio.Location = new Point(109, 64);
            dtInicio.Name = "dtInicio";
            dtInicio.Size = new Size(235, 23);
            dtInicio.TabIndex = 3;
            // 
            // dtTermino
            // 
            dtTermino.Format = DateTimePickerFormat.Short;
            dtTermino.Location = new Point(110, 93);
            dtTermino.Name = "dtTermino";
            dtTermino.Size = new Size(235, 23);
            dtTermino.TabIndex = 4;
            // 
            // CadastroApolice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 216);
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
            Controls.Add(btAdicionar);
            Name = "CadastroApolice";
            Text = "Cadastro de apólice";
            ResumeLayout(false);
            PerformLayout();

        }
    }
}