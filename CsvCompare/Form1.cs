using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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

            public static ArquivoSefaz FromCsv(string csvLine)
            {
                string[] values = csvLine.Split(';');

                if (!string.IsNullOrEmpty(values[0]))
                {
                    if (!values[0].Contains("/"))
                    {
                        if (values.Count() > 2)
                        {
                            ArquivoSefaz arquivo = new ArquivoSefaz();
                            arquivo.SefazNota = values[0].ToString();
                            arquivo.SefazSerie = values[1].ToString();
                            arquivo.SefazCnpj = values[3].ToString();
                            if (values.Count() > 29)
                            {
                                arquivo.SefazValor = values[29].Replace(".", "");
                            }
                            else
                            {
                                arquivo.SefazValor = "0";
                            }
                            return arquivo;
                        }
                    }
                }
                return null;
            }
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
            public string Resultado { get; set; }

            public Comparacao()
            {

            }

            public Comparacao(string cnpj, string nota, string valorSefaz, string valorEscritura, string resultado)
            {
                Cnpj = cnpj;
                Nota = nota;
                ValorSefaz = valorSefaz;
                ValorEscritura = valorEscritura;
                Resultado = resultado;
            }

        }

        #endregion

        #region botoes

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtSefaz.Text = openFileDialog1.FileName;
            CarregaArquivoSefaz(txtSefaz.Text);
        }

        private void BtnFile2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            txtSe.Text = openFileDialog2.FileName;
            CarregaArquivoEscritura(txtSe.Text);
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            LimparDatagrid();

            btnCompare.Text = "Aguarde";
            btnCompare.Enabled = false;

            bool ehvalido = ValidarInformacoes();

            if (ehvalido)
            {
                List<Comparacao> resultado = CompararArquivos();

                dgvFiles.DataSource = resultado;

                AjustarNomeColunas();
            }

            btnCompare.Text = "Compare";
            btnCompare.Enabled = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Não implementado");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Não implementado");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidade Não Implementada");
        }

        #endregion

        #region Metodos de Apoio

        public void AjustarNomeColunas()
        {
            dgvFiles.Columns[0].HeaderText = "CNPJ";
            dgvFiles.Columns[1].HeaderText = "N.º DA NOTA";
            dgvFiles.Columns[2].HeaderText = "VALOR SEFAZ";
            dgvFiles.Columns[3].HeaderText = "VALOR S.ESCRITURA";
            dgvFiles.Columns[4].HeaderText = "RESULTADO";
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

        private void CarregaArquivoEscritura(string filePath)
        {
            try
            {
                valuesEscritura = File.ReadAllLines(filePath)
                                               .Select(v => ArquivoEscritura.FromCsv(v))
                                               .ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar o arquivo, tente novamente");
                txtSe.Text = "";
            }
        }

        private void CarregaArquivoSefaz(string filePath)
        {
            try
            {
                valuesSefaz = File.ReadAllLines(filePath)
                                               .Skip(1)
                                               .Select(v => ArquivoSefaz.FromCsv(v))
                                               .ToList();
            }
            catch (Exception)
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
            else if (!txtSefaz.Text.Contains("RECEBIMENTO_NFE"))
            {
                ehvalido = false;
                MessageBox.Show("Arquivo do sefaz inválido.");
            }
            else if (!txtSe.Text.Contains("DW_NFE"))
            {
                ehvalido = false;
                MessageBox.Show("Arquivo Escritura inválido");
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
                        resultado.Add(new Comparacao(sefaz.SefazCnpj, sefaz.SefazNota + "-" + sefaz.SefazSerie, sefaz.SefazValor, "", "Nota Inexistente"));
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

                    foreach (var escritura in valuesEscritura)
                    {
                        string notaSefaz = sefaz.SefazNota + sefaz.SefazSerie;
                        string notaEscritura = escritura.EscrituraNota + escritura.EscrituraSerie;

                        if (notaSefaz == notaEscritura)
                        {
                            if (Convert.ToDecimal(sefaz.SefazValor) == Convert.ToDecimal(escritura.EscrituraValor))
                            {
                                ehDiferente = false;
                            }
                            else
                            {
                                valorEscritura = escritura.EscrituraValor;
                            }
                        }
                    }

                    if (ehDiferente)
                    {
                        resultado.Add(new Comparacao(sefaz.SefazCnpj, sefaz.SefazNota + "-" + sefaz.SefazSerie, sefaz.SefazValor, valorEscritura, "Divergencia de valor"));
                        qtdeDivergentes++;
                    }
                }
            }

            lblDivergentes.Text = qtdeDivergentes.ToString();
        }

        #endregion

    }
}
