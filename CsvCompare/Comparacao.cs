namespace CsvCompare
{
    public class Comparacao
    {
        public string Cnpj { get; set; }
        public string Nota { get; set; }
        public double ValorSefaz { get; set; }
        public double? ValorEscritura { get; set; }
        public string Cfop { get; set; }
        public string Resultado { get; set; }

        public Comparacao()
        {

        }

        public Comparacao(string cnpj, string nota, double valorSefaz, double? valorEscritura, string cfop, string resultado)
        {
            Cnpj = cnpj;
            Nota = nota;
            ValorSefaz = valorSefaz;
            ValorEscritura = valorEscritura;
            Cfop = cfop;
            Resultado = resultado;
        }
    }
}
