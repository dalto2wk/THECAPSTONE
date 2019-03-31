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
        
        string postingID = row.Cells[0].Text;
        
        string postingName = "";
        postingName = row.Cells[1].Text;
        
        Session["postingTitleToEdit"] = postingName;
        Session["postID"] = postingID;

        dbWork();
        
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
            ",posting.cpemail, posting.postStart, posting.postEnd,posting.opportunitystartdate from posting where posting.postingID = @id"
        };
        
        postingInfo.Parameters.AddWithValue("@id", Session["postID"].ToString());

        SqlDataReader reader = postingInfo.ExecuteReader();
        

        Session["title"] = "";
        Session["requirements"] = "";
        Session["description"] = "";
        Session["cpname"] = "";
        Session["cpphone"] = "";
        Session["cpemail"] = "";
        Session["poststart"] = "";
        Session["postend"] = "";
        Session["oppstart"] = "";

        while (reader.Read())
        {
            
            Session["title"] = reader.GetString(0);
            Session["requirements"] = reader.GetString(1);
            Session["description"] = reader.GetString(2);
            Session["cpname"] = reader.GetString(3);
            Session["cpphone"] = reader.GetString(4);
            Session["cpemail"] = reader.GetString(5);
            Session["poststart"] = String.Format("{0:MM/dd/yyyy}", reader.GetDateTime(6));
            Session["postend"] = String.Format("{0:MM/dd/yyyy}", reader.GetDateTime(7));
            Session["oppstart"] = String.Format("{0:MM/dd/yyyy}", reader.GetDateTime(8));
        }

       
    }
}