using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Vendedor> vendedors { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }

        public Departamento(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddVendedor(Vendedor vendedor)
        {
            vendedors.Add(vendedor);
        }

        public double totalVendedor(DateTime initial, DateTime final)
        {
            return vendedors.Sum(vendedor => vendedor.TotalVendas(initial, final));

        }
    }
}
