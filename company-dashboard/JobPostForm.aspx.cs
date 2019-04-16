using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.IO;

using System.Diagnostics;

public partial class company_dashboard_JobPostForm : System.Web.UI.Page
{
    /// <summary>
    /// Sets up page session variables and ensures a user is logged in 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
       

        //if (IsPostBack == true || IsPostBack == false)
        //{
        //    loggedInUser.Text = Session["username"].ToString();

        //}
        //loggedInUser.Text = Session["username"].ToString();

        //if (!IsPostBack)
        //{
        //    //String State = DropDownList_State.SelectedValue;
        //    //String City = DropDownList_City.SelectedValue; 
            
        //}

       

    }
/// <summary>
/// Method that logs out the user and clears all session variables
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    public void logoutClick(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("/Login.aspx");
    }

    /// <summary>
    /// Calls a method that inserts data into the database when the submit button is clicked 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void submitPostingBtnClick(object sender, EventArgs e)
    {
        

        dbInsert();


    }

    /// <summary>
    /// Method that inserts data for the posting into the database
    /// </summary>
    protected void dbInsert()
    {
        //try
        //{


            String postingTitle = txtJobTitle.Value;
            String requirements = txtRequirements.Value;

            String description = txtDescription.Value;
            String cpName = txtCpName.Value;
            String cpPhone = txtCpPhone.Value;
            String cpEmail = txtCpEmail.Value;
            String postingStartDate = postStart.Value;
            String postingEndDate = postEnd.Value;
            String oppStartDate = opportunityStartDate.Value;

            //fix the emp id to pull from what is in sql from the login 
            School schoolName = new School(listBoxSchool.SelectedValue);
            Employer emp = new Employer("James Madison University", 20000, "Higher Education", "college", "Bill Jon", "BJ123", "password", "bj123@gmail.com", "555-555-5555", 16);
            Posting post = new Posting(postingTitle, description, requirements, cpName, emp, cpPhone, cpEmail, postingStartDate, postingEndDate, oppStartDate);



            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ConnectionString);
            sc.Open();


            System.Data.SqlClient.SqlCommand posting = new System.Data.SqlClient.SqlCommand
            {
                Connection = sc,
                CommandText = "Insert into Posting values (@postingTitle, @description, @jobRequirements, @cpName, @employerID, @LastUpdatedBy, @LastUpdated ,@cpEmail,@cpPhone,@postStart,@postEnd,@opportunityStartDate)"
            };
            //change employer id to match that of the logged in user

            posting.Parameters.AddWithValue("@postingTitle", post.getPostingTitle());
            posting.Parameters.AddWithValue("@description", post.getDescription());
            posting.Parameters.AddWithValue("@jobRequirements", post.getJobRequirements());
            posting.Parameters.AddWithValue("@cpName", post.getContactInfo());
            posting.Parameters.AddWithValue("@employerID", post.getEmp().getEmpID());
            posting.Parameters.AddWithValue("@LastUpdatedBy", post.getLastUpdatedBy());
            posting.Parameters.AddWithValue("@LastUpdated", post.getLastUpdated());
            posting.Parameters.AddWithValue("@cpEmail", post.getCpEmail());
            posting.Parameters.AddWithValue("@cpPhone", post.getCpPhone());
            posting.Parameters.AddWithValue("@postStart", post.getStartDate());
            posting.Parameters.AddWithValue("@postEnd", post.getPostEndDate());
            posting.Parameters.AddWithValue("@opportunityStartDate", post.getOpportunityStartDate());
            posting.ExecuteNonQuery();


        if (fileUp.HasFile == true)
            {
                //set file to null in constructor and then other wise use set file and call the method 
                //post.setfile();
                //post.setfile(fileUp.FileContent);
                System.Data.SqlClient.SqlCommand images = new System.Data.SqlClient.SqlCommand
                {
                    Connection = sc,
                    CommandText = "Insert into Posting_Images values (@postingID, @imageFile)"
                };
            images.Parameters.AddWithValue("@postingID", getMaxPostingID());
            images.Parameters.Add("@imageFile",SqlDbType.VarBinary);
                HttpFileCollection fileCollection = Request.Files;
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile postedFile = fileCollection[i];
                    if(postedFile.ContentLength > 0)
                    {
                        Stream fStream = postedFile.InputStream;
                        byte[] contents = new byte[fStream.Length];
                        fStream.Read(contents, 0, (int)fStream.Length);
                        fStream.Close();
                    images.Parameters["@imageFile"].Value = contents;
                        
                        
                    }
                
                images.ExecuteNonQuery();
            }

            }
            

            




            String count = "";
            count = listBoxInterests.Items.Count.ToString();
            int counter = Int32.Parse(count);
            int currPostingID = getMaxPostingID();

            if (listBoxInterests.SelectedIndex < 0)
            {

            }
            else
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

            String count2 = "";
            count2 = listBoxSchool.Items.Count.ToString();
            int counter2 = Int32.Parse(count2);
            if (listBoxSchool.SelectedIndex < 0)
            {

            }
            else
            {
                for (int i = 0; i < counter2; i++)
                {
                    if (listBoxSchool.Items[i].Selected)
                    {

                        System.Data.SqlClient.SqlCommand postingSchool = new System.Data.SqlClient.SqlCommand
                        {

                            Connection = sc,
                            CommandText = "Insert into Posting_School values (@postingID, @SchoolID, @LastUpdatedBy, @LastUpdated)"

                        };

                        PostingSchool postSchool = new PostingSchool(currPostingID, Convert.ToInt32(listBoxSchool.Items[i].Value));

                        postingSchool.Parameters.AddWithValue("@postingID", postSchool.getPostingID());
                        postingSchool.Parameters.AddWithValue("@SchoolID", postSchool.getSchoolID());
                        postingSchool.Parameters.AddWithValue("@LastUpdatedBy", postSchool.getLastUpdatedBy());
                        postingSchool.Parameters.AddWithValue("@LastUpdated", postSchool.getLastUpdated());

                        postingSchool.ExecuteNonQuery();

                    }
                }
            }

        if (DropDownList_City.SelectedIndex < 0)
        {

        }

        else
        {
            System.Data.SqlClient.SqlCommand postingLocation = new System.Data.SqlClient.SqlCommand
            {
                Connection = sc,
                CommandText = "Insert into Posting_Location values (@PostingID, @LocationID)"
            };




            PostingLocation postLocation = new PostingLocation(currPostingID, Convert.ToInt32(DropDownList_City.SelectedValue));

            postingLocation.Parameters.AddWithValue("@postingID", postLocation.getPostingID());
            postingLocation.Parameters.AddWithValue("@LocationID", postLocation.getLocationID());
   

            postingLocation.ExecuteNonQuery();



        }


        sc.Close();

           
    //}
    //    catch
    //    {

    //    }

    }

    /// <summary>
    /// Method that gets the highest posting ID from the database
    /// </summary>
    /// <returns></returns>
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

    protected void StateSelection_Change(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
     //   DataTable dt = new DataTable();
        System.Data.SqlClient.SqlCommand newCity = new System.Data.SqlClient.SqlCommand();
        newCity.Connection = sc;
        String State = DropDownList_State.SelectedItem.Text;



        SqlDataSourceCity.SelectCommand = "select locationID, citycounty from cities where state = '" + State + "'";
        Debug.WriteLine(SqlDataSourceCity.SelectCommand);
        SqlDataSourceCity.DataBind();



        /*
        try
        {
            sc.Open();
            newCity.CommandText = "SELECT CityCounty FROM cities WHERE State = " + DropDownList_State.SelectedValue;
            string sqlStatement = "SELECT ColumnName * FROM TableName";
            SqlCommand sqlCmd = new SqlCommand(sqlStatement, sc);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DropDownList_City.DataSource = dt;
                DropDownList_City.DataTextField = "CityCounty"; // the items to be displayed in the list items
                DropDownList_City.DataValueField = "CityCounty"; // the id of the items displayed
                DropDownList_City.DataBind();
                sc.Close();
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            sc.Close();
        }
        */
     
    }







    protected void CitySelection_Change(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

        System.Data.SqlClient.SqlCommand newSchool = new System.Data.SqlClient.SqlCommand();
        newSchool.Connection = sc;
        String State = DropDownList_State.SelectedItem.Text;
        String City = DropDownList_City.SelectedItem.Text;

        PostingSchool.SelectCommand = "select SchoolID, SchoolName from School Where State = '" + State + "' and CityCounty = '" + City + "'";
        Debug.WriteLine(PostingSchool.SelectCommand);
        PostingSchool.DataBind();
    }



    protected void populate_Click(object sender, EventArgs e)
    {
        txtJobTitle.Value = "Summer coding camp";
        txtDescription.Value = "This is a shadowing and learning opportunity for a high school student to spend two weeks learning how to code";
        postStart.Value = "04/16/2019";
        postEnd.Value = "04/21/2019";
        opportunityStartDate.Value = "04/28/2019";
        txtCpName.Value = "John Madison";
        txtCpEmail.Value = "jmad@gmail.com";
        txtCpPhone.Value = "555/555-5555";
        txtRequirements.Value = "Must be interested in technology and have some basic computer skills";
    }
}