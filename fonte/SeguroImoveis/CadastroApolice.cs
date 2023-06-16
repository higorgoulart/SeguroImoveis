using MySql.Data.MySqlClient;
using SeguroImoveis.Utils;

namespace SeguroImoveis
{
    public partial class CadastroApolice : Form
    {
        private readonly MySqlConnection _conexao;

        public CadastroApolice()
        {
            _conexao = new MySqlConnection("Server=localhost;Database=seguradora_imovel;Uid=root;Pwd=;");

            CreateTables();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var script = $"INSERT INTO apolice (nome) VALUES ('{textBox1.Text}')";

                ExecuteCommand(script);

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

        private void ExecuteCommand(string sqlInsert)
        {
            var command = new MySqlCommand(sqlInsert, _conexao);

            _conexao.Open();

            command.ExecuteReader();
        }
    }
}