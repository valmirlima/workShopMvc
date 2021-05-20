using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class TotalVendas
    {
        private int v1;
        private DateTime dateTime;
        private double v2;
        private StatusVenda faturado;
        private Vendedor v5;

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

        public TotalVendas(int v1, DateTime dateTime, double v2, StatusVenda faturado, Vendedor v5)
        {
            this.v1 = v1;
            this.dateTime = dateTime;
            this.v2 = v2;
            this.faturado = faturado;
            this.v5 = v5;
        }
    }
}
