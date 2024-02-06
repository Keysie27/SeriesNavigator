using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveProductoraViewModel
    {
        public int IdProductora { get; set; }

        [Required(ErrorMessage = "Ingrese el Nombre de la productora.")]
        public string? Nombre { get; set; }
    }
}
