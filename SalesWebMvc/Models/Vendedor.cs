using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Vendedor
    {
        private int v1;
        private string v2;
        private string v3;
        private DateTime dateTime;
        private Departamento d1;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DataNasc { get; set; }
        public double SalarioBase { get; set; }
        public Departamento departamento{ get; set; }
        public ICollection<TotalVendas> vendas { get; set; } = new List<TotalVendas>();

        public Vendedor()
        {

        }

        public Vendedor(int id, string name, string email, DateTime dataNasc, double salarioBase, Departamento departamento)
        {
            Id = id;
            Name = name;
            Email = email;
            DataNasc = dataNasc;
            SalarioBase = salarioBase;
            this.departamento = departamento;
        }


        public Vendedor(int v1, string v2, string v3, DateTime dateTime, Departamento d1)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.dateTime = dateTime;
            this.d1 = d1;
        }

        public void AddVendas(TotalVendas tv)
        {
            vendas.Add(tv);
        }
        public void RemoveVendas(TotalVendas tv)
        {
            vendas.Remove(tv);
        }

        public double TotalVendas(DateTime initial, DateTime final)
        {
            return vendas.Where(tv => tv.Date >= initial && tv.Date <= final).Sum(tv => tv.total);
        }
    }
}
