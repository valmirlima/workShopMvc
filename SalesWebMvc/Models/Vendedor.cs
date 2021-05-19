using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Vendedor
    {
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
