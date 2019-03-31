using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

        string jobTitle = "";
        string requirements = "" ;
        //may need to be list 
        string interests = "";
        string description = "";
        string cpname = "";
        string cphone = "";
        string cpemail = "";
        string postStart = "";
        string postEnd = "";
        string opportunityStartDate = "";

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

        sc.Open();


        System.Data.SqlClient.SqlCommand postingInfo = new System.Data.SqlClient.SqlCommand

        {
            Connection = sc,
            CommandText = "select Posting.postingTitle, posting.jobRequirements, posting.description, Posting.cpName, posting.cpPhone" +
            ",posting.cpemail, posting.postStart, posting.postEnd,posting.opportunitystartdate from posting where posting.postingID =@id"
        };
        postingInfo.Parameters.AddWithValue("@id", currListingID);

        SqlDataReader reader = postingInfo.ExecuteReader();


        while (reader.Read())
        {
            jobTitle = reader.GetString(0);
            requirements = reader.GetString(1);
            description = reader.GetString(2);
            cpname = reader.GetString(3);
            cphone = reader.GetString(4);
            cpemail = reader.GetString(5);
            postStart = reader.GetString(6);
            postEnd = reader.GetString(7);
            opportunityStartDate = reader.GetString(8);
        }

        txtJobTitle.Value = jobTitle;
        txtRequirements.Value = requirements;
        txtDescription.Value = description;
        txtpostStart.Value = postStart;
        txtpostEnd.Value = postEnd;
        txtopportunityStartDate.Value = opportunityStartDate;
        txtCpName.Value = cpname;
        txtCpEmail.Value = cpemail;
        txtCpPhone.Value = cphone;


        System.Data.SqlClient.SqlCommand postInterests = new System.Data.SqlClient.SqlCommand

        {
            Connection = sc,
            CommandText = "SELECT Posting.postingID, Posting_Interest.interestID FROM Posting INNER JOIN " +
            "Posting_Interest ON Posting.postingID = Posting_Interest.postingID where Posting.postingID = 8"
        };



        sc.Close();

    }
   
}