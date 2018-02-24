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

                string DiaDiem = "Moscow";
                string key = "3dcf4cec81ccab8e5fa391ef6afa7a40";
                HttpResponseMessage respon = await client.GetAsync("?q=" + DiaDiem + "&APPID=" + key);
                if(respon.StatusCode == HttpStatusCode.OK)
                {
                    //string kq = await respon.Content.ReadAsStringAsync();
                    //Console.WriteLine(kq);
                    OpenWeather w = respon.Content.ReadAsAsync<OpenWeather>().Result;
                    string prevTemp = w.main.temp;
                    string temp = "";
                    for (int i = 0; i < prevTemp.Length; ++i)
                    {
                        if (prevTemp[i] == '.')
                        {
                            temp += ',';
                        } else
                        {
                            temp += prevTemp[i];
                        }
                    }
                    double doubleTemp = Convert.ToDouble(temp);
                    doubleTemp -= 273.15;
                    temp = Convert.ToString(doubleTemp);
                    Console.WriteLine("ID dia diem: "+ w.id);
                    Console.WriteLine("Dia diem: " + w.name);
                    Console.WriteLine("Temperatura (C): " + temp);
                    Console.WriteLine("Temperatura (F): " + w.main.temp);
                    Console.WriteLine("Humidity:" + w.main.humidity);
                    Console.WriteLine("Thoi tiet: " + w.weather[0].main + " - " + w.weather[0].iddescription);
                }
                Console.ReadKey();
     
            }
        }
    }
}
