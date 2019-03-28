using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class company_dashboard_Listing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void EditBtn(object sender, GridViewCommandEventArgs e)
    {


        Response.Redirect("EditListing.aspx");
    }
}