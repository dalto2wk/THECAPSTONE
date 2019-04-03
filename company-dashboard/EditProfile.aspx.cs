using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Diagnostics;

public partial class EditProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["username"] == null)
        {
            Response.Redirect("/Login.aspx");
        }
        else
        {
            // uncomment when this page is stragiht
            //loggedInUser.Text = Session["username"].ToString();
        }
        
        industry.Value = Session["username"].ToString();
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();

        if (!IsPostBack)
        {
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand
            {
                Connection = sc,
                //CommandText = "Insert into Employer values (@businessName, @size, @industry, @description, @cpTitle, @cpName, @cpUserName, @cpPassword, @LastUpdatedBy, GETDATE())"
                CommandText = "select businessName from Employer where cpUserName = '" + Session["username"].ToString() + "'"
            };

            
            CompanyName.Value = insert.ExecuteScalar().ToString();

            insert.CommandText = "select size from Employer where cpUserName = '" + Session["username"].ToString() + "'";
            size.Value = insert.ExecuteScalar().ToString();

            insert.CommandText = "select industry from Employer where cpUserName = '" + Session["username"].ToString() + "'";
            industry.Value = insert.ExecuteScalar().ToString();

            insert.CommandText = "select description from Employer where cpUserName = '" + Session["username"].ToString() + "'";
            description.Value = insert.ExecuteScalar().ToString();

            insert.CommandText = "select cptitle from Employer where cpUserName = '" + Session["username"].ToString() + "'";
            title.Value = insert.ExecuteScalar().ToString();

            insert.CommandText = "select cpName from Employer where cpUserName = '" + Session["username"].ToString() + "'";
            ContactName.Value = insert.ExecuteScalar().ToString();

            insert.CommandText = "select cpUserName from Employer where cpUserName = '" + Session["username"].ToString() + "'";
            username.Value = insert.ExecuteScalar().ToString();

            insert.CommandText = "select email from Employer where cpUserName = '" + Session["username"].ToString() + "'";
            email.Value = insert.ExecuteScalar().ToString();

            insert.CommandText = "select cpPhone from Employer where cpUserName = '" + Session["username"].ToString() + "'";
            Phone.Value = insert.ExecuteScalar().ToString();
        }
        sc.Close();

    }
    public void logoutClick(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("/Login.aspx");
    }
    protected void RegisterBtnClick(object sender, EventArgs e)
    {
        //try
        //{

        industry.Value = Session["username"].ToString();
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();

        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,
            //CommandText = "Insert into Employer values (@businessName, @size, @industry, @description, @cpTitle, @cpName, @cpUserName, @cpPassword, @LastUpdatedBy, GETDATE())"
            CommandText = "Update employer  set " +
             "businessName = @businessName," +
             "size  = @size, " +
             "industry = @industry, " +
             "description = @description, " +
             "cpTitle = @cpTitle, " +
             "cpName = @cpName, " +
             "cpUserName = @cpUserName, " +
             "cpPassword = @cpPassword, " +
             "email = @email, " +
             "cpPhone = @phone," +
             "lastUpdated = @lastUpdated"+
             " where cpUserName = '" + Session["username"].ToString() + "'"

    };

        update.Parameters.AddWithValue("@businessName", CompanyName.Value);
        update.Parameters.AddWithValue("@size", size.Value);
        update.Parameters.AddWithValue("@industry", industry.Value);
        update.Parameters.AddWithValue("@description", description.Value);
        update.Parameters.AddWithValue("@cpTitle", title.Value);
        update.Parameters.AddWithValue("@cpName", ContactName.Value);
        update.Parameters.AddWithValue("@cpUserName", username.Value);
        update.Parameters.AddWithValue("@cpPassword", PasswordHash.HashPassword(password.Value));
        update.Parameters.AddWithValue("@email", email.Value);
        update.Parameters.AddWithValue("@Phone", Phone.Value);
        update.Parameters.AddWithValue("@lastUpdated", DateTime.Now);

        update.ExecuteScalar();






        //String businessName = CompanyName.Value;
        //String industryName = industry.Value;
        //String businessSize = size.Value;
        //String desc = description.Value;
        //String cpName = ContactName.Value;
        //String cpTitle = title.Value;
        //String cpUsername = username.Value;
        //String cpPassword = password.Value;
        //String cpPhone = Phone.Value;
        //String cpEmail = email.Value;

        //Employer emp = new Employer(businessName, Convert.ToInt32(businessSize), industryName, desc, cpName, cpUsername, cpPassword, cpEmail, cpPhone, 1);

        //insert.Parameters.AddWithValue("@businessName", businessName);
        //insert.Parameters.AddWithValue("@size", businessSize);
        //insert.Parameters.AddWithValue("@industry", industryName);
        //insert.Parameters.AddWithValue("@description", desc);
        //insert.Parameters.AddWithValue("@cpTitle", cpTitle);
        //insert.Parameters.AddWithValue("@cpName", cpName);
        //insert.Parameters.AddWithValue("@cpUsername", cpUsername);
        //insert.Parameters.AddWithValue("@cpPassword", PasswordHash.HashPassword(cpPassword));
        //insert.Parameters.AddWithValue("@LastUpdatedBy", "484Team");
        //insert.ExecuteNonQuery();

        //Response.Redirect("Login.aspx");
        //double check that this works and add some emp id is getting retrieved from db


        //}
        //catch(Exception ex)
        //{

        //}
        sc.Close();
    }
}

