using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class company_dashboard_SchoolInformation : System.Web.UI.Page
{
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
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();
        lblSchoolName.InnerText = Session["schoolName"].ToString();

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,
        };

        select.CommandText = "select state from school where SchoolName = '" + Session["schoolName"].ToString() + "'";
        lblState.InnerText = select.ExecuteScalar().ToString();

        select.CommandText = "select CityCounty from school where SchoolName = '" + Session["schoolName"].ToString() + "'";
        lblCity.InnerText = select.ExecuteScalar().ToString();

        select.CommandText = "select streetAddress from school where SchoolName = '" + Session["schoolName"].ToString() + "'";
        lblStreet.InnerText = select.ExecuteScalar().ToString();

        select.CommandText = "select counselor.firstName from School inner join Counselor ON " + Session["schoolID"].ToString() + "= Counselor.schoolID";
        lblCounselorFN.InnerText = select.ExecuteScalar().ToString();

        select.CommandText = "select counselor.lastName from School inner join Counselor ON " + Session["schoolID"].ToString() + "= Counselor.schoolID";
        lblCounselorLN.InnerText = select.ExecuteScalar().ToString();

        select.CommandText = "select counselor.email from School inner join Counselor ON " + Session["schoolID"].ToString() + "= Counselor.schoolID";
        lblCounselorEM.InnerText = select.ExecuteScalar().ToString();

        select.CommandText = "select counselor.phoneNumber from School inner join Counselor ON " + Session["schoolID"].ToString() + "= Counselor.schoolID";
        lblCounselorPN.InnerText = select.ExecuteScalar().ToString();

        select.CommandText = "select count(electiveID) from School inner join School_Electives ON " + Session["schoolID"].ToString() + "= School_Electives.schoolID group by School.SchoolName";
        electives.InnerText = select.ExecuteScalar().ToString();
    }

    public void logoutClick(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("/Login.aspx");
    }

   
}