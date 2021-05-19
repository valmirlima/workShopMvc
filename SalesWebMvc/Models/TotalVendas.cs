using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class TotalVendas
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double total { get; set; }
        public TotalVendas Status { get; set; }
        public Vendedor Vendedor{ get; set; }

        public TotalVendas()
        {
        }

        public TotalVendas(int id, DateTime date, double total, TotalVendas status, Vendedor vendedor)
        {
            Id = id;
            Date = date;
            this.total = total;
            Status = status;
            Vendedor = vendedor;
        }

        
    }
}
