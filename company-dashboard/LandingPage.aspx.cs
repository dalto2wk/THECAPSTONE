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
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();


        String firstName;
        String lastName;
        Double GPA;

        System.Data.SqlClient.SqlCommand topCandidate = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,
            CommandText = "SELECT Student.FirstName, Student.LastName, Student.GPA, Interest.name " +
            "FROM Posting_Interest INNER JOIN Posting ON Posting_Interest.postingID = Posting.postingID " +
            "INNER JOIN Application ON Posting.postingID = Application.postingID INNER JOIN Student " +
            "INNER JOIN Student_Interest ON Student.StudentID = Student_Interest.studentID " +
            "ON Application.studentID = Student.StudentID inner JOIN Interest " +
            "ON Posting_Interest.interestID = Interest.interestID " +
            "AND Student_Interest.interestID = Interest.interestID where Posting.postingID = 8;"

        };

        SqlDataReader reader = topCandidate.ExecuteReader();
        int row = 0;
        ArrayList names = new ArrayList();
        ArrayList nameInterest = new ArrayList();
        int multiplier = 0;

        while (reader.Read())
        {
            row++;
            names.Add(reader.GetString(0) + reader.GetString(1));
        }

        Debug.WriteLine(row);
        Debug.WriteLine(names[0]);


        loggedInUser.Text = Session["username"].ToString();
        //recentApplicationsGV.UseAccessibleHeader = true;
        //recentApplicationsGV.HeaderRow.TableSection = TableRowSection.TableHeader;
        testprogress.Style.Add("width", "95%");

        //style="width: 75%" role="progressbar" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"><

        testprogress.Style.Add("role", "progressbar");
        testprogress.Style.Add("aria-valuenow", "75");
        testprogress.Style.Add("aria-valuemin", "0");
        testprogress.Style.Add("aria-valuemax", "100");


        
    }
}