using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea3.Models;

namespace Tarea3.ViewModel
{
    public class MascotaViewModel
    {
        public Mascota FormMascota { get; set; }
        public IEnumerable<Mascota> ListMascota { get; set; }
    }
}