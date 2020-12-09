using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace EADCA3
{
    public static class ServiceExtensions
    {

        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("X-Auth-Token", "e770fa76286949a19bc22fb912045957"); 
                        
            var response = await httpClient.SendAsync(request);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("X-Auth-Token", "e770fa76286949a19bc22fb912045957");
            response.EnsureSuccessStatusCode();

            var responseBytes = await response.Content.ReadAsByteArrayAsync();


            return JsonSerializer.Deserialize<T>(responseBytes, new JsonSerializerOptions { });
        }
    }
}
