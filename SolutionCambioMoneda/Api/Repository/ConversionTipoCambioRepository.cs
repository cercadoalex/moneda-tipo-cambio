using Api.Entities;
using Api.Interfaces;

namespace Api.Repository
{
    public class ConversionTipoCambioRepository : IConversionTipoCambio
    {
        readonly ITablaConversion _tabaConversion;
        readonly IDivisa _divisa;
        public ConversionTipoCambioRepository(IDivisa divisa, ITablaConversion tablaConversion)
        {
            _divisa = divisa;
            _tabaConversion = tablaConversion;
        }
        public ConversionTipoCambio PostConvertirCambio(string isoOrigen, string isoDestino, decimal monto)
        {
            var divisa = _divisa.GetDivisabyIso(isoDestino);
            var valorOrigen = _tabaConversion.GetOrigenUSSD(isoOrigen);
            var valorDestino = _tabaConversion.GetDestinoUSSD(isoDestino);
            var calculo = valorOrigen * monto;
            var resultado = calculo * valorDestino;
            var valorTipoCambio = calculo * valorDestino / monto;
            var montoTipoCambio = $"{resultado} {divisa.Descripcion}";
            return new ConversionTipoCambio { Monto = monto, MontoTipoCambio = montoTipoCambio, MonedaOrigen = isoOrigen, MonedaDestino = isoDestino, TipoCambio = valorTipoCambio };
        }
    }
}
