using MySql.Data.MySqlClient;
using SeguroImoveis.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguroImoveis
{
    public partial class ExcluirApolice : Form
    {
        private readonly MySqlConnection _conexao;

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
            btPesquisar = new Button();
            btExcluir = new Button();
            SuspendLayout();
            // 
            // dtTermino
            // 
            dtTermino.Enabled = false;
            dtTermino.Format = DateTimePickerFormat.Short;
            dtTermino.Location = new Point(104, 99);
            dtTermino.Name = "dtTermino";
            dtTermino.Size = new Size(235, 23);
            dtTermino.TabIndex = 14;
            dtTermino.Visible = false;
            // 
            // dtInicio
            // 
            dtInicio.Enabled = false;
            dtInicio.Format = DateTimePickerFormat.Short;
            dtInicio.Location = new Point(106, 70);
            dtInicio.Name = "dtInicio";
            dtInicio.Size = new Size(235, 23);
            dtInicio.TabIndex = 13;
            dtInicio.Visible = false;
            // 
            // tbValor
            // 
            tbValor.Enabled = false;
            tbValor.Location = new Point(103, 128);
            tbValor.Name = "tbValor";
            tbValor.ReadOnly = true;
            tbValor.Size = new Size(238, 23);
            tbValor.TabIndex = 15;
            tbValor.Visible = false;
            // 
            // lbValor
            // 
            lbValor.AutoSize = true;
            lbValor.Enabled = false;
            lbValor.Location = new Point(6, 131);
            lbValor.Name = "lbValor";
            lbValor.Size = new Size(33, 15);
            lbValor.TabIndex = 6;
            lbValor.Text = "Valor";
            lbValor.Visible = false;
            // 
            // lbDtTermino
            // 
            lbDtTermino.AutoSize = true;
            lbDtTermino.Enabled = false;
            lbDtTermino.Location = new Point(9, 99);
            lbDtTermino.Name = "lbDtTermino";
            lbDtTermino.Size = new Size(92, 15);
            lbDtTermino.TabIndex = 7;
            lbDtTermino.Text = "Data de término";
            lbDtTermino.Visible = false;
            // 
            // lbDtInicio
            // 
            lbDtInicio.AutoSize = true;
            lbDtInicio.Enabled = false;
            lbDtInicio.Location = new Point(9, 73);
            lbDtInicio.Name = "lbDtInicio";
            lbDtInicio.Size = new Size(79, 15);
            lbDtInicio.TabIndex = 8;
            lbDtInicio.Text = "Data de início";
            lbDtInicio.Visible = false;
            // 
            // tbIdImovel
            // 
            tbIdImovel.Enabled = false;
            tbIdImovel.Location = new Point(106, 41);
            tbIdImovel.Name = "tbIdImovel";
            tbIdImovel.Size = new Size(238, 23);
            tbIdImovel.TabIndex = 12;
            tbIdImovel.Visible = false;
            // 
            // lbIdImovel
            // 
            lbIdImovel.AutoSize = true;
            lbIdImovel.Enabled = false;
            lbIdImovel.Location = new Point(9, 44);
            lbIdImovel.Name = "lbIdImovel";
            lbIdImovel.Size = new Size(74, 15);
            lbIdImovel.TabIndex = 9;
            lbIdImovel.Text = "ID do imóvel";
            lbIdImovel.Visible = false;
            // 
            // tbIdApolice
            // 
            tbIdApolice.Location = new Point(106, 12);
            tbIdApolice.Name = "tbIdApolice";
            tbIdApolice.Size = new Size(238, 23);
            tbIdApolice.TabIndex = 11;
            // 
            // lbIdApolice
            // 
            lbIdApolice.AutoSize = true;
            lbIdApolice.Location = new Point(9, 15);
            lbIdApolice.Name = "lbIdApolice";
            lbIdApolice.Size = new Size(75, 15);
            lbIdApolice.TabIndex = 10;
            lbIdApolice.Text = "ID da apólice";
            // 
            // btPesquisar
            // 
            btPesquisar.Location = new Point(6, 186);
            btPesquisar.Name = "btPesquisar";
            btPesquisar.Size = new Size(149, 44);
            btPesquisar.TabIndex = 16;
            btPesquisar.Text = "Pesquisar";
            btPesquisar.UseVisualStyleBackColor = true;
            btPesquisar.Click += btPesquisar_Click;
            // 
            // btExcluir
            // 
            btExcluir.Enabled = false;
            btExcluir.Location = new Point(195, 186);
            btExcluir.Name = "btExcluir";
            btExcluir.Size = new Size(149, 44);
            btExcluir.TabIndex = 17;
            btExcluir.Text = "Excluir";
            btExcluir.UseVisualStyleBackColor = true;
            btExcluir.Visible = false;
            btExcluir.Click += btExcluir_Click;
            // 
            // ExcluirApolice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 242);
            Controls.Add(btExcluir);
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
            Name = "ExcluirApolice";
            Text = "Exclusão de apólice";
            ResumeLayout(false);
            PerformLayout();
        }

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
    

    public ExcluirApolice(MySqlConnection conexao)
        {
            _conexao = conexao;

            InitializeComponent();
            ExibirCampos(false);
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbIdApolice.Text))
                throw new Exception("Preencha o ID da apólice!");

            var script = $@"
                    SELECT id_apolice, id_imovel, dt_inicio, dt_termino, valor_apolice from apolice 
                    WHERE id_apolice = 
            {tbIdApolice.Text}";

            var command = new MySqlCommand(script, _conexao);

            bool resultadoEncontrado = false;

            if (!_conexao.State.Equals(ConnectionState.Open))
            {
                _conexao.Open();
            }

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
                MessageBox.Show("Não foi encontrada apólice com o Id: " + tbIdApolice.Text);
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

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbIdApolice.Text == "")
                {
                    throw new Exception("Preencha o ID da apólice!");
                }

                var script = $@"
                    DELETE FROM 
                        apolice 
                    WHERE
                        id_apolice = 
                {tbIdApolice.Text}";

                var command = new MySqlCommand(script, _conexao);

                if (!_conexao.State.Equals(ConnectionState.Open))
                {
                    _conexao.Open();
                }

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
    }
}
