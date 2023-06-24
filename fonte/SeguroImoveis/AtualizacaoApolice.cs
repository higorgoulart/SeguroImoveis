using MySql.Data.MySqlClient;
using SeguroImoveis.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SeguroImoveis
{
    public partial class AtualizacaoApolice : Form
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
        private Button btAtualizar;
        private Button btPesquisar;
        private MySqlConnection _conexao;

        public AtualizacaoApolice(MySqlConnection conexao)
        {
            _conexao = conexao;

            InitializeComponent();
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

                _conexao.Open();

                using (var cursor = command.ExecuteReader())
                {
                    while (cursor.Read())
                    {
                        tbIdImovel.Text = cursor["id_imovel"].ToString();
                        dtInicio.Text = cursor["dt_inicio"].ToString();
                        dtTermino.Text = cursor["dt_termino"].ToString();
                        tbValor.Text = cursor["valor_apolice"].ToString();
                    }
                }

                HabilitarCampos(true);

                MessageBox.Show("Tudo certo!");
            }
            catch (Exception ex)
            {
                HabilitarCampos(false);

                tbIdImovel.Text = string.Empty;
                dtInicio.Text = string.Empty;
                dtTermino.Text = string.Empty;
                tbValor.Text = string.Empty;
                btAtualizar.Text = string.Empty;

                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conexao.Close();
            }
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var script = $@"
                    UPDATE 
                        apolice 
                    SET 
                        id_imovel = {tbIdImovel.Text}, 
                        dt_inicio = '{DatabaseUtils.FormatToDate(dtInicio.Text)}', 
                        dt_termino = '{DatabaseUtils.FormatToDate(dtTermino.Text)}', 
                        valor_apolice = {tbValor.Text}
                    WHERE
                        id_apolice = {tbIdApolice.Text}";

                var command = new MySqlCommand(script, _conexao);

                _conexao.Open();

                command.ExecuteReader();

                MessageBox.Show("Registro atualizado com sucesso!");
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
         
        private void HabilitarCampos(bool habilitar)
        {
            tbIdImovel.Enabled = habilitar;
            dtInicio.Enabled = habilitar;
            dtTermino.Enabled = habilitar;
            tbValor.Enabled = habilitar;
            btAtualizar.Enabled = habilitar;
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
            this.btAtualizar = new System.Windows.Forms.Button();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtTermino
            // 
            this.dtTermino.Enabled = false;
            this.dtTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTermino.Location = new System.Drawing.Point(110, 119);
            this.dtTermino.Name = "dtTermino";
            this.dtTermino.Size = new System.Drawing.Size(235, 26);
            this.dtTermino.TabIndex = 15;
            // 
            // dtInicio
            // 
            this.dtInicio.Enabled = false;
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(109, 90);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(235, 26);
            this.dtInicio.TabIndex = 14;
            // 
            // tbValor
            // 
            this.tbValor.Enabled = false;
            this.tbValor.Location = new System.Drawing.Point(109, 148);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(238, 26);
            this.tbValor.TabIndex = 16;
            // 
            // lbValor
            // 
            this.lbValor.AutoSize = true;
            this.lbValor.Location = new System.Drawing.Point(12, 151);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(33, 15);
            this.lbValor.TabIndex = 6;
            this.lbValor.Text = "Valor";
            // 
            // lbDtTermino
            // 
            this.lbDtTermino.AutoSize = true;
            this.lbDtTermino.Location = new System.Drawing.Point(12, 122);
            this.lbDtTermino.Name = "lbDtTermino";
            this.lbDtTermino.Size = new System.Drawing.Size(92, 15);
            this.lbDtTermino.TabIndex = 7;
            this.lbDtTermino.Text = "Data de término";
            // 
            // lbDtInicio
            // 
            this.lbDtInicio.AutoSize = true;
            this.lbDtInicio.Location = new System.Drawing.Point(12, 93);
            this.lbDtInicio.Name = "lbDtInicio";
            this.lbDtInicio.Size = new System.Drawing.Size(79, 15);
            this.lbDtInicio.TabIndex = 8;
            this.lbDtInicio.Text = "Data de início";
            // 
            // tbIdImovel
            // 
            this.tbIdImovel.Enabled = false;
            this.tbIdImovel.Location = new System.Drawing.Point(109, 61);
            this.tbIdImovel.Name = "tbIdImovel";
            this.tbIdImovel.Size = new System.Drawing.Size(238, 26);
            this.tbIdImovel.TabIndex = 13;
            // 
            // lbIdImovel
            // 
            this.lbIdImovel.AutoSize = true;
            this.lbIdImovel.Location = new System.Drawing.Point(12, 64);
            this.lbIdImovel.Name = "lbIdImovel";
            this.lbIdImovel.Size = new System.Drawing.Size(74, 15);
            this.lbIdImovel.TabIndex = 9;
            this.lbIdImovel.Text = "ID do imóvel";
            // 
            // tbIdApolice
            // 
            this.tbIdApolice.Location = new System.Drawing.Point(109, 6);
            this.tbIdApolice.Name = "tbIdApolice";
            this.tbIdApolice.Size = new System.Drawing.Size(238, 26);
            this.tbIdApolice.TabIndex = 12;
            // 
            // lbIdApolice
            // 
            this.lbIdApolice.AutoSize = true;
            this.lbIdApolice.Location = new System.Drawing.Point(12, 9);
            this.lbIdApolice.Name = "lbIdApolice";
            this.lbIdApolice.Size = new System.Drawing.Size(75, 15);
            this.lbIdApolice.TabIndex = 10;
            this.lbIdApolice.Text = "ID da apólice";
            // 
            // btAtualizar
            // 
            this.btAtualizar.Enabled = false;
            this.btAtualizar.Location = new System.Drawing.Point(353, 148);
            this.btAtualizar.Name = "btAtualizar";
            this.btAtualizar.Size = new System.Drawing.Size(149, 44);
            this.btAtualizar.TabIndex = 11;
            this.btAtualizar.Text = "Atualizar";
            this.btAtualizar.UseVisualStyleBackColor = true;
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(353, 6);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(149, 44);
            this.btPesquisar.TabIndex = 17;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            // 
            // AtualizacaoApolice
            // 
            this.ClientSize = new System.Drawing.Size(510, 202);
            this.Controls.Add(btPesquisar);
            this.Controls.Add(dtTermino);
            this.Controls.Add(dtInicio);
            this.Controls.Add(tbValor);
            this.Controls.Add(lbValor);
            this.Controls.Add(lbDtTermino);
            this.Controls.Add(lbDtInicio);
            this.Controls.Add(tbIdImovel);
            this.Controls.Add(lbIdImovel);
            this.Controls.Add(tbIdApolice);
            this.Controls.Add(lbIdApolice);
            this.Controls.Add(btAtualizar);
            this.Name = "AtualizacaoApolice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}