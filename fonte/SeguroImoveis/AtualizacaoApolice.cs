using MySql.Data.MySqlClient;
using SeguroImoveis.Utils;

namespace SeguroImoveis
{
    public partial class AtualizacaoApolice : Form
    {
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

                var script = @$"
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
                var script = @$"
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
    }
}