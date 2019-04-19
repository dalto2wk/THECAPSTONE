using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

public partial class company_dashboard_StudentContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["username"] == null || HttpContext.Current.Request.UrlReferrer == null)
        {
            Response.Redirect("/Login.aspx");
        }
        else
        {
            loggedInUser.Text = Session["username"].ToString();
        }



        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();
        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,

            CommandText = "select employerID from Employer where cpUserName = '" + Session["username"].ToString() + "'"

        };


        Session["EmpID"] = Convert.ToString(select.ExecuteScalar());


        ///call the notifications method in the page load
        notifications();

       StudentApplicationDataSource.SelectCommand = "SELECT Approval_Status.EmployerID, CONCAT_WS(' ', Student.FirstName, Student.LastName) AS 'Name', School.SchoolName AS 'School Name', Application.jobTitle AS 'Applied to' FROM Approval_Status INNER JOIN School ON Approval_Status.SchoolID = School.SchoolID INNER JOIN Student ON School.SchoolID = Student.schoolID INNER JOIN Application ON Student.StudentID = Application.studentID WHERE Approval_Status.EmployerID = '" + Session["EmpID"] + "'";
        StudentApplicationDataSource.DataBind();
        studentApplicationTable.DataBind();


    }

    public void logoutClick(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("/Login.aspx");
    }

    protected void viewResume(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "viewResume")
        {
            int buttonRowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = studentApplicationTable.Rows[buttonRowIndex];
            string fullname = row.Cells[0].Text;
            string fname = "";
            string lname = "";
            string[] splitName = fullname.Split(' ');
            fname = splitName[0];
            lname = splitName[1];
            pdfWrite(fname, lname);
            //calls method for converting test data pdf into binary and inserting to db
            //pdfProcessToDB();
        }
        else if (e.CommandName == "viewStudentInformation")
        {
            int buttonRowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = studentApplicationTable.Rows[buttonRowIndex];
            string fullname = row.Cells[0].Text;
            string fname = "";
            string lname = "";
            string[] splitName = fullname.Split(' ');
            fname = splitName[0];
            lname = splitName[1];
            Session["fName"] = fname;
            Session["lName"] = lname;
            Response.Redirect("StudentDetails.aspx");

        }
    }

    protected void pdfProcessToDB()
    {
        System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        cn.Open();
        //file path 
        //file:///C:/Users/WK/Downloads/William%20Dalton%20Resume%202018.pdf
        //Add a pdf file in the below code to add to database
        //C:\\Users\\WK\\Downloads\\ProjectResumesSamples\\Jon Snow.pdf
        FileStream fStream = File.OpenRead("C:\\Users\\WK\\Downloads\\ProjectResumesSamples\\RobertStark.pdf");
        byte[] contents = new byte[fStream.Length];
        fStream.Read(contents, 0, (int)fStream.Length);
        fStream.Close();

        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("Update Application set resume = (@data) where studentID = 6", cn);
        cmd.Parameters.AddWithValue("@Data", contents);
        cmd.ExecuteNonQuery();
        cn.Close();
    }

    protected void pdfWrite(String firstname, String lastName)
    {
        //sql needed- select resume from application inner join student on application.studentid = student.studentid where student.firstname = 'Sansa'
        string savedFilePath = Server.MapPath("~\\TempFiles\\Report.pdf");
        System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        cn.Open();

        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select resume from application inner join student on application.studentid = student.studentid where student.firstname = @FName and student.lastname = @LName", cn);
        cmd.Parameters.AddWithValue("@FName", firstname);
        cmd.Parameters.AddWithValue("@LName", lastName);

        System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default);

        if (dr.Read())
        {
            byte[] fileData = (byte[])dr.GetValue(0);
            //this to the response.bw is new
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename= " + firstname + "_" + lastName + "_Resume.pdf");
            Response.AddHeader("Content-Length", fileData.Length.ToString());
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(fileData);
            //System.IO.FileStream fs = new System.IO.FileStream(savedFilePath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);

            //System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);

            //bw.Write(fileData);

            //bw.Close();

            
        }

        dr.Close();

        //Response.Write(fileData);
        

        //the below way stores to solution using response.binarywrite is better
        //old Response.Redirect("~\\TempFiles\\Report.pdf");

    }

    public void TopCandidate()
    {

        ///////////////////////////////////Top Candidate Code////////////////////////////////////////////
        ///Declare and Initialize lists
        List<TopCandidate> topCandidate = new List<TopCandidate>();
        List<int> postingInterest = new List<int>();


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

            if (reader2.Read() == false)
            {
                postingInterest.Add(0);
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
                            ((TopCandidate)topCandidate[i]).setFinalValue(((TopCandidate)topCandidate[i - 1]).getFinalValue() + .3);
                        }
                    }

                    if ((topCandidate[i]).getStudentInterestID() != postingInterest[0])
                    {
                        ((TopCandidate)topCandidate[i]).setFinalValue(((TopCandidate)topCandidate[i]).getGPA());
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

    public void notifications()
    {
        List<String> notifications = new List<String>();
        List<DateTime> dates = new List<DateTime>();

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
            dates.Add(reader.GetDateTime(3));
        }
        sc.Close();

        notifications.Reverse();
        dates.Reverse();

        ///day and month of most recent application
        String dy0 = dates[0].Day.ToString();
        String mn0 = new DateTime(2019, dates[0].Month, 1).ToString("MMM", System.Globalization.CultureInfo.InvariantCulture);

        ///day and month of Second-most recent application
        String dy1 = dates[1].Day.ToString();
        String mn1 = new DateTime(2019, dates[1].Month, 1).ToString("MMM", System.Globalization.CultureInfo.InvariantCulture);

        ///day and month of Third-most recent application
        String dy2 = dates[2].Day.ToString();
        String mn2 = new DateTime(2019, dates[2].Month, 1).ToString("MMM", System.Globalization.CultureInfo.InvariantCulture);


        notificationTitle1.Text = notifications[2] + " " + notifications[1] + " just applied for the " + notifications[0] + " position!";
        day1.Text = dy0;
        month1.Text = mn0;
        day2.Text = dy1;
        month2.Text = mn1;
        day3.Text = dy2;
        month3.Text = mn2;
        notificationTitle2.Text = notifications[5] + " " + notifications[4] + " just applied for the " + notifications[3] + " position!";
        notificationTitle3.Text = notifications[8] + " " + notifications[7] + " just applied for the " + notifications[6] + " position!";

    }
}