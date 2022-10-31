using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarvesterTemp
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        private int[] GetPMValues()
        {
            //http://jsonviewer.stack.hu/
            //59.202752, 10.953535
            int[] values = new int[2];
            values[0] = -999;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.smartcitizen.me/v0/devices/14057");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = "bolle";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JObject jObj = JObject.Parse(result);

                    JToken pm10 = jObj.SelectToken("data.sensors[7]");
                    JToken pm25 = jObj.SelectToken("data.sensors[8]");
                    int valuepm10 = pm10.Value<int>("value");
                    int valuepm25 = pm25.Value<int>("value");
                    values[0] = valuepm10;
                    values[1] = valuepm25;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return values;
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
                    //JToken data = jObj.SelectToken("path");
                    //int valuepm1 = data.Value<int>("keyname");//key name - getting key.value
                    //int valuepm25 = data.Value<int>("pm25");
                    //int radonValue = data.Value<int>("radonShortTermAvg");
                    // inn i db

                }
                return 0;
            }
            catch { Exception ex; }
            return 0;
        }
    }
}
