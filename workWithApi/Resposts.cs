using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace workWithApi
{
    public class Resposts : IPosts
    {
        HttpClient client;
        JsonSerializerOptions _SerializerOptions;
        const string url = "https://jsonplaceholder.typicode.com/posts/";
        public List<Posts> ps { get; set; }

        public Resposts()
        {
             client = new HttpClient();
            _SerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }
        public async Task<List<Posts>> GetPostsAsync()
        {
            ps = new List<Posts>();
            Uri uri = new Uri(string.Format(url, string.Empty));
            try
            {
                HttpResponseMessage resposnce = await client.GetAsync(url);
                if (resposnce.IsSuccessStatusCode)
                {  
                    ps = JsonSerializer.Deserialize<List<Posts>>(await resposnce.Content.ReadAsStringAsync(), _SerializerOptions);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ps;
        }

    
    }
}
