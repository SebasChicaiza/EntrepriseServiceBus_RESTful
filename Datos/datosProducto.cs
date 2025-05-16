using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.DTO;

namespace Datos
{
    public class datosProducto
    {
        private static datosProducto _instance;
        private static readonly object _lock = new object();
        private List<productoDTO> _productoCache;
        private static List<tienda> tiendas = new List<tienda>()
        {
            new tienda()
            {
                url="http://backendpawstails.runasp.net"
            },
            new tienda()
            {
                url="http://backendrestfableedsteel.runasp.net"
            },
            new tienda()
            {
                url="http://backendpeteats.runasp.net/"
            }
        };
        private datosProducto()
        {
            _productoCache = new List<productoDTO>();
        }
        public static datosProducto Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new datosProducto();
                    }
                    return _instance;
                }
            }
        }
        public async Task<List<productoDTO>> obtenerProductos()
        {
            if (_productoCache.Any())
            {
                return _productoCache;
            }
            _productoCache = new List<productoDTO>();
            foreach (var tienda in tiendas)
            {
                var productos = await tienda.obtenerProductos();
                if (productos != null && productos.Count > 0)
                {
                    _productoCache.AddRange(productos);
                }
            }
            return _productoCache.ToList();
        }
        public async Task<List<productoDTO>> ObtenerTodosLosProductos()
        {
            if (_productoCache.Any())
            {
                return _productoCache;
            }

            _productoCache = new List<productoDTO>();
            foreach (var tienda in tiendas)
            {
                List<productoDTO> productosDeApi = await tienda.obtenerProductos();
                _productoCache.AddRange(productosDeApi);
            }

            return _productoCache.ToList(); // Devolvemos una nueva lista para evitar modificaciones externas
        }
    }

}