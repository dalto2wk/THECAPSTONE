using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class company_dashboard_StudentContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //loggedInUser.Text = Session["username"].ToString();
    }

    protected void viewResume(object sender, GridViewCommandEventArgs e)
    {
        int buttonRowIndex = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = studentApplicationTable.Rows[buttonRowIndex];
        
    }
}