using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    internal class DBLayer
    {
        public void InsertMRTableValues(int year, int month, int day, int pm10dm, int pm10hm, int pm25dm, int pm25hm, int PM25HMTime, int PM10HMTime)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into MRTempTable values(@year,@month,@day,@PM10DM,@PM10HM,@PM25DM,@PM25HM,@PM25HMTime,@PM10HMTime)", conn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@year", SqlDbType.Int);
                param.Value = year;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@month", SqlDbType.Int);
                param.Value = month;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@day", SqlDbType.Int);
                param.Value = day;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PM10DM", SqlDbType.Int);
                param.Value = pm10dm;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PM10HM", SqlDbType.Int);
                param.Value = pm10hm;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PM25DM", SqlDbType.Int);
                param.Value = pm25dm;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PM25HM", SqlDbType.Int);
                param.Value = pm25hm;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PM25HMTime", SqlDbType.Int);
                param.Value = PM25HMTime;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@PM10HMTime", SqlDbType.Int);
                param.Value = PM10HMTime;//(object)wpd.Temp ?? DBNull.Value;//wpd.Temp;
                cmd.Parameters.Add(param);

                int rows = cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<MonthlyReport> GetMonthlyReportByYearAndMonthFromMRTable(int year, int month)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;
            List<MonthlyReport> mrs = new List<MonthlyReport>();
            SqlParameter param;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT day,pm10dm,pm10hm,pm25dm,pm25hm,pm25hmtime,pm10hmtime from MRTempTable where year=@year and month=@month order by day asc", conn);
                cmd.CommandType = CommandType.Text;

                param = new SqlParameter("@month", SqlDbType.Int);
                param.Value = month;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@year", SqlDbType.Int);
                param.Value = year;
                cmd.Parameters.Add(param);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MonthlyReport mr = new MonthlyReport();
                    //air.DateAndTime = (DateTime)reader["DateAndTime"]; 
                    //air.Year = (int)reader["Year"];
                    //air.Month = (int)reader["Month"];
                    mr.Day = (int)reader["Day"];
                    mr.PM10DM = (int)reader["PM10DM"];
                    mr.PM10HM = (int)reader["PM10HM"];
                    mr.PM25DM = (int)reader["PM25DM"];
                    mr.PM25HM = (int)reader["PM25HM"];
                    mr.PM25HMTime = (int)reader["PM25HMTime"];
                    mr.PM10HMTime = (int)reader["PM10HMTime"];
                    mrs.Add(mr);
                }
                reader.Close();
                conn.Close();
            }
            return mrs;
        }
    }
}
