using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveSerieViewModel
    {
        public int IdSerie { get; set; }

        [Required(ErrorMessage = "Ingrese el Nombre de la serie.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la URL de la Portada de la serie.")]
        public string? Portada { get; set; }

        [Required(ErrorMessage = "Ingrese la URL del Trailer de la serie.")]
        public string? Trailer { get; set; }

        //ForeignKeys:
        [Required(ErrorMessage = "Seleccione un Género para la serie.")]
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "Seleccione la Productora de la serie.")]
        public int IdProductora { get; set; }

        public List<ProductoraViewModel>? Productoras { get; set; }
        public List<GeneroViewModel>? Generos { get; set; }

    }
}
