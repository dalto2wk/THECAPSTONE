using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        bool isValidPassword = getPassword(pwd, username);
        if(isValidPassword == true)
        {
            Session["username"] = username;
            Session["EmpName"] = getName(pwd, username);
            Response.Redirect("company-dashboard/LandingPage.aspx");
        } else
        {

        }
        
    }

    protected String getUserName()
    {
        String result ="";



        
        return result;
    }

    protected bool getPassword(String password, String username)
    {
        bool result = false;
        try
        {


            

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
            sc.Open();

            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
            {
                Connection = sc,
                CommandText = "select cpPassword, cpUserName from Employer where cpPassword = '" + password + "' and cpUserName = '" + username + "'"
            };

            
            if(select.ExecuteScalar().ToString() != null)
            {
                result = true;
            }
                
                String sqlResult = select.ExecuteScalar().ToString();
                Debug.WriteLine(sqlResult + " is the Result: result");
            


            //String sqlResult = select.ExecuteScalar().ToString();




            return result;
        }
        catch
        {
            return result;
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