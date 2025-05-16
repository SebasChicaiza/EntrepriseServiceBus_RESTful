using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DTO
{
    public class productoDTO
    {
        public int idProducto { get; set; }
        public string? prodNombre { get; set; }
        public string? prodCategoria { get; set; }
        public string? prodDescripcion { get; set; }

        public string? prodPrecio { get; set; }
        public int prodStock { get; set; }
        public string? prodProveedor { get; set; }
        public List<string> prodImg { get; set; }
    }
}
