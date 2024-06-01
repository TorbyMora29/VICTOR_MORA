using FluentResults;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http.Headers;
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

        public async Task<Result<TResponse?>> PostAsync<TRequest, TResponse>(string uri, TRequest data, string? bearerToken = null)
        {
            try
            {
                // Agregar Bearer Token
                if (!String.IsNullOrEmpty(bearerToken))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                }
                
                var response = await _httpClient.PostAsJsonAsync(ProcesarUri(uri), data);
                response.EnsureSuccessStatusCode();

                if(response.StatusCode == HttpStatusCode.OK)
                {
                    return Result.Ok(await response.Content.ReadFromJsonAsync<TResponse>());
                }

                return Result.Fail($"La solicitud devolvió un código: {response.StatusCode}");
            }
            catch
            {
                return Result.Fail("Error al procesar la solicitud");
            }
        }

        private string ProcesarUri(string uri)
        {
            return string.Concat(_configuracion["UriApi"], uri);
        }
    }
}
