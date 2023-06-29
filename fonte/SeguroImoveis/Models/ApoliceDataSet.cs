using System;

namespace SeguroImoveis.Models
{
    public class ApoliceDataSet
    {
        public string Cliente { get; set; }
        public string DtInicio { get; set; }
        public string DtTermino { get; set; }
        public string Valor { get; set; }
        public string Imovel { get; set; }
        public string Sinistro { get; set; }
        public string Cobertura { get; set; }
        public string Vigente { get; set; }

        public ApoliceDataSet(
            string cliente,
            string dtInicio,
            string dtTermino,
            string valor,
            string imovel,
            string sinistro,
            string cobertura,
            string vigente)
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
