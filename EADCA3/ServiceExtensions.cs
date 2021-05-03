using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EADCA3
{
    public static class ServiceExtensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url); //makes request
            request.Headers.Add("X-Auth-Token", "e770fa76286949a19bc22fb912045957"); //no point in hiding this, in public header anyway.

            var response = await httpClient.SendAsync(request);
            response.Headers.Add("Access-Control-Allow-Origin", "*"); //Allows for CORS in response headers
            response.EnsureSuccessStatusCode();

            var responseBytes = await response.Content.ReadAsByteArrayAsync();

            return JsonSerializer.Deserialize<T>(responseBytes);
        }
    }
    }
