using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class HomeViewModel
    {
        public string? NombreSerie { get; set; }
        public int? IdProductora { get; set; }
        public List<SerieViewModel>? Series { get; set; }
        public List<ProductoraViewModel>? Productoras { get; set; }
    }
}
