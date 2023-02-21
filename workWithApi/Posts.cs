using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace workWithApi
{
    public class Posts
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }


        public List<Posts> ps;

        public async Task<List<Posts>> RequestMethod()
        {
            ps = new List<Posts>();
            var client   = new HttpClient();
            var request  = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/posts/");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                ps = JsonSerializer.Deserialize<List<Posts>>(await response.Content.ReadAsStringAsync());
            }
            return ps;
        }
        public async Task<List<Posts>> ResponseMethod()
        {
            ps = new List<Posts>();
            HttpClient client = new HttpClient();
            Uri uri = new Uri(string.Format("https://jsonplaceholder.typicode.com/posts/", string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ps = JsonSerializer.Deserialize<List<Posts>>(content);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ps;
        }
    }
}
