using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class company_dashboard_EditListing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //    loggedInUser.Text = Session["username"].ToString();
        listingToEdit.Text = Session["postingTitleToEdit"].ToString();
        populateListing();     
    }

    protected void populateListing()
    {
        string currListingID = Session["listingID"].ToString();

        string jobTitle;
        string requirements;
        //may need to be list 
        string interests;
        string description;
        string cpname;
        string cphone;
        string cpemail;

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

        sc.Open();


        System.Data.SqlClient.SqlCommand postingInfo = new System.Data.SqlClient.SqlCommand

        {
            Connection = sc,
            CommandText = "SELECT Posting.postingID, Posting_Interest.interestID FROM Posting INNER JOIN " +
            "Posting_Interest ON Posting.postingID = Posting_Interest.postingID where Posting.postingID = 8"
        };



        System.Data.SqlClient.SqlCommand postInterests = new System.Data.SqlClient.SqlCommand

        {
            Connection = sc,
            CommandText = "SELECT Posting.postingID, Posting_Interest.interestID FROM Posting INNER JOIN " +
            "Posting_Interest ON Posting.postingID = Posting_Interest.postingID where Posting.postingID = 8"
        };



        sc.Close();

    }
   
}