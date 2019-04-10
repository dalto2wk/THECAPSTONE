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

public partial class company_dashboard_LandingPage : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["username"] == null)
        {
            Response.Redirect("/Login.aspx");
        }
        else
        {
            loggedInUser.Text = Session["username"].ToString();
        }

        ///call the notifications method here in the page load
        notifications();


    }

    public void notifications()
    {
        List<String> notifications = new List<String>();

        ///Connect to database
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

        ///Grab the posting interests from the posting
        sc.Open();
        System.Data.SqlClient.SqlCommand getMostRecentApplication = new System.Data.SqlClient.SqlCommand

        {
            Connection = sc,
            CommandText = "SELECT Student.FirstName, Student.LastName, Application.jobTitle, Application.LastUpdated FROM Student " +
            "INNER JOIN Application ON Student.StudentID = Application.studentID order by Application.LastUpdated"
        };

        SqlDataReader reader = getMostRecentApplication.ExecuteReader();
        ///add the posting interests into the postingInterest arraylist
        while (reader.Read())
        {
            notifications.Add(reader.GetString(0));
            notifications.Add(reader.GetString(1));
            notifications.Add(reader.GetString(2));
        }
        sc.Close();

        notifications.Reverse();


        notificationTitle1.Text = notifications[2] + " " + notifications[1] + " just applied for the " + notifications[0] + " position!";
        notificationTitle2.Text = notifications[5] + " " + notifications[4] + " just applied for the " + notifications[3] + " position!";
        notificationTitle3.Text = notifications[8] + " " + notifications[7] + " just applied for the " + notifications[6] + " position!";

    }

    public void logoutClick(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("/Login.aspx");
    }
    public void TopCandidate()
    {

        ///////////////////////////////////Top Candidate Code////////////////////////////////////////////
        ///Declare and Initialize lists
        List<TopCandidate> topCandidate = new List<TopCandidate>();
        ArrayList postingInterest = new ArrayList();


        ///Connect to database
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

        try
        {
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
        }
        catch
        {
            postingInterest.Add(0);
        }

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

        ///here we are setting the final value equal to
        ///each student's GPA + .3 for each interest they have that matches the interest of the job posting. 
        for (int i = 0; i < topCandidate.Count; i++)
        {

            if (i == 0)
            {
                ((TopCandidate)topCandidate[i]).setFinalValue(((TopCandidate)topCandidate[i]).getGPA());

                for (int j = 0; j < postingInterest.Count; j++)
                {
                    if (((TopCandidate)topCandidate[i]).getStudentInterestID().Equals(postingInterest[j]))
                    {
                        ((TopCandidate)topCandidate[i]).setFinalValue(((TopCandidate)topCandidate[i]).getFinalValue() + .3);
                    }
                }
            }

            else
            {
                if (((TopCandidate)topCandidate[i]).getFirstName() + ((TopCandidate)topCandidate[i]).getLastName() == ((TopCandidate)topCandidate[i - 1]).getFirstName() + ((TopCandidate)topCandidate[i - 1]).getLastName())
                {
                    for (int j = 0; j < postingInterest.Count; j++)
                    {
                        if (((TopCandidate)topCandidate[i]).getStudentInterestID().Equals(postingInterest[j]))
                        {
                            ((TopCandidate)topCandidate[i]).setFinalValue(((TopCandidate)topCandidate[i-1]).getFinalValue() + .3);                          
                        }                   
                    }

                    topCandidate.RemoveAt(i - 1);
                    i--;

                }

                else
                {
                    ((TopCandidate)topCandidate[i]).setFinalValue(((TopCandidate)topCandidate[i]).getGPA());

                    for (int j = 0; j < postingInterest.Count; j++)
                    {
                        if (((TopCandidate)topCandidate[i]).getStudentInterestID().Equals(postingInterest[j]))
                        {
                            ((TopCandidate)topCandidate[i]).setFinalValue(((TopCandidate)topCandidate[i]).getFinalValue() + .3);
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
        if (sortedList.Count == 0)
        {
            ApplicantOne.Text = "No first candidate in system";
            ApplicantTwo.Text = "No second candidate in system";
            ApplicantThree.Text = "No third candidate in system";
        }

        if (sortedList.Count == 1)
        {
            ApplicantOne.Text = sortedList[0].getFirstName() + " " + sortedList[0].getLastName() +
                "  (Score: " + sortedList[0].getFinalValue() + ")";

            ApplicantTwo.Text = "No second candidate in system";
            ApplicantThree.Text = "No third candidate in system";
        }

        if (sortedList.Count == 2)
        {
            ApplicantOne.Text = sortedList[0].getFirstName() + " " + sortedList[0].getLastName() +
                "  (Score: " + sortedList[0].getFinalValue() + ")";

            ApplicantTwo.Text = sortedList[1].getFirstName() + " " + sortedList[1].getLastName() +
                "  (Score: " + sortedList[1].getFinalValue() + ")";

            ApplicantThree.Text = "No third candidate in system";

        }

        if (sortedList.Count > 2)
        {
            ApplicantOne.Text = sortedList[0].getFirstName() + " " + sortedList[0].getLastName() +
                "  (Score: " + sortedList[0].getFinalValue() + ")";

            ApplicantTwo.Text = sortedList[1].getFirstName() + " " + sortedList[1].getLastName() +
                "  (Score: " + sortedList[1].getFinalValue() + ")";

            ApplicantThree.Text = sortedList[2].getFirstName() + " " + sortedList[2].getLastName() +
                "  (Score: " + sortedList[2].getFinalValue() + ")";
        }

        ///Display the Data on the chart for the Top Candidates
        if (sortedList.Count == 0)
        {
            testprogress.Style.Add("width", "0%");
            testprogress2.Style.Add("width", "0%");
            testprogress3.Style.Add("width", "0%");
        }

        if (sortedList.Count == 1)
        {
            String highestPercentage = (sortedList[0].getFinalValue() / maxFinalValue).ToString(".%");
            testprogress.Style.Add("width", highestPercentage);

            testprogress2.Style.Add("width", "0%");
            testprogress3.Style.Add("width", "0%");
        }

        if (sortedList.Count == 2)
        {
            String highestPercentage = (sortedList[0].getFinalValue() / maxFinalValue).ToString(".%");
            testprogress.Style.Add("width", highestPercentage);

            String secondHighestPercentage = (sortedList[1].getFinalValue() / maxFinalValue).ToString(".%");
            testprogress2.Style.Add("width", secondHighestPercentage);

            testprogress3.Style.Add("width", "0%");
        }

        if (sortedList.Count > 2)
        {
            String highestPercentage = (sortedList[0].getFinalValue() / maxFinalValue).ToString(".%");
            testprogress.Style.Add("width", highestPercentage);

            String secondHighestPercentage = (sortedList[1].getFinalValue() / maxFinalValue).ToString(".%");
            testprogress2.Style.Add("width", secondHighestPercentage);

            String thirdHighestPercentage = (sortedList[2].getFinalValue() / maxFinalValue).ToString(".%");
            testprogress3.Style.Add("width", thirdHighestPercentage);
        }

        ///This stuff is just here incase we need it
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