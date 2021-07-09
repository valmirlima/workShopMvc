using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "{0} Requerid")]//Nome obrigatorio
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} Tamanho permitido entre {2} e {1}")]//Tamanho maximo e minimo
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Requerid")]
        [EmailAddress(ErrorMessage = "Entre com email")]
        public string Email { get; set; }

        [Display(Name = "Data Nasc")]//Separando o nomes
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }

        [Display(Name = "Salario Base")]//Separando o nomes
        [DisplayFormat(DataFormatString = "{0:F2}")]//formantando com duas casas decimais
        [Required(ErrorMessage = "{0} Requerid")]
        [Range(100.0, 50000.0, ErrorMessage ="{0} Salario entre {1} e {2}")]
        public double SalarioBase { get; set; }
        public Departamento departamento{ get; set; }
        public int DepartamentoId { get; set; }
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
