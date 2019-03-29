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
        int buttonRowIndex = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = GridView1.Rows[buttonRowIndex];
        Debug.WriteLine(row.Cells[1].Text);
        string postingID = row.Cells[1].Text;
        string postingName = "";
        postingName = row.Cells[0].Text;
        Session["listingID"] = postingID;
        Session["postingTitleToEdit"] = postingName;
        
        Response.Redirect("EditListing.aspx");
    }
}