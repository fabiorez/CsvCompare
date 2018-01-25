using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace CsvCompare
{
    public class ArquivoExcelComparativo
    {
        private List<Comparacao> _comparacao;
        private string _nomeArquivo;
        private HSSFWorkbook _workbookCatalogo;

        public ArquivoExcelComparativo(List<Comparacao> comparacao)
        {
            this._comparacao = comparacao;
        }

        public void GerarArquivo(string nomeArquivo)
        {
            this._nomeArquivo = nomeArquivo;

            FileStream file = new FileStream(ConfigurationManager
                .AppSettings["TemplateArquivoExcelComparacao"],
                    FileMode.Open, FileAccess.Read);
            _workbookCatalogo = new HSSFWorkbook(file);

            PreencherInformacoesComparacao();
            FinalizarGravacaoArquivo();
        }

        private void PreencherInformacoesComparacao()
        {
            ISheet sheetCatalogo =
                _workbookCatalogo.GetSheet("Comparativo");

            int numeroProximaLinha = 3;
            foreach (Comparacao compara in _comparacao)
            {
                sheetCatalogo.GetCell(numeroProximaLinha, 1)
                    .SetCellValue(compara.Cnpj);
                sheetCatalogo.GetCell(numeroProximaLinha, 2)
                    .SetCellValue(compara.Nota);
                sheetCatalogo.GetCell(numeroProximaLinha, 3)
                    .SetCellValue(compara.ValorSefaz);
                sheetCatalogo.GetCell(numeroProximaLinha, 4)
                    .SetCellValue(Math.Round(Convert.ToDouble(compara.ValorEscritura), 2));
                sheetCatalogo.GetCell(numeroProximaLinha, 5)
                    .SetCellValue(compara.Cfop);
                sheetCatalogo.GetCell(numeroProximaLinha, 6)
                    .SetCellValue(compara.Resultado);
                numeroProximaLinha++;
            }
        }

        public void FinalizarGravacaoArquivo()
        {
            using (FileStream file = new FileStream(
                _nomeArquivo, FileMode.Create))
            {
                _workbookCatalogo.Write(file);
                file.Close();
            }
        }
    }
}
