using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Genero
    {
        public int IdGenero { get; set; }
        public string? Nombre { get; set; }

        //Navigation property:
        public ICollection<Serie>? Series { get; set; }
    }
}
