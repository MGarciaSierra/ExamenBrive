using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributos
{
    public class Venta
    {
        public int IdVenta { get; set; }

        public Usuario Usuario { get; set; }
        public decimal Total { get; set; }

        public DateTime FechaVenta { get; set; }
        public MetodoPago MetodoPago { get; set; }

        public List<object> Ventas { get; set; }
    }
}
