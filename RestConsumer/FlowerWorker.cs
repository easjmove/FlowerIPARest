using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TestRest.Models;

namespace RestConsumer
{
    internal class FlowerWorker
    {
        public string URL = "http://localhost:5292/api/Flowers";

        public void DoWork()
        {
            IEnumerable<Flower> list = GetAll().Result;
            foreach (Flower f in list)
            {
                Console.WriteLine(f.Species);
            }
        }

        public async Task<IEnumerable<Flower>> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Amount", "20");
                HttpResponseMessage response = await client.GetAsync(URL);
                if (response.Headers.TryGetValues("TotalAmount", out IEnumerable<string> totalAmount))
                {
                    Console.WriteLine(totalAmount.First());
                }
                IEnumerable<Flower> flowers = await response.Content.ReadFromJsonAsync<IEnumerable<Flower>>();
                return flowers;
            }
        }
    }


}

