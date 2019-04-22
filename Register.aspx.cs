using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Diagnostics;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Method that handles the register button being clicked. Inserts user input into the database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RegisterBtnClick(object sender, EventArgs e)
    {
        //try
        //{


        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,
            CommandText = "Insert into Employer values (@businessName, @size, @industry, @description, @cpTitle, @cpName, @cpUserName, @cpPassword, @LastUpdatedBy, GETDATE(), @cpEmail, @cpPhone)"
        };

        String businessName = HttpUtility.HtmlEncode(CompanyName.Value);
        String industryName = HttpUtility.HtmlEncode(industry.Value);
        String businessSize = HttpUtility.HtmlEncode(size.Value);
        String desc = HttpUtility.HtmlEncode(description.Value);
        String cpName = HttpUtility.HtmlEncode(ContactName.Value);
        String cpTitle = HttpUtility.HtmlEncode(title.Value);
        String cpUsername = HttpUtility.HtmlEncode(username.Value);
        String cpPassword = HttpUtility.HtmlEncode(password.Value);
        String cpPhone = HttpUtility.HtmlEncode(Phone.Value);
        String cpEmail = HttpUtility.HtmlEncode(email.Value);

        Employer emp = new Employer(businessName, Convert.ToInt32(businessSize), industryName, desc, cpName, cpUsername, cpPassword, cpEmail, cpPhone, getNextEmpID());

        insert.Parameters.AddWithValue("@businessName", businessName);
        insert.Parameters.AddWithValue("@size", businessSize);
        insert.Parameters.AddWithValue("@industry", industryName);
        insert.Parameters.AddWithValue("@description", desc);
        insert.Parameters.AddWithValue("@cpTitle", cpTitle);
        insert.Parameters.AddWithValue("@cpName", cpName);
        insert.Parameters.AddWithValue("@cpUsername", cpUsername);
        insert.Parameters.AddWithValue("@cpPassword", PasswordHash.HashPassword(cpPassword));
        insert.Parameters.AddWithValue("@LastUpdatedBy", "484Team");
        insert.Parameters.AddWithValue("@cpEmail", cpEmail);
        insert.Parameters.AddWithValue("@cpPhone", cpPhone);


        insert.ExecuteNonQuery();


        Response.Redirect("Login.aspx");
        //double check that this works and add some emp id is getting retrieved from db


        //}
        //catch(Exception ex)
        //{

        //}
    }

    protected int getNextEmpID()
    {
        int result = 0;
        System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        cn.Open();

        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select max(employerID) from Employer", cn);

        System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default);

        if (dr.Read())
        {
            result = dr.GetInt32(0);
        }

        return result;
    }

    protected void PopulateBtnClick(object sender, EventArgs e)
    {
        CompanyName.Value = "James Madison University";
        industry.Value = "Computer Information Systems";
        size.Value = "20000";
        description.Value = "We provide consulting to local businesses to help them build efficient information systems to drive their businesses!";
        ContactName.Value = "John Alger";
        title.Value = "The President";
        username.Value = "dukes";
        password.Value = "dukes";
        Phone.Value = "804-123-4567";
        email.Value = "jmu@jmu.edu";
    }


    
}

