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
            _conexao = new MySqlConnection("Server=localhost;Database=seguradora_imovel;Uid=root;Pwd=;");

            CreateTables();
            AddDefaultData();

            InitializeComponent();
        }

        private void btCadastroApolice_Click(object sender, EventArgs e)
        {
            new CadastroApolice(_conexao).ShowDialog();
        }

        private void btEditarApolice_Click(object sender, EventArgs e)
        {
            new AtualizacaoApolice(_conexao).ShowDialog();
        }

        private void CreateTables()
        {
            try
            {
                ExecuteCommand(DatabaseUtils.GetScript("ddl.sql"));
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
                ExecuteCommand(DatabaseUtils.GetScript("insert.sql"));
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

        private void ExecuteCommand(string script)
        {
            var command = new MySqlCommand(script, _conexao);

            _conexao.Open();

            command.ExecuteReader();
        }
    }
}
