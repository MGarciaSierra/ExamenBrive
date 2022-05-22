using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributos
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public Venta Venta { get; set; }

        public Sucursal Sucursal { get; set; }

        public int Cantidad { get; set; }

        public Producto Producto { get; set; }

        public List<object> DetalleVentas { get; set; }
    }
}
