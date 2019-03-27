using System;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Listing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //add session variable; for some reason it isn't liking this at the moment
        //loggedInUser.Text = Session["username"].ToString();
        
    }
    protected void Button_Click1(object sender, GridViewCommandEventArgs e)
    {

        //var closeLink = (Control)sender;
        //GridViewRow row = (GridViewRow)closeLink.NamingContainer;
        //string firstCell = row.Cells[0].Text;

        if (e.CommandName == "editListing")
        {
            int i = Convert.ToInt32(e.CommandArgument);
            
        }

        Debug.WriteLine("if this works i swear");


        

    }
}