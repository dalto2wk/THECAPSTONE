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
        int rows = 0;
        ArrayList names = new ArrayList();
        ArrayList GPA = new ArrayList();
        ArrayList interest = new ArrayList();

        while (reader.Read())
        {
            
            names.Add(reader.GetString(0) + " " + reader.GetString(1));
            GPA.Add(reader.GetDecimal(2));
            interest.Add(reader.GetString(3));
            rows++;
        }

        ArrayList finalValues = new ArrayList();

        double gpaCounter = 0;
        for(int i=0; i<rows; i++)
        {
            gpaCounter = Convert.ToDouble(GPA[0]) + .5;
            
            if (i > 0)
            {
                if(names[i] == names[i-1])
                {
                    gpaCounter += .5;
                }
                finalValues.Add(gpaCounter);
            }
            
        }
        Debug.WriteLine(rows);
        Debug.WriteLine(names[0]);
        Debug.WriteLine(GPA[0]);
        Debug.WriteLine(interest[0]);


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