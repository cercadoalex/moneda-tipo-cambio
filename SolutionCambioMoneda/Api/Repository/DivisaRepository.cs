using Api.Entities;
using Api.Interfaces;

namespace Api.Repository
{
    public class DivisaRepository : IDivisa
    {
        public DivisaRepository()
        {
            using (var context = new ApiContext())
            {
                var list = context.Divisas.ToList();
                if (list.Count == 0)
                {
                    var divisas = new List<Divisa>
                {
                    new Divisa { ISO = "EUR",Descripcion="Euro",ISOCorto="FR"},
                    new Divisa { ISO = "MXN",Descripcion="Pesos Mexicanos",ISOCorto="MX"},
                    new Divisa { ISO = "COP",Descripcion="Pesos Colombianos",ISOCorto="CO"},
                    new Divisa { ISO = "BRL",Descripcion="Real Brazileño",ISOCorto="BR"},
                    new Divisa { ISO = "PEN",Descripcion="Sol Peruano",ISOCorto="PE"},
                    new Divisa { ISO = "USD",Descripcion="Dolares",ISOCorto="US"}

                };
                    context.Divisas.AddRange(divisas);
                    context.SaveChanges();
                }
            }
        }



        public List<Divisa> GetAllDivisa()
        {
            using (var context = new ApiContext())
            {
                var list = context.Divisas.ToList();
                return list;
            }
        }

        public Divisa GetDivisabyIso(string iso)
        {
            using (var context = new ApiContext())
            {
                return context.Divisas.Where(x => x.ISO == iso).FirstOrDefault();
            }
        }
        public void Actualizar(Divisa divisa)
        {
            using (var context = new ApiContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Add(divisa);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                        throw;
                    }
                }
            }
        }

    }
}
