using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace ProyectoJwt.Servicios.Servicios
{
    public class ClienteConsumoApi
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuracion;

        public ClienteConsumoApi(HttpClient httpClient, IConfiguration configuracion)
        {
            _httpClient = httpClient;
            _configuracion = configuracion;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            return await _httpClient.GetFromJsonAsync<T>(ProcesarUri(uri));
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ProcesarUri(uri), data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<TResponse>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private string ProcesarUri(string uri)
        {
            return string.Concat(_configuracion["UriApi"], uri);
        }
    }
}
