namespace Api.Entities
{
    public class ConversionTipoCambio
    {
        public decimal Monto { get; set; }
        public string MontoTipoCambio { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public decimal TipoCambio { get; set; }
    }
}
