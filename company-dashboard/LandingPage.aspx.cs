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

        ArrayList topCandidate = new ArrayList();
        ArrayList postingInterest = new ArrayList();

        ///Connect to database
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();
        System.Data.SqlClient.SqlCommand getTopCandidate = new System.Data.SqlClient.SqlCommand

        {
            ///select the firstname, lastname, GPA, and interest name from all the students who applied to
            ///a particular job posting
            Connection = sc,
            CommandText = "SELECT Student.StudentID, Student.FirstName, Student.LastName, Student.GPA, Student_Interest.interestID" +
            "FROM Student INNER JOIN Student_Interest ON Student.StudentID = Student_Interest.studentID " +
            "INNER JOIN Application ON Student.StudentID = Application.studentID INNER JOIN " +
            "Posting ON Application.postingID = Posting.postingID where Posting.PostingID = 8;"
    };

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

            if (topCandidate.Count == 0)
            {
                topCandidate.Add(new TopCandidate(id, firstName, lastName, GPA));
            }
            for(int i=0; i<topCandidate.Count; i++)
            {
                if((((TopCandidate)topCandidate[i]).getFirstName() + ((TopCandidate)topCandidate[i]).getLastName()).Equals(firstName + lastName) == )
                {
                    ((TopCandidate)topCandidate[i]).fillStudentInterests(studentInterestID);
                }
            }
            topCandidate.Add(new TopCandidate(id, firstName, lastName, GPA));

        }

        sc.Close();

        sc.Open();
        System.Data.SqlClient.SqlCommand getPostingInterest = new System.Data.SqlClient.SqlCommand

        {
            Connection = sc,
            CommandText = "SELECT Posting.postingID, Posting_Interest.interestID FROM Posting INNER JOIN " +
            "Posting_Interest ON Posting.postingID = Posting_Interest.postingID where Posting.postingID = 8"
        };

        SqlDataReader reader2 = getPostingInterest.ExecuteReader();
        
        while (reader2.Read())
        {
            postingInterest.Add(1);
        }






        //Create an arraylist called finalValues that will store the numerical value of
        //each student. The formula is (GPA + (#ofMatchingInterests * .5)
        //for example, if a student has a 2.9 GPA and two matching interests, their finalValue
        //would be 2.9 + .5 + .5 = 3.9
        ArrayList finalValues = new ArrayList();
        ArrayList namesOfFinalValues = new ArrayList();
        double gpaCounter = 0;
        //for (int i = 0; i < rows; i++)
        //{
        //        gpaCounter = Convert.ToDouble(GPA[i]) + .5;
             
        //        if (i > 0)
        //        {
        //            if (names[i].Equals(names[i - 1]))
        //            {
        //                gpaCounter += .5;
                        
        //            }
        //            finalValues.Add(gpaCounter);
        //        }
    
        //}

        
        ////I find out the top 3 qualified candidates sorted by highest finalValue
        //finalValues.Sort();

        /////Determine the top candidates by who has the highest, second highest, and
        /////third highest value
        //double highestCandidate = Convert.ToDouble(finalValues[finalValues.Count - 1]);
        //double secondHighestCandidate = Convert.ToDouble(finalValues[finalValues.Count - 2]);

        //////////Find out what the maximum finalValue could be///////////
        ///*I find out what the max number of interests a person could have
        //  by finding out how many times their name repeates in the resultset*/
        //int nameRepeats = 1;
        //for (int i = 0; i < rows; i++)
        //{
        //    if (i > 0)
        //    {
        //        if (names[i].Equals(names[i - 1]))
        //        {        
        //            nameRepeats++;
        //        }
        //    }
        //}

        ////I now come up with what the max final value could be:
        //double finalValue = 4.0 + (nameRepeats * .5);
        

        /////Testing to the debugger console
        //Debug.WriteLine("number of rows: " + rows);
        //Debug.WriteLine("name at index of 0: " + names[0]);
        //Debug.WriteLine("GPA at index of 0: " + GPA[0]);
        //Debug.WriteLine("interest at index of 0: " + interest[0]);
        //Debug.WriteLine("final value at index of 0: " + finalValues[0]);
        //Debug.WriteLine("final value at index of 1: " + finalValues[1]);
        //Debug.WriteLine(nameRepeats);
        //Debug.WriteLine(finalValues.Count);
        //Debug.WriteLine(finalValue);
        //Debug.WriteLine(highestCandidate + " " + secondHighestCandidate);



        loggedInUser.Text = Session["username"].ToString();

        //recentApplicationsGV.UseAccessibleHeader = true;
        //recentApplicationsGV.HeaderRow.TableSection = TableRowSection.TableHeader;



        ////////////////Put data into Graph on Landing Page////////////////
        ///Grab the Posting Title from the Posting that the top candidates are related to
        sc.Open();
        System.Data.SqlClient.SqlCommand getPostingTitle = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,
            CommandText = "Select PostingTitle from Posting where postingID = 8;"
        };
        String postingSubTitle = getPostingTitle.ExecuteScalar().ToString();
        getPostingTitle.ExecuteNonQuery();
        sc.Close();

        ///set the Posting Title in the sub title
        topCandidateSubTitle.Text = "For: " + postingSubTitle;


        ///Add student information above the progress bar
        ApplicantOne.Text = "ME";

        ///Display the Data on the chart for the Top Candidate
        //String highestPercentage = (highestCandidate/finalValue).ToString(".%");
        //testprogress.Style.Add("width", highestPercentage);

        testprogress.Style.Add("role", "progressbar");
        testprogress.Style.Add("aria-valuenow", "75");
        testprogress.Style.Add("aria-valuemin", "0");
        testprogress.Style.Add("aria-valuemax", "100");
        //Old HTML: style="width: 75%" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"><


        ///Display the Data on the chart for the Second-Most Top Candidate
        //String secondHighestPercentage = (secondHighestCandidate / finalValue).ToString(".%");
        //testprogress2.Style.Add("width", secondHighestPercentage);

        testprogress.Style.Add("role", "progressbar");
        testprogress.Style.Add("aria-valuenow", "50");
        testprogress.Style.Add("aria-valuemin", "0");
        testprogress.Style.Add("aria-valuemax", "100");
        //Old HTML: style = "width: 50%" role = "progressbar" aria - valuenow = "50" aria - valuemin = "0" aria - valuemax = "100"

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}