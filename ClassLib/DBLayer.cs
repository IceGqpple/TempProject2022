using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer
{
    public class DBLayer
    {
        public void InsertMRTableValues(DateTime dateAndTime, int hour, int day, int month, int year, float degreesC, float windSpeed, float windGust, float windDirection)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into WeatherData values(@DateAndTime,@Hour,@Day,@Month,@Year,ROUND(@DegreesC,1),ROUND(@WindSpeed,1),ROUND(@WindGust,1),ROUND(@WindDirection,1))", conn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@DateAndTime", SqlDbType.DateTime);
                param.Value = dateAndTime;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Hour", SqlDbType.Int);
                param.Value = hour;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Day", SqlDbType.Int); 
                param.Value = day;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Month", SqlDbType.Int);
                param.Value = month;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@Year", SqlDbType.Int);
                param.Value = year;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@DegreesC", SqlDbType.Float);
                param.Value = degreesC;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WindSpeed", SqlDbType.Float);
                param.Value = windSpeed;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WindGust", SqlDbType.Float);
                param.Value = windGust;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@WindDirection", SqlDbType.Float);
                param.Value = windDirection;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                int rows = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public double GetNowTemp()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;
           

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DegreesC FROM WeatherData ORDER BY ID DESC", conn);
                cmd.CommandType = CommandType.Text;
                double num = (double) cmd.ExecuteScalar();
                return num;
            }
        }
        public double GetTopTemp()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DegreesC FROM WeatherData ORDER BY DegreesC DESC", conn);
                cmd.CommandType = CommandType.Text;
                double num = (double)cmd.ExecuteScalar();
                return num;
            }
        }
        public double GetNowWind()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT WindSpeed FROM WeatherData ORDER BY ID DESC", conn);
                cmd.CommandType = CommandType.Text;
                double num = (double)cmd.ExecuteScalar();
                return num;
            }
        }
        public double GetNowWindGust()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT WindGust FROM WeatherData ORDER BY ID DESC", conn);
                cmd.CommandType = CommandType.Text;
                double num = (double)cmd.ExecuteScalar();
                return num;
            }
        }
        public double GetNowWindDirection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT WindDirection FROM WeatherData ORDER BY ID DESC", conn);
                cmd.CommandType = CommandType.Text;
                double num = (double)cmd.ExecuteScalar();
                return num;
            }
        }
        public List<WeatherData> GetNewest24Rows(int day, int month, int year)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;
            List<WeatherData> wds = new List<WeatherData>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 24 ID, DateAndTime, Hour, Day, Month, Year, DegreesC, WindSpeed, WindGust, WindDirection FROM WeatherData ORDER BY ID DESC", conn);
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    WeatherData data = new WeatherData();
                    data.WindSpeed = (double)reader["WindSpeed"];
                    data.WindGust = (double)reader["WindGust"];
                    data.DegreesC = (double)reader["DegreesC"];
                    data.Id = (int)reader["ID"];
                    data.DateAndTime = (DateTime)reader["DateAndTime"];
                    data.Hour = (int)reader["Hour"];
                    data.Day = (int)reader["Day"];
                    data.Month = (int)reader["Month"];
                    data.Year = (int)reader["Year"];
                    data.WindDirection = (double)reader["WindDirection"];
                    wds.Add(data);
                }
                conn.Close();
                reader.Close();
               
            } 
            return wds;
        }
    }
}
