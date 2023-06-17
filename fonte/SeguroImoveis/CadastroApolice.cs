using MySql.Data.MySqlClient;

namespace SeguroImoveis
{
    public partial class CadastroApolice : Form
    {
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
                var script = @$"
                    INSERT INTO apolice (id_apolice, id_imovel, dt_inicio, dt_termino, valor_apolice) 
                    VALUES ({tbIdApolice.Text}, {tbIdImovel.Text}, '{dtInicio.Text}', '{dtTermino.Text}', {tbValor.Text})";

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
    }
}