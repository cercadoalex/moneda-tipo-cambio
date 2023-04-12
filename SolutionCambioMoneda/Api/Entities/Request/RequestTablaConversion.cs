using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities.Request
{
    public class RequestTablaConversion
    {
        public string ISO { get; set; }
        public decimal InUSSD { get; set; }
        public decimal PerUSSD { get; set; }
    }
}
