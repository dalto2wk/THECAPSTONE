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

        if (!IsPostBack)
        {
            txtJobTitle.Value = Session["title"].ToString();
            txtRequirements.Value = Session["requirements"].ToString();
            txtDescription.Value = Session["description"].ToString();
            txtCpName.Value = Session["cpname"].ToString();
            txtCpPhone.Value = Session["cpphone"].ToString();
            txtCpEmail.Value = Session["cpemail"].ToString();
            txtpostStart.Value = String.Format("{0:MM/dd/yyyy}", Session["poststart"].ToString());
            txtpostEnd.Value = String.Format("{0:MM/dd/yyyy}", Session["postend"].ToString());
            txtopportunityStartDate.Value = String.Format("{0:MM/dd/yyyy}", Session["oppstart"].ToString());
        }
      




    }

    

    protected void updateBtnClick(object sender, EventArgs e)
    {
        //Response.Redirect("Listing.aspx");
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

    
   
