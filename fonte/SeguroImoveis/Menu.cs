using MySql.Data.MySqlClient;
using SeguroImoveis.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguroImoveis
{
    public partial class Menu : Form
    {
        private readonly MySqlConnection _conexao;

        public Menu()
        {
            _conexao = new MySqlConnection("Server=localhost;Database=seguradora_imovel;Uid=root;Pwd=;Allow User Variables=True;");

            CreateTables();
            AddDefaultData();

            InitializeComponent();
        }

        private void btCadastroApolice_Click(object sender, EventArgs e) => new CadastroApolice(_conexao).ShowDialog();

        private void btEditarApolice_Click(object sender, EventArgs e) => new AtualizacaoApolice(_conexao).ShowDialog();

        private void btExcluirApolice_Click(object sender, EventArgs e) => new ExcluirApolice(_conexao).ShowDialog();

        private void btRelatorio_Click(object sender, EventArgs e) => new Relatorio(_conexao).ShowDialog();

        private void CreateTables()
        {
            try
            {
                var command = new MySqlCommand(DatabaseUtils.GetScript("ddl.sql"), _conexao);

                _conexao.Open();

                command.ExecuteReader();
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

        private void AddDefaultData()
        {
            try
            {
                _conexao.Open();

                var script = $@"SELECT EXISTS (SELECT 1 FROM apolice);";

                var command = new MySqlCommand(script, _conexao);

                using (var cursor = command.ExecuteReader())
                {
                    while (cursor.Read())
                    {
                        if (Convert.ToInt32(cursor[0]) > 0)
                            return;
                    }
                }

                command = new MySqlCommand(DatabaseUtils.GetScript("insert.sql"), _conexao);
                command.ExecuteReader();
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btCadastroApolice = new System.Windows.Forms.Button();
            this.btEditarApolice = new System.Windows.Forms.Button();
            this.btExcluirApolice = new System.Windows.Forms.Button();
            this.btRelatorio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btCadastroApolice
            // 
            this.btCadastroApolice.Location = new System.Drawing.Point(10, 10);
            this.btCadastroApolice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btCadastroApolice.Name = "btCadastroApolice";
            this.btCadastroApolice.Size = new System.Drawing.Size(120, 33);
            this.btCadastroApolice.TabIndex = 0;
            this.btCadastroApolice.Text = "Cadastrar apólice";
            this.btCadastroApolice.UseVisualStyleBackColor = true;
            this.btCadastroApolice.Click += new System.EventHandler(this.btCadastroApolice_Click);
            // 
            // btEditarApolice
            // 
            this.btEditarApolice.Location = new System.Drawing.Point(136, 10);
            this.btEditarApolice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btEditarApolice.Name = "btEditarApolice";
            this.btEditarApolice.Size = new System.Drawing.Size(120, 33);
            this.btEditarApolice.TabIndex = 1;
            this.btEditarApolice.Text = "Editar apólice";
            this.btEditarApolice.UseVisualStyleBackColor = true;
            this.btEditarApolice.Click += new System.EventHandler(this.btEditarApolice_Click);
            // 
            // btExcluirApolice
            // 
            this.btExcluirApolice.Location = new System.Drawing.Point(260, 10);
            this.btExcluirApolice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btExcluirApolice.Name = "btExcluirApolice";
            this.btExcluirApolice.Size = new System.Drawing.Size(120, 33);
            this.btExcluirApolice.TabIndex = 2;
            this.btExcluirApolice.Text = "Excluir apólice";
            this.btExcluirApolice.UseVisualStyleBackColor = true;
            this.btExcluirApolice.Click += new System.EventHandler(this.btExcluirApolice_Click);
            // 
            // btRelatorio
            // 
            this.btRelatorio.Location = new System.Drawing.Point(386, 10);
            this.btRelatorio.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btRelatorio.Name = "btRelatorio";
            this.btRelatorio.Size = new System.Drawing.Size(120, 33);
            this.btRelatorio.TabIndex = 3;
            this.btRelatorio.Text = "Relatório";
            this.btRelatorio.UseVisualStyleBackColor = true;
            this.btRelatorio.Click += new System.EventHandler(this.btRelatorio_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 54);
            this.Controls.Add(this.btRelatorio);
            this.Controls.Add(this.btExcluirApolice);
            this.Controls.Add(this.btEditarApolice);
            this.Controls.Add(this.btCadastroApolice);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        private Button btCadastroApolice;
        private Button btEditarApolice;
        private Button btExcluirApolice;
        private Button btRelatorio;
    }
}
