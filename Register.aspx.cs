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
                CommandText = "Insert into Employer values (@businessName, @size, @industry, @description, @cpTitle, @cpName, @cpUserName, @cpPassword, @LastUpdatedBy, GETDATE())"
            };

            String businessName = CompanyName.Value;
            String industryName = industry.Value;
            String businessSize = size.Value;
            String desc = description.Value;
            String cpName = ContactName.Value;
            String cpTitle = title.Value;
            String cpUsername = username.Value;
            String cpPassword = password.Value;
            String cpPhone = Phone.Value;
            String cpEmail = email.Value;
            
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
}

