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
    public partial class Form1 : Form
    {
        #region variaveis globais
        List<ArquivoSefaz> valuesSefaz = new List<ArquivoSefaz>();
        List<ArquivoEscritura> valuesEscritura = new List<ArquivoEscritura>();
        #endregion

        #region Formulario

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AlterarCorDatagrid(dgvFiles);
        }

        #endregion

        #region Classes

        class ArquivoSefaz
        {
            public string SefazNota { get; set; }
            public string SefazSerie { get; set; }
            public string SefazCnpj { get; set; }
            public string SefazValor { get; set; }
            public string SefazCfop { get; set; }

            //public static ArquivoSefaz FromCsv(string csvLine)
            //{
            //    string[] values = csvLine.Split(';');

            //    if (!string.IsNullOrEmpty(values[0]))
            //    {
            //        if (!values[0].Contains("/"))
            //        {
            //            if (values.Count() > 2)
            //            {
            //                ArquivoSefaz arquivo = new ArquivoSefaz();
            //                arquivo.SefazNota = values[0].ToString();
            //                arquivo.SefazSerie = values[1].ToString();
            //                arquivo.SefazCnpj = values[3].ToString();
            //                if(values.Count() > 23)
            //                {
            //                    arquivo.SefazCfop = values[23].ToString();
            //                }
            //                if (values.Count() > 29)
            //                {
            //                    arquivo.SefazValor = values[29].Replace(".", "");
            //                }
            //                else
            //                {
            //                    arquivo.SefazValor = "0";
            //                }
            //                return arquivo;
            //            }
            //        }
            //    }
            //    return null;
            //}
        }

        class ArquivoEscritura
        {
            public string EscrituraCnpj { get; set; }
            public string EscrituraNota { get; set; }
            public string EscrituraSerie { get; set; }
            public string EscrituraValor { get; set; }

            public static ArquivoEscritura FromCsv(string csvLine)
            {
                string[] values = csvLine.Split(',');
                if (values.Count() > 2)
                {
                    ArquivoEscritura arquivo = new ArquivoEscritura();
                    arquivo.EscrituraNota = values[2].ToString();
                    arquivo.EscrituraSerie = values[3].ToString();
                    arquivo.EscrituraValor = values[9].ToString() + "," + values[10].ToString();
                    if (values.Count() > 25)
                    {
                        arquivo.EscrituraCnpj = values[25].ToString();
                    }
                    else
                    {
                        arquivo.EscrituraCnpj = "sem cnpj";
                    }
                    return arquivo;
                }
                return null;
            }
        }

        class Comparacao
        {
            public string Cnpj { get; set; }
            public string Nota { get; set; }
            public string ValorSefaz { get; set; }
            public string ValorEscritura { get; set; }
            public string Cfop { get; set; }
            public string Resultado { get; set; }

            public Comparacao()
            {

            }

            public Comparacao(string cnpj, string nota, string valorSefaz, string valorEscritura, string cfop, string resultado)
            {
                Cnpj = cnpj;
                Nota = nota;
                ValorSefaz = valorSefaz;
                ValorEscritura = valorEscritura;
                Cfop = cfop;
                Resultado = resultado;
            }

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
            LimparDatagrid();

            BloqueiaAplicacao();

            bool ehvalido = ValidarInformacoes();

            if (ehvalido)
            {
                if (lblTotalXls.Text != valuesSefaz.Count.ToString())
                {
                    CarregaArquivoSefaz(txtSefaz.Text);
                }
                List<Comparacao> resultado = CompararArquivos();

                dgvFiles.DataSource = resultado;

                AjustarNomeColunas();

                ExportarParaExcel();
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
            ExportarParaExcel();
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
                    sefaz.SefazValor = (((Excel.Range)range.Cells[row, 30]).Text).ToString().Replace(".", "");

                    valuesSefaz.Add(sefaz);
                }

                lblTotalXls.Text = valuesSefaz.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar o arquivo, tente novamente");
                txtSefaz.Text = "";
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

        private void ExportarParaExcel()
        {
            try
            {
                SaveFileDialog salvar = new SaveFileDialog
                {
                    Filter = "Excel (*.xls)|*.xls",
                    FileName = "ComparativoSefazSe"
                };

                if (salvar.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application app; //aplicacao excel
                    Excel.Workbook wb; //pasta
                    Excel.Worksheet ws; //planilha
                    object misValue = System.Reflection.Missing.Value;

                    app = new Excel.Application();
                    wb = app.Workbooks.Add();
                    ws = (Excel.Worksheet)wb.Worksheets.get_Item(1);

                    //escrevendo linhas
                    for (int i = 0; i < dgvFiles.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dgvFiles.Columns.Count; j++)
                        {
                            if ((dgvFiles.Rows[i].Cells[j].Value == null) == false)
                            {
                                ws.Cells[i + 2, j + 1] = dgvFiles.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    //escrevendo titulo
                    ws.Cells[1, 1] = "CNPJ";
                    ws.Cells[1, 2] = "N.º DA NOTA";
                    ws.Cells[1, 3] = "VALOR SEFAZ";
                    ws.Cells[1, 4] = "VALOR S. ESCRITURA";
                    ws.Cells[1, 5] = "CFOP";
                    ws.Cells[1, 6] = "RESULTADO";

                    //Excel Header
                    var range = ws.get_Range("A1", "F1");
                    range.Font.Color = Color.Gray;
                    range.Font.Size = 12;
                    

                    // salva o arquivo
                    wb.SaveAs(salvar.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                        Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    wb.Close(true, misValue, misValue);
                    app.Quit(); // encerra o excel

                    MessageBox.Show("Exportado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ao exportar as informações devido a: " + ex.ToString());
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
                        resultado.Add(new Comparacao(sefaz.SefazCnpj, sefaz.SefazNota + "-" + sefaz.SefazSerie, sefaz.SefazValor, "", sefaz.SefazCfop, "Nota Inexistente"));
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
                    string valorEscritura = "";
                    string valorSefaz = "";

                    foreach (var escritura in valuesEscritura)
                    {
                        string notaSefaz = sefaz.SefazNota + sefaz.SefazSerie;
                        string notaEscritura = escritura.EscrituraNota + escritura.EscrituraSerie;

                        if (notaSefaz == notaEscritura)
                        {
                            valorEscritura = (Math.Round(Convert.ToDecimal(escritura.EscrituraValor), 2)).ToString();
                            valorSefaz = (Math.Round(Convert.ToDecimal(sefaz.SefazValor), 2)).ToString();

                            if (Math.Round(Convert.ToDecimal(sefaz.SefazValor), 2) == (Math.Round(Convert.ToDecimal(escritura.EscrituraValor), 2)))
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

        #endregion

    }
}
