using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class TablaConversion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TablaConversionId { get; set; }
        public string Descripcion { get; set; }
        public string ISO { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal InUSSD { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal PerUSSD { get; set; }

    }
}
