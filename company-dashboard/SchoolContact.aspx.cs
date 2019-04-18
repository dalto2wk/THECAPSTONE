using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class company_dashboard_SchoolContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("/Login.aspx");
        }
        else
        {
            loggedInUser.Text = Session["username"].ToString();
        }
    }

    public void viewInfo(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "viewInfo")
        {
            int buttonRowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[buttonRowIndex];
            string schoolid = row.Cells[0].Text;
            string schoolname = row.Cells[1].Text;

            Session["schoolName"] = schoolname;
            Session["schoolID"] = schoolid;


            Response.Redirect("SchoolInformation.aspx");
        }
    }
    public void logoutClick(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("/Login.aspx");
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
       
    }
}
