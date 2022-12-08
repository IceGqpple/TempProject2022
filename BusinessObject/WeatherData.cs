using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class WeatherData
    {
        public int Id { get;}
        public DateTime DateAndTime { get; set; }
        public int Hour { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double DegreesC { get; set; }
        public double WindSpeed { get; set; }
        public double WindGust { get; set; }
        public double WindDirection { get; set; }
    }
}
