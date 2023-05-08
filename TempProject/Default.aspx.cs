using BusinessLayer;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;


namespace TempProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            BusinessClass bc = new BusinessClass();
            double tempnow = bc.GetNowTemp();
            if (tempnow > -1)
            {
                Label1Warm.Text = "Temperature now: " + tempnow.ToString() + "°";
            }
            else
            {
                Label1Cold.Text = "Temperature now: " + tempnow.ToString() + "°";
            }
            Label2.Text = "Wind speed now: " + bc.GetNowWind().ToString();
            Label3.Text = "Wind gust now: " + bc.GetNowWindGust().ToString();
            double WindDirection = bc.GetNowWindDirection();
            Label4.Text = "Wind direction: " + Helpers.GetDirectionFromDegrees((int) WindDirection);
            Label5.Text = "Higest temperature: " + bc.GetTopTemp().ToString() + "°";
            GridView1.DataSource = bc.GetNewest24Rows(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            GridView1.DataBind();
            //BindChart();
        }

        //public void BindChart()
        //{
        //    Chart1.Series[0].XValueMember = "Hour";
        //    Chart1.Series[0].XValueType = ChartValueType.Int32;//optional
        //    Chart1.Series[0].YValueMembers = "WindSpeed";
        //    Chart1.Series[0].ChartType = SeriesChartType.Line;

        //    //to serier=2 grafer/bars etc
        //    Chart1.Series[1].XValueMember = "Hour";
        //    Chart1.Series[1].XValueType = ChartValueType.Int32;//optional
        //    Chart1.Series[1].YValueMembers = "WindGust";
        //    Chart1.Series[1].ChartType = SeriesChartType.Line;

        //    //Chart1.DataBindTable(temps,"Hour");//using just DataBind() below
        //    //Chart1.ChartAreas[0].AxisX.Minimum = 0;
        //    //Chart1.ChartAreas[0].AxisX.Maximum = 24;
        //    Chart1.ChartAreas[0].AxisX.Interval = 1;
        //    Chart1.ChartAreas[0].AxisX.IsMarginVisible = false;

        //    BusinessClass bc = new BusinessClass();

        //    Chart1.DataSource = bc.GetNewest24Rows(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        //    Chart1.DataBind();
        //}
    }
}