using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class company_dashboard_SchoolContact : System.Web.UI.Page
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
        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,

            CommandText = "select employerID from Employer where cpUserName = '" + Session["username"].ToString() + "'"

        };


        Session["EmpID"] = Convert.ToString(select.ExecuteScalar());

        Sqldatasource1.SelectCommand = "SELECT Approval_Status.EmployerID, School.SchoolID,       School.SchoolName, School.CityCounty, School.state, Approval_Status.Approval_Status " +
            "FROM Approval_Status inner join School ON Approval_Status.SchoolID = School.SchoolID where Approval_Status.Approval_Status != 'Approved' AND Approval_Status.EmployerID = '" + Session["EmpID"] + "'";
        Sqldatasource1.DataBind();
        GridView1.DataBind();

        Sqldatasource2.SelectCommand = "SELECT Approval_Status.EmployerID, School.SchoolID,       School.SchoolName, School.CityCounty, School.state, Approval_Status.Approval_Status " +
            "FROM Approval_Status inner join School ON Approval_Status.SchoolID = School.SchoolID where Approval_Status.Approval_Status = 'Approved' AND Approval_Status.EmployerID = '" + Session["EmpID"] + "'";
        Sqldatasource2.DataBind();
        GridView2.DataBind();

    }

    public void viewInfo(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "viewInfo")
        {
            int buttonRowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[buttonRowIndex];
            string schoolid = row.Cells[0].Text;
            string schoolname = row.Cells[1].Text;

            Session["schoolName"] = schoolname;
            Session["schoolID"] = schoolid;


            Response.Redirect("SchoolInformation.aspx");
        }
    }
    public void logoutClick(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("/Login.aspx");
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {

        Sqldatasource1.SelectCommand = "SELECT Approval_Status.EmployerID, School.SchoolID,       School.SchoolName, School.CityCounty, School.state, Approval_Status.Approval_Status " +
            "FROM Approval_Status inner join School ON Approval_Status.SchoolID = School.SchoolID where Approval_Status.Approval_Status != 'Approved' AND Approval_Status.EmployerID = '" + Session["EmpID"]+"'";
        Sqldatasource1.DataBind();
        GridView1.DataBind();
    }

    protected void Unnamed_Click2(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();
        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,

            CommandText = "select employerID from Employer where cpUserName = '" + Session["username"].ToString() + "'"

        };


        Session["EmpID"] = Convert.ToString(select.ExecuteScalar());

    }
}
