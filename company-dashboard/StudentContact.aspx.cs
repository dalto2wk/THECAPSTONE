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
        int buttonRowIndex = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = studentApplicationTable.Rows[buttonRowIndex];
        pdfProcessToDB();
    }
    protected void pdfProcessToDB()
    {
        System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        cn.Open();
        //file path 
        //file:///C:/Users/WK/Downloads/William%20Dalton%20Resume%202018.pdf
        //Add a pdf file in the below code to add to database
        //C:\\Users\\WK\\Downloads\\ProjectResumesSamples\\Jon Snow.pdf
        FileStream fStream = File.OpenRead("C:\\Users\\WK\\Downloads\\ProjectResumesSamples\\Jon Snow.pdf");
        byte[] contents = new byte[fStream.Length];
        fStream.Read(contents, 0, (int)fStream.Length);
        fStream.Close();

        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("Update Application set resume = (@data) where studentID = 3", cn);
        cmd.Parameters.AddWithValue("@Data", contents);
        cmd.ExecuteNonQuery();
        cn.Close();
    }
}