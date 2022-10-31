using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TempProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             Temperatur temperatur = new Temperatur();
             List<Temperatur> temperaturs = new List<Temperatur>();
        }
    }
}