using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SeguroImoveis
{
    public partial class Relatorio : Form
    {
        private ReportViewer reportViewer1;
        private DateTimePicker dtTermino;
        private DateTimePicker dtInicio;
        private Label lbDtTermino;
        private Label lbDtInicio;
        private Button btPesquisar;
        private readonly MySqlConnection _conexao;

        public Relatorio(MySqlConnection conexao)
        {
            _conexao = conexao;
            InitializeComponent();

            //Customers dsCustomers = GetData();
            //ReportDataSource datasource = new ReportDataSource("Customers", dsCustomers.Tables[0]);
            //this.reportViewer.LocalReport.DataSources.Clear();
            //this.reportViewer.LocalReport.DataSources.Add(datasource);
            reportViewer1.RefreshReport();
        }

        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtTermino = new System.Windows.Forms.DateTimePicker();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.lbDtTermino = new System.Windows.Forms.Label();
            this.lbDtInicio = new System.Windows.Forms.Label();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportPath = "Relatorio.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 77);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1016, 263);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtTermino
            // 
            this.dtTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTermino.Location = new System.Drawing.Point(139, 44);
            this.dtTermino.Margin = new System.Windows.Forms.Padding(4);
            this.dtTermino.Name = "dtTermino";
            this.dtTermino.Size = new System.Drawing.Size(301, 26);
            this.dtTermino.TabIndex = 8;
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(138, 5);
            this.dtInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(301, 26);
            this.dtInicio.TabIndex = 7;
            // 
            // lbDtTermino
            // 
            this.lbDtTermino.AutoSize = true;
            this.lbDtTermino.Location = new System.Drawing.Point(13, 48);
            this.lbDtTermino.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDtTermino.Name = "lbDtTermino";
            this.lbDtTermino.Size = new System.Drawing.Size(123, 20);
            this.lbDtTermino.TabIndex = 5;
            this.lbDtTermino.Text = "Data de término";
            // 
            // lbDtInicio
            // 
            this.lbDtInicio.AutoSize = true;
            this.lbDtInicio.Location = new System.Drawing.Point(13, 9);
            this.lbDtInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDtInicio.Name = "lbDtInicio";
            this.lbDtInicio.Size = new System.Drawing.Size(105, 20);
            this.lbDtInicio.TabIndex = 6;
            this.lbDtInicio.Text = "Data de início";
            // 
            // btPesquisar
            // 
            this.btPesquisar.Location = new System.Drawing.Point(835, 9);
            this.btPesquisar.Margin = new System.Windows.Forms.Padding(4);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(192, 59);
            this.btPesquisar.TabIndex = 9;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // Relatorio
            // 
            this.ClientSize = new System.Drawing.Size(1040, 352);
            this.Controls.Add(this.btPesquisar);
            this.Controls.Add(this.dtTermino);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.lbDtTermino);
            this.Controls.Add(this.lbDtInicio);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Relatorio";
            this.Load += new System.EventHandler(this.Relatorio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Relatorio_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            this.reportViewer1.DataBindings.Clear();
            this.reportViewer1.RefreshReport();
        }
    }
}
