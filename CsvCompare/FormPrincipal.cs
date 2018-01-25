using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CsvCompare
{
    public partial class FormPrincipal : Form
    {

        #region variaveis globais
        List<ArquivoSefaz> valuesSefaz = new List<ArquivoSefaz>();
        List<ArquivoEscritura> valuesEscritura = new List<ArquivoEscritura>();
        List<Comparacao> resultado = new List<Comparacao>();
        #endregion

        #region Formulario

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            AlterarCorDatagrid(dgvFiles);
        }

        #endregion

        #region botoes

        private void BtnSefaz_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtSefaz.Text = openFileDialog1.FileName;
            LimparDatagrid();
            if (ValidaSefaz())
            {
                BloqueiaAplicacao();
                CarregaArquivoSefaz(txtSefaz.Text);
                DesbloqueiaAplicacao();
            }
        }

        private void BtnSe_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            txtSe.Text = openFileDialog2.FileName;
            LimparDatagrid();
            if (ValidaSe())
            {
                BloqueiaAplicacao();
                CarregaArquivoEscritura(txtSe.Text);
                DesbloqueiaAplicacao();
            }
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            resultado.Clear();

            LimparDatagrid();

            BloqueiaAplicacao();

            bool ehvalido = ValidarInformacoes();

            if (ehvalido)
            {
                if (lblTotalXls.Text != valuesSefaz.Count.ToString())
                {
                    CarregaArquivoSefaz(txtSefaz.Text);
                }
                resultado = CompararArquivos();

                dgvFiles.DataSource = resultado;

                AjustarNomeColunas();

                GerarExcel();
            }

            DesbloqueiaAplicacao();

        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade Não Implementada");
        }

        private void BtnExportarExcel_Click(object sender, EventArgs e)
        {
            BloqueiaAplicacao();
            GerarExcel();
            DesbloqueiaAplicacao();
        }
        #endregion

        #region Metodos de Apoio

        public void AjustarNomeColunas()
        {
            dgvFiles.Columns[0].HeaderText = "CNPJ";
            dgvFiles.Columns[1].HeaderText = "N.º DA NOTA";
            dgvFiles.Columns[2].HeaderText = "VALOR SEFAZ";
            dgvFiles.Columns[3].HeaderText = "VALOR S. ESCRITURA";
            dgvFiles.Columns[4].HeaderText = "CFOP";
            dgvFiles.Columns[5].HeaderText = "RESULTADO";
        }

        public void AlterarCorDatagrid(DataGridView dgv)
        {
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void BloqueiaAplicacao()
        {
            btnSefaz.Enabled = false;
            btnExportar.Enabled = false;
            btnCompare.Enabled = false;
            btnSe.Enabled = false;
            btnExportarExcel.Enabled = false;
            lblAguarde.Visible = true;
        }

        private void CarregaArquivoEscritura(string filePath)
        {
            try
            {
                valuesEscritura = File.ReadAllLines(filePath)
                                               .Select(v => ArquivoEscritura.FromCsv(v))
                                               .ToList();

                lblTotalCsv.Text = valuesEscritura.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar o arquivo, tente novamente");
                txtSe.Text = "";
                var erro = ex;
            }
        }

        private void CarregaArquivoSefaz(string filePath)
        {
            valuesSefaz.Clear();

            try
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(filePath);
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                Excel.Range range = worksheet.UsedRange;


                for (int row = 2; row <= range.Rows.Count; row++)
                {
                    ArquivoSefaz sefaz = new ArquivoSefaz();
                    sefaz.SefazNota = ((Excel.Range)range.Cells[row, 1]).Text;
                    sefaz.SefazSerie = ((Excel.Range)range.Cells[row, 2]).Text;
                    sefaz.SefazCnpj = ((Excel.Range)range.Cells[row, 4]).Text;
                    sefaz.SefazCfop = ((Excel.Range)range.Cells[row, 24]).Text;
                    sefaz.SefazValor = Convert.ToDouble((((Excel.Range)range.Cells[row, 30]).Text).ToString().Replace(".", "").Replace(",", "."));

                    valuesSefaz.Add(sefaz);
                }

                lblTotalXls.Text = valuesSefaz.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar o arquivo, tente novamente");
                txtSefaz.Text = "";
                var erro = ex;
            }
        }

        private List<Comparacao> CompararArquivos()
        {
            List<Comparacao> resultado = new List<Comparacao>();
            VerificaNotaInexistente(resultado);
            VerificaValoresDivergentes(resultado);

            return resultado.OrderBy(x => x.Resultado).ThenBy(y => y.Nota).ToList();
        }

        private void DesbloqueiaAplicacao()
        {
            btnSefaz.Enabled = true;
            btnExportar.Enabled = true;
            btnCompare.Enabled = true;
            btnSe.Enabled = true;
            btnExportarExcel.Enabled = true;
            lblAguarde.Visible = false;
        }

        private void GerarExcel()
        {
            if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
            {
                ArquivoExcelComparativo arq = new ArquivoExcelComparativo(resultado);
                arq.GerarArquivo(saveFileDialogExcel.FileName);
                MessageBox.Show("O arquivo " + saveFileDialogExcel.FileName + " foi gerado com sucesso!");
            }
        }

        private void LimparDatagrid()
        {
            dgvFiles.Columns.Clear();
            dgvFiles.Refresh();
        }

        private bool ValidarInformacoes()
        {
            bool ehvalido = true;

            if (txtSefaz.Text == "" || txtSe.Text == "")
            {
                ehvalido = false;
                MessageBox.Show("Favor selecionar os dois arquivos para que possa ser feita a comparação");
            }

            else if (txtSefaz.Text == txtSe.Text)
            {
                ehvalido = false;
                MessageBox.Show("Você escolheu o mesmo arquivo para comparar. Selecione novamente 2 arquivos diferentes");
            }

            return ehvalido;
        }

        private bool ValidaSe()
        {
            bool ehValido = true;

            if (!txtSe.Text.Contains("DW_NFE"))
            {
                txtSe.Text = "";
                MessageBox.Show("Arquivo do recebimento inválido.");
                ehValido = false;
            }

            return ehValido;
        }

        private bool ValidaSefaz()
        {
            bool ehvalido = true;

            if (!txtSefaz.Text.Contains("RECEBIMENTO_NFE"))
            {
                txtSefaz.Text = "";
                MessageBox.Show("Arquivo do sefaz inválido.");
                ehvalido = false;
            }

            return ehvalido;
        }

        private void VerificaNotaInexistente(List<Comparacao> resultado)
        {
            List<ArquivoSefaz> listaRemovidos = new List<ArquivoSefaz>();

            foreach (ArquivoSefaz sefaz in valuesSefaz)
            {
                if (sefaz != null && !string.IsNullOrEmpty(sefaz.SefazCnpj))
                {
                    bool ehInexistente = true;

                    foreach (var escritura in valuesEscritura)
                    {
                        string notaSefaz = sefaz.SefazNota + sefaz.SefazSerie;
                        string notaEscritura = escritura.EscrituraNota + escritura.EscrituraSerie;

                        if (notaSefaz == notaEscritura)
                        {
                            ehInexistente = false;
                        }
                    }

                    if (ehInexistente)
                    {
                        resultado.Add(new Comparacao(sefaz.SefazCnpj, sefaz.SefazNota + "-" + sefaz.SefazSerie, sefaz.SefazValor, null, sefaz.SefazCfop, "Nota Inexistente"));
                        listaRemovidos.Add(sefaz);
                    }
                }
                lblInexistentes.Text = resultado.Count().ToString();
            }

            valuesSefaz.RemoveAll(i => listaRemovidos.Contains(i));
        }

        private void VerificaValoresDivergentes(List<Comparacao> resultado)
        {
            int qtdeDivergentes = 0;

            foreach (ArquivoSefaz sefaz in valuesSefaz)
            {
                if (sefaz != null && !string.IsNullOrEmpty(sefaz.SefazCnpj))
                {
                    bool ehDiferente = true;
                    double valorEscritura = 0;
                    double valorSefaz = 0;

                    foreach (var escritura in valuesEscritura)
                    {
                        string notaSefaz = sefaz.SefazNota + sefaz.SefazSerie;
                        string notaEscritura = escritura.EscrituraNota + escritura.EscrituraSerie;

                        if (notaSefaz == notaEscritura)
                        {
                            valorEscritura = Math.Round(escritura.EscrituraValor, 2);
                            valorSefaz = Math.Round(sefaz.SefazValor, 2);

                            if (valorSefaz == valorEscritura)
                            {
                                ehDiferente = false;
                            }
                        }
                    }

                    if (ehDiferente)
                    {
                        resultado.Add(new Comparacao(sefaz.SefazCnpj, sefaz.SefazNota + "-" + sefaz.SefazSerie, valorSefaz, valorEscritura, sefaz.SefazCfop, "Divergencia de valor"));
                        qtdeDivergentes++;
                    }
                }
            }

            lblDivergentes.Text = qtdeDivergentes.ToString();
        }

        private void DgvFiles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvFiles.Columns[2].DefaultCellStyle.Format = "C2";
                dgvFiles.Columns[3].DefaultCellStyle.Format = "C2";
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
