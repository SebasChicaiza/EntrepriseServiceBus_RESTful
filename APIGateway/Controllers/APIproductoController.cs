using Microsoft.AspNetCore.Mvc;
using AccesoDatos;
using Logica;
using AccesoDatos.DTO;

namespace APIGateway.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class APIproductoController : ControllerBase
    {
        private readonly logicaProductos _logicaProducto = new logicaProductos();
        [HttpGet] // Ruta específica para obtener los productos
        public async Task<ActionResult<List<productoDTO>>> Get()
        {
            var productos = await _logicaProducto.obtenerProductos();
            return Ok(productos);
        }
        [HttpGet("buscar")]
        public async Task<ActionResult<List<productoDTO>>> GetPrdBusqueda([FromQuery] string param, [FromQuery] string buscado)
        {
            List<productoDTO> res = await _logicaProducto.buscarProductosPorParam(param, buscado);
            return Ok(res);
        }
        [HttpGet("{proveedor}/{id}")]
        public async Task<productoDTO> GetPrd(string proveedor, int id)
        {
            return await _logicaProducto.buscarProducto(proveedor, id);
        }
    }
}
