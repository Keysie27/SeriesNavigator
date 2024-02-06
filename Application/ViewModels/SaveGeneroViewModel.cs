using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveGeneroViewModel
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "Ingrese el Nombre del género.")]
        public string? Nombre { get; set; }
    }
}
