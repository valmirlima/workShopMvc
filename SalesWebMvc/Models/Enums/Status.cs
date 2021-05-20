using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.Enums
{
    public enum StatusVenda: int
    {
        pendente = 0,
        faturado = 1,
        cancelado = 2
    }
}
