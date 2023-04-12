using Api.Entities;

namespace Api.Interfaces
{
    public interface IDivisa
    {
        public List<Divisa> GetAllDivisa();
        public Divisa GetDivisabyIso(string iso);

        public void Actualizar(Divisa divisa);
    }
}
