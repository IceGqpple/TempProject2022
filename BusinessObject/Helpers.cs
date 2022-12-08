using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Helpers
    {
        public static string GetDirectionFromDegrees(int degrees)
        {
            string[] bearings = new string[] { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };
            return bearings[(((degrees * 100) + 1125) % 36000) / 2250];
        }
    }
}
