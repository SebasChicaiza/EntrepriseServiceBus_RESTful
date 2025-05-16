using AccesoDatos.DTO;
using System.Text.Json;

namespace AccesoDatos
{
    public class tienda
    {
        public string url { get; set; }
        public string productosUrl { get => url + "api/integracion/productos"; }
        public async Task<List<productoDTO>> obtenerProductos()
        {
            //Creamos un http client para realizar la peticion
            HttpClient httpClient = new HttpClient();

            try
            {
                //Realizamos la peticion a la api
                var response = await httpClient.GetAsync(productosUrl);
                //Comprobamos que la respuesta es correcta
                response.EnsureSuccessStatusCode();
                //Leemos el contenido de la respuesta
                var jsonString = await response.Content.ReadAsStringAsync();
                //Deserializamos el contenido a una lista de productos
                var res = JsonSerializer.Deserialize<List<productoDTO>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive=true});
                foreach (var item in res)
                {
                    if(string.IsNullOrEmpty(item.prodCategoria))
                    {
                        item.prodCategoria = "NA";
                    }
                    if (string.IsNullOrEmpty(item.prodNombre))
                    {
                        item.prodCategoria = "NA";
                    }                    
                }
                return res?? new List<productoDTO>();

            }
            catch (Exception ex)
            {
                return new List<productoDTO>();
            }
        }
    }
}
