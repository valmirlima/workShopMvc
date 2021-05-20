using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SeedingServece
    {
        private SalesWebMvcContext _context;

        public SeedingServece(SalesWebMvcContext context)
        {
            _context = context;   
        }

        public void Seed()
        {
            if(_context.Departamento.Any() ||
                _context.vendedors.Any() ||
                _context.totalVendas.Any())
            {
                return;// Se banca ja esta pupulado.
            }
            Departamento d1 = new Departamento(1, "Computadores");
            Departamento d2 = new Departamento(2, "Eletronicos");
            Departamento d3 = new Departamento(3, "Confecçoes");
            Departamento d4 = new Departamento(4, "Livros");

            Vendedor v1 = new Vendedor(1, "Bob Dilan", "bob@gmail.com", new DateTime(1975, 5, 12),1000.10, d1);
            Vendedor v2 = new Vendedor(2, "James Car", "james@ig.com.br", new DateTime(1980, 1, 22), 1200.20, d3);
            Vendedor v3 = new Vendedor(3, "Helio Costa", "helio@hotmail.com", new DateTime(1978, 12, 1),1100.98, d2);
            Vendedor v4 = new Vendedor(4, "Caio Victor", "cvictor@gmail.com", new DateTime(2000, 7, 7), 2100.10, d4);
            Vendedor v5 = new Vendedor(5, "Marta Lobo", "mlobo@gmail.com", new DateTime(2005, 9, 10), 3000.00, d1);
            Vendedor v6 = new Vendedor(6, "Clara Nunes", "cnunes@hotmail.com", new DateTime (1997, 10, 10),2580.50, d3);

            TotalVendas tv1 = new TotalVendas(1, new DateTime (2018,10, 20), 15000.28, StatusVenda.faturado, v5);
            TotalVendas tv2 = new TotalVendas(2, new DateTime(2011, 7, 2), 10000.28, StatusVenda.faturado, v2);
            TotalVendas tv3 = new TotalVendas(3, new DateTime(2013, 10, 12), 1200.28, StatusVenda.cancelado, v3);
            TotalVendas tv4 = new TotalVendas(4, new DateTime(2015, 1, 22), 1010.28, StatusVenda.pendente, v1);
            TotalVendas tv5 = new TotalVendas(5, new DateTime(2018, 10, 23), 1000.28, StatusVenda.faturado, v3);
            TotalVendas tv6 = new TotalVendas(6, new DateTime(2018, 10, 2), 11000.28, StatusVenda.pendente, v1);
            TotalVendas tv7 = new TotalVendas(7, new DateTime(2020, 5,15), 8000.10, StatusVenda.faturado, v5);
            TotalVendas tv8 = new TotalVendas(8, new DateTime(2021, 10, 25), 11000.28, StatusVenda.faturado, v2);
            TotalVendas tv9 = new TotalVendas(9, new DateTime(2018, 10, 2), 18000.28, StatusVenda.faturado, v4);
            TotalVendas tv10 = new TotalVendas(10, new DateTime(2017, 12, 1), 11000.28, StatusVenda.pendente, v3);
            TotalVendas tv11 = new TotalVendas(11, new DateTime(2018, 1, 2), 11000.28, StatusVenda.cancelado, v3);
            TotalVendas tv12 = new TotalVendas(12, new DateTime(2020, 10, 2), 11000.28, StatusVenda.faturado, v4);

            _context.Departamento.AddRange(d1, d2, d3, d4);//Adicionado objetos ao Banco dados

            _context.vendedors.AddRange(v1, v2, v3, v4, v5, v6);

            _context.totalVendas.AddRange(tv1, tv2, tv3, tv4, tv5, tv6, tv7, tv8, tv9, tv7,tv8,tv9, tv10, tv11, tv12);

            _context.SaveChanges();//Salvando no BD.

        }
    }
}
