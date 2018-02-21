using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace weather
{
    class Program
    {
        static void Main(string[] args)
        {
            LayDuLieu().Wait();

        }

        static async Task LayDuLieu()
        {
            using (var client = new HttpClient())
            {
                // New code;
                client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string DiaDiem = "Moskva";
                string key = "3dcf4cec81ccab8e5fa391ef6afa7a40";
                HttpResponseMessage respon = await client.GetAsync("?q=" +DiaDiem+ "&APPID=" +key);
                if(respon.StatusCode == HttpStatusCode.OK)
                {
                    //string kq = await respon.Content.ReadAsStringAsync();
                    //Console.WriteLine(kq);
                    OpenWeather w = respon.Content.ReadAsAsync<OpenWeather>().Result;
                    Console.WriteLine("ID dia diem: "+ w.id);
                    Console.WriteLine("Dia diem: " + w.name);
                    Console.WriteLine("Temperatura (F): " + w.main.temp);
                    Console.WriteLine("Vlajnost`:" + w.main.humidity);
                    Console.WriteLine("Thoi tiet: " + w.weather[0].main + " - " + w.weather[0].iddescription);
                }
                Console.ReadKey();
     
            }
        }
    }
}
