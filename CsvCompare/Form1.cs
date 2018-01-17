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
        List<Arquivo> values1 = new List<Arquivo>();
        List<Arquivo> values2 = new List<Arquivo>();
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

        class Arquivo
        {
            string colA;
            string colB;
            string colC;
            string colD;
            string colE;
            string colF;
            string colG;
            string colH;
            string colI;
            string colJ;
            string colK;
            string colL;
            string colM;
            string colN;
            string colO;
            string colP;
            string colQ;
            string colR;
            string colS;
            string colT;
            string colU;
            string colV;
            string colW;
            string colX;
            string colY;
            string colZ;
            string colAA;
            string colAB;
            string colAC;
            string colAD;
            string colAE;
            string colAF;
            string colAG;
            string colAH;
            string colAI;
            string colAJ;
            string colAK;
            string colAL;
            string colAM;
            string colAN;
            string colAO;
            string colAP;
            string colAQ;
            string colAR;
            string colAS;
            string colAT;
            string colAU;
            string colAV;
            string colAW;
            string colAX;
            string colAY;
            string colAZ;

            public static Arquivo FromCsv(string csvLine)
            {
                string[] values = csvLine.Split(';');
                if (values.Count() > 2)
                {
                    Arquivo arquivo = new Arquivo();
                    arquivo.colA = values[0].ToString();
                    arquivo.colB = values[1].ToString();
                    arquivo.colC = values[2].ToString();
                    arquivo.colD = values[3].ToString();
                    arquivo.colE = values[4].ToString();
                    arquivo.colF = values[5].ToString();
                    arquivo.colF = values[6].ToString();
                    arquivo.colG = values[7].ToString();
                    arquivo.colH = values[8].ToString();
                    arquivo.colI = values[9].ToString();
                    arquivo.colJ = values[10].ToString();
                    arquivo.colK = values[11].ToString();
                    arquivo.colL = values[12].ToString();
                    arquivo.colM = values[13].ToString();
                    arquivo.colN = values[14].ToString();
                    arquivo.colO = values[15].ToString();
                    arquivo.colP = values[16].ToString();
                    arquivo.colQ = values[17].ToString();
                    arquivo.colR = values[18].ToString();
                    if (values.Count() > 19)
                    {
                        arquivo.colS = values[19].ToString();
                        arquivo.colT = values[20].ToString();
                        arquivo.colU = values[21].ToString();
                        arquivo.colV = values[22].ToString();
                        arquivo.colW = values[23].ToString();
                        arquivo.colX = values[24].ToString();
                        arquivo.colY = values[24].ToString();
                        arquivo.colZ = values[24].ToString();
                        arquivo.colAA = values[25].ToString();
                        arquivo.colAB = values[26].ToString();
                        arquivo.colAC = values[27].ToString();
                        arquivo.colAD = values[28].ToString();
                        arquivo.colAE = values[29].ToString();
                        arquivo.colAF = values[30].ToString();
                        arquivo.colAG = values[31].ToString();
                        arquivo.colAH = values[32].ToString();
                        if (values.Count() > 32)
                        {
                            if (values.Count() > 33)
                            {
                                arquivo.colAI = values[33].ToString();
                                arquivo.colAJ = values[34].ToString();
                                arquivo.colAK = values[35].ToString();
                                arquivo.colAL = values[36].ToString();
                                arquivo.colAM = values[37].ToString();
                                arquivo.colAN = values[38].ToString();
                                arquivo.colAO = values[39].ToString();
                                arquivo.colAP = values[40].ToString();
                                arquivo.colAQ = values[41].ToString();
                                arquivo.colAR = values[42].ToString();
                                arquivo.colAS = values[43].ToString();
                                arquivo.colAT = values[44].ToString();
                                arquivo.colAU = values[45].ToString();
                                arquivo.colAV = values[46].ToString();
                                arquivo.colAW = values[47].ToString();
                                arquivo.colAX = values[48].ToString();
                                arquivo.colAY = values[49].ToString();
                                arquivo.colAZ = values[50].ToString();
                            }
                        }
                    }
                    return arquivo;
                }

                return null;
            }
        }

        class Comparacao
        {
            public string Cnpj { get; set; }
            public string Id { get; set; }
            public string Valor1 { get; set; }
            public string Valor2 { get; set; }
            public string Resultado { get; set; }

            public Comparacao()
            {

            }

            public Comparacao(string cnpj, string id, string valor1, string valor2, string resultado)
            {
                Cnpj = cnpj;
                Id = id;
                Valor1 = valor1;
                Valor2 = valor2;
                Resultado = resultado;
            }

        }

        #endregion

        #region botoes

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtFile1.Text = openFileDialog1.FileName;
            CarregaArquivo(txtFile1.Text);
        }

        private void BtnFile2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            txtFile2.Text = openFileDialog2.FileName;
            CarregaArquivo2(txtFile2.Text);
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            List<Comparacao> resultado = CompararArquivosFake();

            dgvFiles.DataSource = resultado;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Metodos de Apoio

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

        private void CarregaArquivo(string filePath)
        {
            try
            {
            values1 = File.ReadAllLines(filePath)
                                           .Select(v => Arquivo.FromCsv(v))
                                           .ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar o arquivo, tente novamente");
            }
        }

        private void CarregaArquivo2(string filePath)
        {
            try
            {
            values2 = File.ReadAllLines(filePath)
                                           .Skip(1)
                                           .Select(v => Arquivo.FromCsv(v))
                                           .ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar o arquivo, tente novamente");
            }
        }

        private List<Comparacao> CompararArquivosFake()
        {
            //precisa implementar
            var teste = values1;
            var tst = values2;
            List<Comparacao> resultado = new List<Comparacao>();
            resultado.Add(new Comparacao("1234", "1", "25,42", "26,42", "Valor Divergente"));
            resultado.Add(new Comparacao("1235", "2", "28", "", "Nao encontrado"));
            resultado.Add(new Comparacao("1236", "3", "150", "", "Nao encontrado"));
            resultado.Add(new Comparacao("1237", "4", "30,25", "26,42", "Valor Divergente"));

            return resultado;
        }

        #endregion

    }
}
