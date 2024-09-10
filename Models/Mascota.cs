using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea3.Models
{
    [Table("Mascota")]
    public class Mascota
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Raza { get; set; }
        public string? Color { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}