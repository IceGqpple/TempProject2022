using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BusinessLayer
{
    public class BusinessClass
    {
        private DBLayer dbl = new DBLayer();
        public double GetNowTemp()
        {
            return dbl.GetNowTemp();
        }
        public double GetNowWind()
        {
            return dbl.GetNowWind();
        }
        public double GetNowWindGust()
        {
            return dbl.GetNowWindGust();
        }
        public double GetNowWindDirection()
        {
            return dbl.GetNowWindDirection();
        }
        public List<WeatherData> GetNewest24Rows(int day, int month, int year)
        {
            return dbl.GetNewest24Rows(day, month, year);
        }
        public double GetTopTemp()
        {
            return dbl.GetTopTemp();
        }
    }
}
