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
            AddDefaultData();

            InitializeComponent();
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var script = @$"
                    INSERT INTO apolice (id_apolice, id_imovel, dt_inicio, dt_termino, valor_apolice) 
                    VALUES ({tbIdApolice.Text}, {tbIdImovel.Text}, '{dtInicio.Text}', '{dtTermino.Text}', {tbValor.Text})";

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