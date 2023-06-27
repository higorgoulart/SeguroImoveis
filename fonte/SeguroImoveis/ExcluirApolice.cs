using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SeguroImoveis
{
    public partial class ExcluirApolice : Form
    {
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
        private Button btPesquisar;
        private Button btExcluir;

        private readonly MySqlConnection _conexao;

        public ExcluirApolice(MySqlConnection conexao)
        {
            _conexao = conexao;

            InitializeComponent();

            ExibirCampos(false);
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbIdApolice.Text))
                    throw new Exception("Preencha o ID da apólice!");

                var script = $@"
                    SELECT id_apolice, id_imovel, dt_inicio, dt_termino, valor_apolice from apolice 
                    WHERE id_apolice = {tbIdApolice.Text}";

                var command = new MySqlCommand(script, _conexao);

                bool resultadoEncontrado = false;

                _conexao.Open();

                using (var cursor = command.ExecuteReader())
                {
                    while (cursor.Read())
                    {
                        resultadoEncontrado = true;
                        tbIdImovel.Text = cursor["id_imovel"].ToString();
                        dtInicio.Text = cursor["dt_inicio"].ToString();
                        dtTermino.Text = cursor["dt_termino"].ToString();
                        tbValor.Text = cursor["valor_apolice"].ToString();
                    }
                }

                if (resultadoEncontrado)
                {
                    ExibirCampos(true);
                }
                else
                {
                    MessageBox.Show("Não foi encontrada apólice com o ID: " + tbIdApolice.Text);
                }
            }
            finally
            {
                _conexao.Close();
            } 
        }   

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbIdApolice.Text == "")
                    throw new Exception("Preencha o ID da apólice!");

                var script = $@"DELETE FROM apolice WHERE id_apolice = {tbIdApolice.Text}";

                var command = new MySqlCommand(script, _conexao);

                _conexao.Open();

                command.ExecuteReader();

                MessageBox.Show("Excluido com sucesso!");
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

        private void ExibirCampos(bool exibir)
        {
            tbIdImovel.Visible = exibir;
            lbIdImovel.Visible = exibir;
            dtInicio.Visible = exibir;
            lbDtInicio.Visible = exibir;
            dtTermino.Visible = exibir;
            lbDtTermino.Visible = exibir;
            tbValor.Visible = exibir;
            lbValor.Visible = exibir;
            btExcluir.Visible = exibir;
            btExcluir.Enabled = exibir;
        }

        private void InitializeComponent()
        {
            this.dtTermino = new System.Windows.Forms.DateTimePicker();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.lbValor = new System.Windows.Forms.Label();
            this.lbDtTermino = new System.Windows.Forms.Label();
            this.lbDtInicio = new System.Windows.Forms.Label();
            this.tbIdImovel = new System.Windows.Forms.TextBox();
            this.lbIdImovel = new System.Windows.Forms.Label();
            this.tbIdApolice = new System.Windows.Forms.TextBox();
            this.lbIdApolice = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtTermino
            // 
            this.dtTermino.Enabled = false;
            this.dtTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTermino.Location = new System.Drawing.Point(134, 132);
            this.dtTermino.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtTermino.Name = "dtTermino";
            this.dtTermino.Size = new System.Drawing.Size(301, 26);
            this.dtTermino.TabIndex = 14;
            this.dtTermino.Visible = false;
            // 
            // dtInicio
            // 
            this.dtInicio.Enabled = false;
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(136, 93);
            this.dtInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(301, 26);
            this.dtInicio.TabIndex = 13;
            this.dtInicio.Visible = false;
            // 
            // tbValor
            // 
            this.tbValor.Enabled = false;
            this.tbValor.Location = new System.Drawing.Point(132, 171);
            this.tbValor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbValor.Name = "tbValor";
            this.tbValor.ReadOnly = true;
            this.tbValor.Size = new System.Drawing.Size(305, 26);
            this.tbValor.TabIndex = 15;
            this.tbValor.Visible = false;
            // 
            // lbValor
            // 
            this.lbValor.AutoSize = true;
            this.lbValor.Enabled = false;
            this.lbValor.Location = new System.Drawing.Point(8, 175);
            this.lbValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(46, 20);
            this.lbValor.TabIndex = 6;
            this.lbValor.Text = "Valor";
            this.lbValor.Visible = false;
            // 
            // lbDtTermino
            // 
            this.lbDtTermino.AutoSize = true;
            this.lbDtTermino.Enabled = false;
            this.lbDtTermino.Location = new System.Drawing.Point(12, 132);
            this.lbDtTermino.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDtTermino.Name = "lbDtTermino";
            this.lbDtTermino.Size = new System.Drawing.Size(123, 20);
            this.lbDtTermino.TabIndex = 7;
            this.lbDtTermino.Text = "Data de término";
            this.lbDtTermino.Visible = false;
            // 
            // lbDtInicio
            // 
            this.lbDtInicio.AutoSize = true;
            this.lbDtInicio.Enabled = false;
            this.lbDtInicio.Location = new System.Drawing.Point(12, 97);
            this.lbDtInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDtInicio.Name = "lbDtInicio";
            this.lbDtInicio.Size = new System.Drawing.Size(105, 20);
            this.lbDtInicio.TabIndex = 8;
            this.lbDtInicio.Text = "Data de início";
            this.lbDtInicio.Visible = false;
            // 
            // tbIdImovel
            // 
            this.tbIdImovel.Enabled = false;
            this.tbIdImovel.Location = new System.Drawing.Point(136, 55);
            this.tbIdImovel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbIdImovel.Name = "tbIdImovel";
            this.tbIdImovel.Size = new System.Drawing.Size(305, 26);
            this.tbIdImovel.TabIndex = 12;
            this.tbIdImovel.Visible = false;
            // 
            // lbIdImovel
            // 
            this.lbIdImovel.AutoSize = true;
            this.lbIdImovel.Enabled = false;
            this.lbIdImovel.Location = new System.Drawing.Point(12, 59);
            this.lbIdImovel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIdImovel.Name = "lbIdImovel";
            this.lbIdImovel.Size = new System.Drawing.Size(96, 20);
            this.lbIdImovel.TabIndex = 9;
            this.lbIdImovel.Text = "ID do imóvel";
            this.lbIdImovel.Visible = false;
            // 
            // tbIdApolice
            // 
            this.tbIdApolice.Location = new System.Drawing.Point(136, 16);
            this.tbIdApolice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbIdApolice.Name = "tbIdApolice";
            this.tbIdApolice.Size = new System.Drawing.Size(305, 26);
            this.tbIdApolice.TabIndex = 11;
            // 
            // lbIdApolice
            // 
            this.lbIdApolice.AutoSize = true;
            this.lbIdApolice.Location = new System.Drawing.Point(12, 20);
            this.lbIdApolice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIdApolice.Name = "lbIdApolice";
            this.lbIdApolice.Size = new System.Drawing.Size(102, 20);
            this.lbIdApolice.TabIndex = 10;
            this.lbIdApolice.Text = "ID da apólice";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(8, 248);
            this.btPesquisar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(192, 59);
            this.btPesquisar.TabIndex = 16;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Enabled = false;
            this.btExcluir.Location = new System.Drawing.Point(251, 248);
            this.btExcluir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(192, 59);
            this.btExcluir.TabIndex = 17;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Visible = false;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // ExcluirApolice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 323);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btPesquisar);
            this.Controls.Add(this.dtTermino);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.lbValor);
            this.Controls.Add(this.lbDtTermino);
            this.Controls.Add(this.lbDtInicio);
            this.Controls.Add(this.tbIdImovel);
            this.Controls.Add(this.lbIdImovel);
            this.Controls.Add(this.tbIdApolice);
            this.Controls.Add(this.lbIdApolice);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ExcluirApolice";
            this.Text = "Exclusão de apólice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
