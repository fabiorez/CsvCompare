using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsvCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Criando um DataTable
            DataTable dt = new DataTable();

            //Lendo Todas as linhas do arquivo CSV
            string[] Linha = System.IO.File.ReadAllLines(@"C:\Projetos GIT\MeuCSV.csv");

            //Neste For, vamos percorrer todas as linhas que foram lidas do arquivo CSV
            for (Int32 i = 0; i < Linha.Length; i++)
            {
                //Aqui Estamos pegando a linha atual, e separando os campos
                //Por exemplo, ele vai lendo um texto, e quando achar um ponto e virgula
                //ele pega o texto e joga na outra posição do array temp, e assim por diante
                //até chegar no final da linha
                string[] campos = Linha[i].Split(Convert.ToChar(";"));

                //Um datable precisa de colunas
                //Como a função acima jogou cada campo em uma posição do array de acordo com
                //o ponto e virgula, eu estou pegando quantos campos ele achou e criando a mesma
                //quantidade de colunas no datatable para corresponder a cada campo
                if (i == 0)
                {
                    for (Int32 i2 = 0; i2 < campos.Length; i2++)
                    {
                        //Criando uma coluna
                        DataColumn col = new DataColumn();
                        //Adicionando a coluna criada ao datatable
                        dt.Columns.Add(col);
                    }
                }

                //Inserindo uma linha(row) no datable (Vai fazer isso para cada linha encontrada
                //no arquivo CSV
                dt.Rows.Add(campos);
            }

            //Depois de montado o datatable, vamos falar para o grid
            //que a fonte de dados para ele exibir, será o datatable que 
            //a gente acabou de criar
            dgvFiles.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtFile1.Text = openFileDialog1.FileName;
            BindDataCSV(txtFile1.Text);
        }

        private void BindDataCSV(string filePath)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                //primeira linha cria header
                string firstLine = lines[0];
                string[] headerLabels = firstLine.Split(';');
                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }

                for (int r = 1; r < lines.Length; r++)
                {
                    string[] dataWords = lines[r].Split(';');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;

                    foreach(string headerWord in headerLabels)
                    {
                        dr[headerWord] = dataWords[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if(dt.Rows.Count>0)
            {
                dgvFiles.DataSource = dt;
            }
        }
    }
}
