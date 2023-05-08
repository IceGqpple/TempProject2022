using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DataLayer;
using System.Runtime.CompilerServices;

namespace HarvesterTemp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            for (; ;)
            { 
                if (DateTime.Now.Minute == 0)
                {
                    p.GetStuff();
                    var timeOfDay = DateTime.Now.TimeOfDay;
                    var nextFullHour = TimeSpan.FromHours(Math.Ceiling(timeOfDay.TotalHours));
                    var delta = (nextFullHour - timeOfDay).TotalMilliseconds;
                    int Wait = 5 * 60 * 1000;
                    Thread.Sleep(Convert.ToInt32(delta) - Wait);//
                }
                Thread.Sleep(10000);
            }
        }

        public int GetStuff()
        {
            //http://jsonviewer.stack.hu/
            //https://peterdaugaardrasmussen.com/2022/01/18/how-to-get-a-property-from-json-using-selecttoken/
            //create the httpwebrequest
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.met.no/weatherapi/nowcast/2.0/complete?lat=59.9333&lon=10.7166");

            //the usual stuff. run the request, parse your json
            try
            {
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);
                    JToken data = jObj.SelectToken("properties.timeseries[0].data.instant.details");
                    float valuetemp = data.Value<float>("air_temperature");//key name - getting key.value
                    float valueWindSpeed = data.Value<float>("wind_speed");
                    float valueWindGust = data.Value<float>("wind_speed_of_gust");
                    float valueWindDirection = data.Value<float>("wind_from_direction");
                    //inn i db
                    DBLayer DBL = new DBLayer();
                    DBL.InsertMRTableValues(DateTime.Now, DateTime.Now.Hour, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, valuetemp, valueWindSpeed, valueWindGust, valueWindDirection);
                }
                return 0;
            }
            catch { Exception ex; }
            return 0;
        }
    }
}
