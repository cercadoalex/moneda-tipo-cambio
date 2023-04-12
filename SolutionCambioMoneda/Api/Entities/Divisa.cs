using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Divisa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DivisaId { get; set; }
        public string ISO { get; set; }
        public string Descripcion { get; set; }
        public string ISOCorto { get; set; }
    }
}
