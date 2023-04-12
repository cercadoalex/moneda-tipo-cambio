using Api.Entities;
using Api.Entities.Request;

namespace Api.Interfaces
{
    public interface ITablaConversion
    {

       // CUANTOS DOLARES HAY EN UN "TIPO DE MONEDA"
        public decimal GetOrigenUSSD(string iso);


        // CUANTOS "TIPO DE MONEDA"  ME DARIAN POR 1 DOLAR 
        public decimal GetDestinoUSSD(string iso);


        public int Actualizar(RequestTablaConversion tabla);

    }
}
