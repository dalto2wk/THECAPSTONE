using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class company_dashboard_LandingPage : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        loggedInUser.Text = Session["username"].ToString();
        //recentApplicationsGV.UseAccessibleHeader = true;
        //recentApplicationsGV.HeaderRow.TableSection = TableRowSection.TableHeader;
        testprogress.Style.Add("width", "95%");

        //style="width: 75%" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"><

        testprogress.Style.Add("role", "progressbar");
        testprogress.Style.Add("aria-valuenow", "75");
        testprogress.Style.Add("aria-valuemin", "0");
        testprogress.Style.Add("aria-valuemax", "100");


        
    }
}