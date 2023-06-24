using System;

namespace SeguroImoveis.Models
{
    public class ApoliceDataSet
    {
        public string Cliente { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtTermino { get; set; }
        public decimal Valor { get; set; }
        public string Imovel { get; set; }
        public bool Sinistro { get; set; }
        public string Cobertura { get; set; }
        public bool Vigente { get; set; }

        public ApoliceDataSet(
            string cliente,
            DateTime dtInicio,
            DateTime dtTermino,
            decimal valor,
            string imovel,
            bool sinistro,
            string cobertura,
            bool vigente)
        {
            Cliente = cliente;
            DtInicio = dtInicio;
            DtTermino = dtTermino;
            Valor = valor;
            Imovel = imovel;
            Sinistro = sinistro;
            Cobertura = cobertura;
            Vigente = vigente;
        }
    }
}
