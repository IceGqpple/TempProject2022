<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TempProject.Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        div.dropdownmenu {
            background-color: #333;
            white-space: nowrap;
        }

        div.dropdownmenu a {
            display: inline-block;
            color: white;
            text-align: center;
            padding: 14px;
            text-decoration: none;
        }

        div.dropdownmenu a:hover {
            background-color: #777;
        }

        .center {
            margin: auto;
            padding: 10px;
            width: 1200px
        }
        div.Warm{
            color: darkred;
        }
        div.Cold{
            color: darkblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class ="center">

        
</div>

        <div>


            <div class="Warm"><asp:Label ID="Label1Warm" runat="server" Text=""></asp:Label></div>
            <div class="Cold"><asp:Label ID="Label1Cold" runat="server" Text=""></asp:Label></div>
            <div><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></div>
            <div><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></div>
            <div><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></div>
            <div><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></div>
            <div><asp:GridView ID="GridView1" runat="server"></asp:GridView></div>


            <asp:Chart ID="Chart1" runat="server">
                <Series>
                    <asp:Series Name="Series1"></asp:Series>
                    <asp:Series Name="Series2"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>



        </div>
    </form>
    <script>
/* When the user clicks on the button, 
toggle between hiding and showing the dropdown content */
function myFunction() {
  document.getElementById("myDropdown").classList.toggle("show");
}

// Close the dropdown if the user clicks outside of it
window.onclick = function(event) {
  if (!event.target.matches('.dropbtn')) {
    var dropdowns = document.getElementsByClassName("dropdown-content");
    var i;
    for (i = 0; i < dropdowns.length; i++) {
      var openDropdown = dropdowns[i];
      if (openDropdown.classList.contains('show')) {
        openDropdown.classList.remove('show');
      }
    }
  }
}
    </script>
</body>
</html>
