using Api.Entities;
using Api.Entities.Request;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class TablaConversionRepository : ITablaConversion
    {
        public TablaConversionRepository()
        {
            using (var context = new ApiContext())
            {
                var list = context.TablaConversions.ToList();
                if (list.Count == 0)
                {
                    var conversiones = new List<TablaConversion>
                {
                    new TablaConversion { ISO = "EURO",Descripcion="Euro" ,InUSSD=1.09m ,PerUSSD=0.92m},
                    new TablaConversion { ISO = "MXN",Descripcion="Pesos Mexicanos",InUSSD=0.055m ,PerUSSD=18.16m},
                    new TablaConversion { ISO = "COP",Descripcion="Pesos Colombianos",InUSSD=0.00022m ,PerUSSD=4559.25m},
                    new TablaConversion { ISO = "BRL",Descripcion="Real Brazileño",InUSSD=0.2m ,PerUSSD=5.07m},
                    new TablaConversion { ISO = "PEN",Descripcion="Sol Peruano",InUSSD=0.27m ,PerUSSD=3.75m},
                    new TablaConversion { ISO = "USD",Descripcion="Dolares",InUSSD=1m ,PerUSSD=1m}
                };
                    context.TablaConversions.AddRange(conversiones);
                    context.SaveChanges();
                }
            }
        }
        public decimal GetOrigenUSSD(string iso)
        {
            using (var context = new ApiContext())
            {
                return context.TablaConversions.Where(x => x.ISO == iso.Trim()).Select(x => x.InUSSD).FirstOrDefault();
            }
        }

        public decimal GetDestinoUSSD(string iso)
        {
            using (var context = new ApiContext())
            {
                return context.TablaConversions.Where(x => x.ISO == iso.Trim()).Select(x => x.PerUSSD).FirstOrDefault();
            }
        }

        public int Actualizar(RequestTablaConversion tabla)
        {

            tabla.InUSSD = 1 / tabla.PerUSSD;
            int flag = 0;
            using (var context = new ApiContext())
            {
                try
                {
                    var item = context.TablaConversions.Where(x => x.ISO == tabla.ISO).AsNoTracking().FirstOrDefault();
                    var conversion = new TablaConversion { TablaConversionId = item.TablaConversionId, ISO = item.ISO, Descripcion = item.Descripcion, InUSSD = tabla.InUSSD, PerUSSD = tabla.PerUSSD };
                    context.Update(conversion);
                    flag = context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }

            return flag;
        }
    }
}
