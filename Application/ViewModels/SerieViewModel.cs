using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SerieViewModel
    {
        public int IdSerie { get; set; }
        public string? Nombre { get; set; }
        public string? Portada { get; set; }
        public string? Trailer { get; set; }

        //ForeignKeys:
        public int IdGenero { get; set; }
        public int IdProductora { get; set; }

        //Navigation propertys:
        public Genero? Genero { get; set; }
        public Productora? Productora { get; set; }
    }
}
