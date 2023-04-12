using Api.Entities;

namespace Api.Interfaces
{
    public interface IConversionTipoCambio
    {
        public ConversionTipoCambio PostConvertirCambio(string isoOrigen,string isoDestino,decimal monto);
    }
}
