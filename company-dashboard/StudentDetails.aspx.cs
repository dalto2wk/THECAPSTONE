using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class company_dashboard_StudentDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<int> interestIDs = new List<int>();
        List<String> Interests = new List<String>();

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();
        lblFirstName.InnerText = Session["fName"].ToString();
        lblLastName.InnerText = Session["lName"].ToString();

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,
        };
        select.CommandText = "select academicyear from student where FirstName = '" + Session["fName"].ToString() + "' and LastName = '" + Session["lName"].ToString() + "'";
        lblAcademicYear.InnerText = select.ExecuteScalar().ToString();

        select.CommandText = "select email from student where FirstName = '" + Session["fName"].ToString() + "' and LastName = '" + Session["lName"].ToString() + "'";
        lblEmail.InnerText = select.ExecuteScalar().ToString();

        select.CommandText = "select phoneNumber from student where FirstName = '" + Session["fName"].ToString() + "' and LastName = '" + Session["lName"].ToString() + "'";
        lblPhone.InnerText = select.ExecuteScalar().ToString();

        select.CommandText = "select studentid from student where FirstName = '" + Session["fName"].ToString() + "' and LastName = '" + Session["lName"].ToString() + "'";
        int studentID = Convert.ToInt32(select.ExecuteScalar());

        select.CommandText = "select interestId from student_interest where studentid = '" + studentID + "'";
        SqlDataReader reader = select.ExecuteReader();
        ///add the posting interests into the postingInterest arraylist
        while (reader.Read())
        {
            interestIDs.Add(reader.GetInt32(0));
        }
        sc.Close();

        sc.Open();
        for(int i=0; i < interestIDs.Count ; i++)
        {
            select.CommandText = "select name from interest where interestID = '" + interestIDs[i] + "'";
            Interests.Add(select.ExecuteScalar().ToString());
        }

        for(int i = 0; i < Interests.Count; i++)
        {
            lblInterests.InnerText += Interests[i];
            lblInterests.InnerText += ", ";

        }


        select.CommandText = "select GPA from student where FirstName = '" + Session["fName"].ToString() + "' and LastName = '" + Session["lName"].ToString() + "'";
        lblgpa.InnerText = select.ExecuteScalar().ToString();

        select.CommandText = "select schoolid from student where FirstName = '" + Session["fName"].ToString() + "' and LastName = '" + Session["lName"].ToString() + "'";
        int schoolID = Convert.ToInt32(select.ExecuteScalar());

        select.CommandText = "select schoolName from school where schoolId = '" + schoolID.ToString() + "'";
        lblSchool.InnerText = select.ExecuteScalar().ToString();

    }    
}