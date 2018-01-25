using System;
using System.Linq;

namespace CsvCompare
{
    public class ArquivoEscritura
    {
        public string EscrituraCnpj { get; set; }
        public string EscrituraNota { get; set; }
        public string EscrituraSerie { get; set; }
        public double EscrituraValor { get; set; }

        public static ArquivoEscritura FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            if (values.Count() > 2)
            {
                ArquivoEscritura arquivo = new ArquivoEscritura();
                arquivo.EscrituraNota = values[2].ToString();
                arquivo.EscrituraSerie = values[3].ToString();
                arquivo.EscrituraValor = Convert.ToDouble(values[9] + "." + values[10]);
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
}
