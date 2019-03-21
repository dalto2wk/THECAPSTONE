using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class company_dashboard_JobPostForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        loggedInUser.Text = Session["username"].ToString();
        

        if (IsPostBack == true || IsPostBack == false)
        {
            loggedInUser.Text = Session["username"].ToString();
            
        }

    }

    protected void submitPostingBtnClick(object sender, EventArgs e)
    {
        

        dbInsert();


    }

    protected void dbInsert()
    {
        String postingTitle = txtJobTitle.Value;
        String requirements = txtRequirements.Value;
        String interest = ddlInterest.Value;
        String description = txtDescription.Value;
        String cpName = txtCpName.Value;
        //String cpPhone = txtCpPhone.Value;
        //String cpEmail = txtCpEmail.Value;
        Employer emp = new Employer("James Madison University", 20000, "Higher Education", "college", "Bill Jon", "BJ123", "password", "bj123@gmail.com", "555-555-5555", 1);
        Posting post = new Posting(postingTitle, description, interest, requirements, cpName, emp);

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Project"].ConnectionString);
        sc.Open();

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,
            CommandText = "Insert into Posting values (@postingTitle, @description, @interests, @jobRequirements, @cpName, @employerID, @LastUpdatedBy, @LastUpdated)"
        };


        insert.Parameters.AddWithValue("@postingTitle", post.getPostingTitle());
        insert.Parameters.AddWithValue("@description", post.getDescription());
        insert.Parameters.AddWithValue("@interests", post.getInterests());
        insert.Parameters.AddWithValue("@jobRequirements", post.getJobRequirements());
        insert.Parameters.AddWithValue("@cpName", post.getContactInfo());
        insert.Parameters.AddWithValue("@employerID", post.getEmp().getEmpID());
        insert.Parameters.AddWithValue("@LastUpdatedBy", post.getLastUpdatedBy());
        insert.Parameters.AddWithValue("@LastUpdated", post.getLastUpdated());

        insert.ExecuteNonQuery();
    }
}