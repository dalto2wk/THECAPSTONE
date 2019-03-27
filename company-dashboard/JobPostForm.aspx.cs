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
        //loggedInUser.Text = Session["username"].ToString();


        //if (IsPostBack == true || IsPostBack == false)
        //{
        //    loggedInUser.Text = Session["username"].ToString();

        //}
        //loggedInUser.Text = Session["username"].ToString();

    }

    protected void submitPostingBtnClick(object sender, EventArgs e)
    {
        

        dbInsert();


    }

    protected void dbInsert()
    {
        String postingTitle = txtJobTitle.Value;
        String requirements = txtRequirements.Value;
        
        String description = txtDescription.Value;
        String cpName = txtCpName.Value;
        //String cpPhone = txtCpPhone.Value;
        //String cpEmail = txtCpEmail.Value;
        //fix the emp id to pull from what is in sql from the login 
        Employer emp = new Employer("James Madison University", 20000, "Higher Education", "college", "Bill Jon", "BJ123", "password", "bj123@gmail.com", "555-555-5555", 16);
        Posting post = new Posting(postingTitle, description,requirements, cpName, emp);

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();

        System.Data.SqlClient.SqlCommand posting = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,
            CommandText = "Insert into Posting values (@postingTitle, @description, @jobRequirements, @cpName, @employerID, @LastUpdatedBy, @LastUpdated)"
        };
        //change employer id to match that of the logged in user

        posting.Parameters.AddWithValue("@postingTitle", post.getPostingTitle());
        posting.Parameters.AddWithValue("@description", post.getDescription());
        posting.Parameters.AddWithValue("@jobRequirements", post.getJobRequirements());
        posting.Parameters.AddWithValue("@cpName", post.getContactInfo());
        posting.Parameters.AddWithValue("@employerID", post.getEmp().getEmpID());
        posting.Parameters.AddWithValue("@LastUpdatedBy", post.getLastUpdatedBy());
        posting.Parameters.AddWithValue("@LastUpdated", post.getLastUpdated());



        posting.ExecuteNonQuery();

        String count = "";
        count = listBoxInterests.Items.Count.ToString();
        int counter = Int32.Parse(count);
        int currPostingID = getMaxPostingID();

        if(listBoxInterests.SelectedIndex < 0)
        {

        } else
        {
            for (int i = 0; i < counter; i++)
            {
                if (listBoxInterests.Items[i].Selected)
                {
                    System.Data.SqlClient.SqlCommand postingInterests = new System.Data.SqlClient.SqlCommand
                    {
                        Connection = sc,
                        CommandText = "Insert into Posting_Interest values (@postingID, @interestID, @LastUpdatedBy, @LastUpdated)"
                    };
                    PostingInterest postInterest = new PostingInterest(currPostingID, Convert.ToInt32(listBoxInterests.Items[i].Value));
                    
                    postingInterests.Parameters.AddWithValue("@postingID", postInterest.getPostingID());
                    postingInterests.Parameters.AddWithValue("@interestID", postInterest.getInterestID());
                    postingInterests.Parameters.AddWithValue("@LastUpdatedBy", postInterest.getLastUpdatedBy());
                    postingInterests.Parameters.AddWithValue("@LastUpdated", postInterest.getLastUpdated());

                    postingInterests.ExecuteNonQuery();
                    
                }
            }
        }


        




        sc.Close();
    }


    private int getMaxPostingID()
    {
        int result = 0;

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();

        System.Data.SqlClient.SqlCommand maxID = new System.Data.SqlClient.SqlCommand();
        maxID.Connection = sc;
        maxID.CommandText = "select max(PostingID) from Posting";

        result = Convert.ToInt32(maxID.ExecuteScalar());
        maxID.ExecuteNonQuery();

        sc.Close();

        return result; 
    }
}