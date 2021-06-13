using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Models
{
    public class SalesWebMvcContext : DbContext
    {
        private readonly object vendedores;

        public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> vendedors { get; set; }
        public DbSet<TotalVendas> totalVendas { get; set; }

        internal object Vendedores => vendedores;
        public object Vendedor { get; internal set; }

      
    }
}
