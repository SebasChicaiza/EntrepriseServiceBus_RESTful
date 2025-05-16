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
        public async Task<List<productoDTO>> ObtenerTodosLosProductos()
        {
            return await _datosProducto.ObtenerTodosLosProductos();
        }
        public async Task<List<productoDTO>> buscarProductosPorParam(string param = "", string buscado = "")
        {
            List<productoDTO> prds = await _datosProducto.ObtenerTodosLosProductos();
            if (buscado == "")
            {
                return prds;
            }
            switch (param)
            {
                case "proveedor":
                    return prds.Where(c => c.prodProveedor.Contains(buscado)).ToList() ?? new List<productoDTO>();
                case "categoria":
                    return prds.Where(c => c.prodCategoria.Contains(buscado)).ToList() ?? new List<productoDTO>();
                case "nombre":
                    return prds.Where(c => c.prodNombre.Contains(buscado)).ToList() ?? new List<productoDTO>();
                default:
                    return prds;
            }
        }
        public async Task<productoDTO> buscarProducto(string proveedor, int id)
        {
            List<productoDTO> aux = await _datosProducto.ObtenerTodosLosProductos();
            return aux.Where(c => c.prodProveedor == proveedor).Where(c => c.idProducto == id).FirstOrDefault() ?? new productoDTO();
        }
    }
}
