using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        string postingID = row.Cells[0].Text;
        string postingName = "";
        postingName = row.Cells[1].Text;
        Session["listingID"] = postingID;
        Session["postingTitleToEdit"] = postingName;

        dbWork();
        Debug.WriteLine(Session["title"].ToString());
        Response.Redirect("EditListing.aspx");
        
    }
    protected void dbWork()
    {
        
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

        sc.Open();



        System.Data.SqlClient.SqlCommand postingInfo = new System.Data.SqlClient.SqlCommand

        {
            Connection = sc,
            CommandText = "select Posting.postingTitle, posting.jobRequirements, posting.description, Posting.cpName, posting.cpPhone" +
            ",posting.cpemail, posting.postStart, posting.postEnd,posting.opportunitystartdate from posting where posting.postingID =@id"
        };
        Debug.WriteLine(Session["listingID"].ToString());
        postingInfo.Parameters.AddWithValue("@id", Session["listingID"].ToString());

        SqlDataReader reader = postingInfo.ExecuteReader();
        string jobTitle = "";
        string requirements = "";
        //may need to be list 
        string interests = "";
        string description = "";
        string cpname = "";
        string cphone = "";
        string cpemail = "";
        string postStart = "";
        string postEnd = "";
        string opportunityStartDate = "";

        reader.Read();
      
        Session["title"] = reader.GetString(0);
        Session["requirements"] = reader.GetString(1);
        Session["description"] = reader.GetString(2);
        Session["cpname"] = reader.GetString(3);
        Session["cpphone"] = reader.GetString(4);
        Session["cpemail"] = reader.GetString(5);
        Session["poststart"] = reader.GetString(6);
        Session["postend"] = reader.GetString(7);
        Session["oppstart"] = reader.GetString(8);
    }
}