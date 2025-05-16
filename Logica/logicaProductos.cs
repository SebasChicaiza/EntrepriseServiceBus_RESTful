using AccesoDatos.DTO;
using Datos;

namespace Logica
{
    public class logicaProductos
    {
        private readonly datosProducto _datosProducto = datosProducto.Instance;
        public async Task<List<productoDTO>> obtenerProductos()
        {
            return await _datosProducto.ObtenerTodosLosProductos();
        }
        public async Task<List<productoDTO>> obtenerProductosPorNombre(string nombre)
        {
            List<productoDTO> res = await _datosProducto.ObtenerTodosLosProductos();
            return res.Where(c => c.prodNombre.Contains(nombre)).ToList();
        }

    }
}
