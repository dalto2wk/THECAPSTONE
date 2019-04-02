using System;
using System.Collections;
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
        sc.Close();
       
    }

    public void TopCandidate()
    {
        ///////////////////////////////////Top Candidate Code////////////////////////////////////////////
        ///Declare and Initialize lists
        List<TopCandidate> topCandidate = new List<TopCandidate>();
        ArrayList postingInterest = new ArrayList();


        ///Connect to database
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

        ///Grab the posting interests from the posting
        sc.Open();
        System.Data.SqlClient.SqlCommand getPostingInterest = new System.Data.SqlClient.SqlCommand

        {
            Connection = sc,
            CommandText = "SELECT Posting.postingID, Posting_Interest.interestID FROM Posting INNER JOIN " +
            "Posting_Interest ON Posting.postingID = Posting_Interest.postingID where Posting.postingID = @ddlTopCandidate"
        };

        getPostingInterest.Parameters.AddWithValue("@ddlTopCandidate", ddlTopCandidate.SelectedValue);

        SqlDataReader reader2 = getPostingInterest.ExecuteReader();
        ///add the posting interests into the postingInterest arraylist
        while (reader2.Read())
        {
            postingInterest.Add(reader2.GetInt32(1));
        }
        sc.Close();


        sc.Open();
        System.Data.SqlClient.SqlCommand getTopCandidate = new System.Data.SqlClient.SqlCommand

        {
            ///select the firstname, lastname, GPA, and interest name from all the students who applied to
            ///a particular job posting
            Connection = sc,
            CommandText = "SELECT Student.StudentID, Student.FirstName, Student.LastName, Student.GPA, Student_Interest.interestID " +
            "FROM Student INNER JOIN Student_Interest ON Student.StudentID = Student_Interest.studentID " +
            "INNER JOIN Application ON Student.StudentID = Application.studentID INNER JOIN " +
            "Posting ON Application.postingID = Posting.postingID where Posting.PostingID = @ddlTopCandidate"
        };
        getTopCandidate.Parameters.AddWithValue("@ddlTopCandidate", ddlTopCandidate.SelectedValue);

        //create an array list to store the names, GPAs, and interests all separately
        SqlDataReader reader = getTopCandidate.ExecuteReader();

        int id = 0;
        String firstName = "";
        String lastName = "";
        double GPA = 0;
        int studentInterestID = 0;



        //separate out data and fill arraylists
        while (reader.Read())
        {
            id = (reader.GetInt32(0));
            firstName = (reader.GetString(1));
            lastName = (reader.GetString(2));
            GPA = (reader.GetDouble(3));
            studentInterestID = (reader.GetInt32(4));

            topCandidate.Add(new TopCandidate(id, firstName, lastName, GPA, studentInterestID, 0));



        }
        sc.Close();

        ///This was by far the most difficult part, here we are setting the final value equal to
        ///the each student's GPA + .5 for each interest they have that matches the posting interest. 
        for (int i = 0; i < topCandidate.Count; i++)
        {
            ((TopCandidate)topCandidate[i]).setFinalValue(((TopCandidate)topCandidate[i]).getGPA());

            if (i == 0)
            {
                for (int j = 0; j < postingInterest.Count; j++)
                {
                    if (((TopCandidate)topCandidate[i]).getStudentInterestID().Equals(postingInterest[j]))
                    {
                        ((TopCandidate)topCandidate[i]).setFinalValue(((TopCandidate)topCandidate[i]).getGPA() + .3);
                    }
                }
            }

            else
            {
                if (((TopCandidate)topCandidate[i]).getFirstName() + ((TopCandidate)topCandidate[i]).getLastName() == ((TopCandidate)topCandidate[i - 1]).getFirstName() + ((TopCandidate)topCandidate[i - 1]).getLastName())
                {
                    ((TopCandidate)topCandidate[i]).setFinalValue(((TopCandidate)topCandidate[i - 1]).getFinalValue() + .3);
                    topCandidate.RemoveAt(i - 1);
                    i--;
                }

                else
                {
                    for (int j = 0; j < postingInterest.Count; j++)
                    {
                        if (((TopCandidate)topCandidate[i]).getStudentInterestID().Equals(postingInterest[j]))
                        {
                            ((TopCandidate)topCandidate[i]).setFinalValue(((TopCandidate)topCandidate[i]).getGPA() + .3);
                        }
                    }
                }
            }
        }


        ///sort the list of Top Candidates by their final value, and then reverse the list
        ///so that the top candidates start at postion 0
        List<TopCandidate> sortedList = topCandidate.OrderBy(o => o.getFinalValue()).ToList();
        sortedList.Reverse();

        ///determine the maximum possible value for a posting
        double maxFinalValue = 4.0 + (postingInterest.Count * .3);


        ////////////////Put data into Graph on Landing Page////////////////
        ///Grab the Posting Title from the Posting that the top candidates are related to
        sc.Open();
        System.Data.SqlClient.SqlCommand getPostingTitle = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,
            CommandText = "Select PostingTitle from Posting where postingID = @ddlTopCandidate;"
        };
        getPostingTitle.Parameters.AddWithValue("@ddlTopCandidate", ddlTopCandidate.SelectedValue);

        String postingSubTitle = getPostingTitle.ExecuteScalar().ToString();
        getPostingTitle.ExecuteNonQuery();
        sc.Close();

        ///set the Posting Title in the sub title
        topCandidateSubTitle.Text = "For: " + postingSubTitle;


        ///Add student information above the progress bar
        ApplicantOne.Text = sortedList[0].getFirstName() + " " + sortedList[0].getLastName() +
            "  (Score: " + sortedList[0].getFinalValue() + ")";

        ApplicantTwo.Text = sortedList[1].getFirstName() + " " + sortedList[1].getLastName() +
            "  (Score: " + sortedList[1].getFinalValue() + ")";

        ApplicantThree.Text = sortedList[2].getFirstName() + " " + sortedList[2].getLastName() +
            "  (Score: " + sortedList[2].getFinalValue() + ")";

        ///Display the Data on the chart for the Top Candidate
        String highestPercentage = (sortedList[0].getFinalValue() / maxFinalValue).ToString(".%");
        testprogress.Style.Add("width", highestPercentage);

        //testprogress.Style.Add("role", "progressbar");
        //testprogress.Style.Add("aria-valuenow", "75");
        //testprogress.Style.Add("aria-valuemin", "0");
        //testprogress.Style.Add("aria-valuemax", "100");
        //Old HTML: style="width: 75%" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"><


        ///Display the Data on the chart for the Second-Most Top Candidate
        String secondHighestPercentage = (sortedList[1].getFinalValue() / maxFinalValue).ToString(".%");
        testprogress2.Style.Add("width", secondHighestPercentage);

        //testprogress.Style.Add("role", "progressbar");
        //testprogress.Style.Add("aria-valuenow", "50");
        //testprogress.Style.Add("aria-valuemin", "0");
        //testprogress.Style.Add("aria-valuemax", "100");
        //Old HTML: style = "width: 50%" role = "progressbar" aria - valuenow = "50" aria - valuemin = "0" aria - valuemax = "100"


        String thirdHighestPercentage = (sortedList[2].getFinalValue() / maxFinalValue).ToString(".%");
        testprogress3.Style.Add("width", thirdHighestPercentage);

        //testprogress.Style.Add("role", "progressbar");
        //testprogress.Style.Add("aria-valuenow", "25");
        //testprogress.Style.Add("aria-valuemin", "0");
        //testprogress.Style.Add("aria-valuemax", "100");
        //Old HTML: style="width: 75%" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"><
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    /// <summary>
    /// Call the method in the prerender (a page event that comes after 
    protected void topCandidate(object sender, EventArgs e)
    {
        TopCandidate();
    }
}