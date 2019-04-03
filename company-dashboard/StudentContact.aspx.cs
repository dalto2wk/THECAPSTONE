using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class company_dashboard_StudentContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //loggedInUser.Text = Session["username"].ToString();
        
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
            //Response.BinaryWrite(fileData);
            System.IO.FileStream fs = new System.IO.FileStream(savedFilePath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);

            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);

            bw.Write(fileData);
            bw.Close();
        }

        dr.Close();
        //the below way stores to solution using response.binarywrite is better
        Response.Redirect("~\\TempFiles\\Report.pdf");

    }
}