using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
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
        //populateListing();     

        //string currListingID = Session["listingID"].ToString();
        //System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

        //sc.Open();
        //if (!IsPostBack)
        //{


        //    System.Data.SqlClient.SqlCommand postingInfo = new System.Data.SqlClient.SqlCommand

        //    {
        //        Connection = sc,
        //        CommandText = "select Posting.postingTitle, posting.jobRequirements, posting.description, Posting.cpName, posting.cpPhone" +
        //        ",posting.cpemail, posting.postStart, posting.postEnd,posting.opportunitystartdate from posting where posting.postingID =@id"
        //    };
        //    postingInfo.Parameters.AddWithValue("@id", currListingID);

        //    SqlDataReader reader = postingInfo.ExecuteReader();

        txtJobTitle.Value = Session["title"].ToString();
        txtRequirements.Value = Session["requirements"].ToString();
        txtDescription.Value = Session["description"].ToString();
        txtCpName.Value = Session["cpname"].ToString();
        txtCpPhone.Value = Session["cpphone"].ToString();
        txtCpEmail.Value = Session["cpemail"].ToString();
        txtpostStart.Value = Session["poststart"].ToString();
        txtpostEnd.Value = Session["postend"].ToString();
        txtopportunityStartDate.Value = Session["oppstart"].ToString();

        //while (reader.Read())
        //{
        //    txtJobTitle.Value = reader.GetString(0);
        //    txtRequirements.Value = reader.GetString(1);
        //    txtDescription.Value = reader.GetString(2);
        //    txtCpName.Value = reader.GetString(3);
        //    txtCpPhone.Value = reader.GetString(4);
        //    txtCpEmail.Value = reader.GetString(5);
        //    txtpostEnd.Value = reader.GetString(6);
        //    txtpostEnd.Value = reader.GetString(7);
        //    txtopportunityStartDate.Value = reader.GetString(8);

        //}




        //System.Data.SqlClient.SqlCommand postInterests = new System.Data.SqlClient.SqlCommand

        //{
        //    Connection = sc,
        //    CommandText = "SELECT Posting.postingID, Posting_Interest.interestID FROM Posting INNER JOIN " +
        //    "Posting_Interest ON Posting.postingID = Posting_Interest.postingID where Posting.postingID = 8"
        //};




    }

    //sc.Close();

    protected void updateBtnClick(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();

        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,
            
            CommandText = "Update posting set " +
             "postingTitle = @postingTitle," +
             "description  = @description, " +
             "jobRequirements = @jobRequirements, " +
             "cpName = @cpName, " +
             "cpEmail = @cpEmail, " +
             "cpPhone = @cpPhone, " +
             "postStart = @postStart, " +
             "postEnd = @postEnd, " +
             "opportunityStartDate = @opportunityStartDate, " +
             "lastUpdated = GetDATE()" +
             " where postingID = @postingID"

        };
        update.Parameters.AddWithValue("@postingTitle", txtJobTitle.Value);
        update.Parameters.AddWithValue("@description", txtDescription.Value);
        update.Parameters.AddWithValue("@jobRequirements", txtRequirements.Value);
        update.Parameters.AddWithValue("@cpName", txtCpName.Value);
        update.Parameters.AddWithValue("@cpEmail", txtCpEmail.Value);
        update.Parameters.AddWithValue("@cpPhone", txtCpPhone.Value);
        update.Parameters.AddWithValue("@postStart", txtpostStart.Value);
        update.Parameters.AddWithValue("@postEnd", txtpostEnd.Value);
        update.Parameters.AddWithValue("@opportunityStartDate", txtopportunityStartDate.Value);
        update.Parameters.AddWithValue("@postingID", Session["postID"].ToString());

        update.ExecuteNonQuery();

        sc.Close();
    }
}

    
   
