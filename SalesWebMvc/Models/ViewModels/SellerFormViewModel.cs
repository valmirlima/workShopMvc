using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Vendedor vendedor { get; set; }
        public ICollection<Departamento> departamentos{ get; set; }
    }
}
