using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
       

        String username = email.Text;
        String pwd = password.Text;
        
        //String validUsername = getUserName();
        getPassword(pwd, username);
        
        
    }

 

    protected String getUserName()
    {
        String result ="";

        

        
        return result;
    }

    protected void getPassword(String pass, String username)
    {
        
        try
        {




            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
            sc.Open();



            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
            {
                Connection = sc,
                CommandText = "select cpPassword from Employer where cpUserName = @Username"
           
            };

            select.Parameters.Add(new SqlParameter("@Username", username));
        

        SqlDataReader reader = select.ExecuteReader(); // create a reader
            Debug.WriteLine("First: ");
            if (reader.HasRows) // if the username exists, it will continue
            {
                Debug.WriteLine("Second: ");
                while (reader.Read()) // this will read the single record that matches the entered username
                {
                    string storedHash = reader["cpPassword"].ToString(); // store the database password into this variable
                    Debug.WriteLine("Password status: " + PasswordHash.ValidatePassword(pass, storedHash));
                    if (PasswordHash.ValidatePassword(password.Text, storedHash)) // if the entered password matches what is stored, it will show success
                    {
                        Response.Redirect("company-dashboard/LandingPage.aspx");
                    }
                  
                       
                }


                

                String sqlResult = select.ExecuteScalar().ToString();
                Debug.WriteLine(sqlResult + " is the Result: result");



                //String sqlResult = select.ExecuteScalar().ToString();




               
            }
        }
        catch
        {
           
        }

    }

    protected String getName(String password, String username)
    {
        String result = "";
        try
        {




            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
            sc.Open();

            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
            {
                Connection = sc,
                CommandText = "select cpName from Employer where cpPassword = '" + password + "' and cpUserName = '" + username + "'"
            };


            

            String sqlResult = select.ExecuteScalar().ToString();
            



            //String sqlResult = select.ExecuteScalar().ToString();

            result = sqlResult;


            return result;
        }
        catch
        {
            return result;
        }
    }
}