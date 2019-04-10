using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class company_dashboard_EditListing : System.Web.UI.Page
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
        listingToEdit.Text = Session["postingTitleToEdit"].ToString();

        if (!IsPostBack)
        {
            txtJobTitle.Value = Session["title"].ToString();
            txtRequirements.Value = Session["requirements"].ToString();
            txtDescription.Value = Session["description"].ToString();
            txtCpName.Value = Session["cpname"].ToString();
            txtCpPhone.Value = Session["cpphone"].ToString();
            txtCpEmail.Value = Session["cpemail"].ToString();
            txtpostStart.Value = String.Format("{0:MM/dd/yyyy}", Session["poststart"].ToString());
            txtpostEnd.Value = String.Format("{0:MM/dd/yyyy}", Session["postend"].ToString());
            txtopportunityStartDate.Value = String.Format("{0:MM/dd/yyyy}", Session["oppstart"].ToString());
            DropDownList_State.SelectedIndex = 46;
            DropDownList_City.SelectedIndex = 7028;


            String State = DropDownList_State.SelectedValue;
            String City = DropDownList_City.SelectedValue;

            PostingSchool.SelectCommand = "select SchoolID, SchoolName from School Where State = '" + State + "' and CityCounty = '" + City + "'";
            PostingSchool.DataBind();

            

            //46 and 7028



        }
        





    }


    public void logoutClick(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("/Login.aspx");
    }
    protected List<Interests> getPostingInterests()
    {
        List<Interests> result = new List<Interests>();

        //query SELECT        Interest.name,interest.interestID
        //FROM Posting INNER JOIN
        //                 Posting_Interest ON Posting.postingID = Posting_Interest.postingID INNER JOIN
        //                 Interest ON Posting_Interest.interestID = Interest.interestID where posting.postingID = 8

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,

            CommandText = "SELECT        Interest.name,interest.interestID FROM Posting INNER JOIN " +
                         "Posting_Interest ON Posting.postingID = Posting_Interest.postingID INNER JOIN " +
                         "Interest ON Posting_Interest.interestID = Interest.interestID where posting.postingID = @postingID"

        };
        select.Parameters.AddWithValue("@postingID", Session["postID"].ToString());

        SqlDataReader reader = select.ExecuteReader();

        while (reader.Read())
        {
            result.Add(new Interests(reader.GetString(0), reader.GetInt32(1)));
        }
        sc.Close();
        return result;
    }

    protected List<School> getPostingSchools()
    {
        List<School> result = new List<School>();
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,

            CommandText = "SELECT        School.SchoolName,School.SchoolID FROM Posting INNER JOIN " +
                         "Posting_School ON Posting.postingID = Posting_School.postingID INNER JOIN " +
                         "School ON Posting_School.SchoolID = School.SchoolID where posting.postingID = @postingID"

        };
        select.Parameters.AddWithValue("@postingID", Session["postID"].ToString());

        SqlDataReader reader = select.ExecuteReader();

        while (reader.Read())
        {
            result.Add(new School(reader.GetString(0), reader.GetInt32(1)));
        }
        sc.Close();

        return result;        
    }

    protected void updateBtnClick(object sender, EventArgs e)
    {
        //Response.Redirect("Listing.aspx");
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();

        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,
            
            CommandText = "Update posting set " +
             "postingTitle = @postingTitle," +
             "description  = @description, " +
             "jobRequirements = @jobRequirements, " +
             "cpName = @cpName, " +
             "cpEmail = @cpEmail, " +
             "cpPhone = @cpPhone, " +
             "postStart = @postStart, " +
             "postEnd = @postEnd, " +
             "opportunityStartDate = @opportunityStartDate, " +
             "lastUpdated = GetDATE()" +
             " where postingID = @postingID"

        };
        update.Parameters.AddWithValue("@postingTitle", txtJobTitle.Value);
        update.Parameters.AddWithValue("@description", txtDescription.Value);
        update.Parameters.AddWithValue("@jobRequirements", txtRequirements.Value);
        update.Parameters.AddWithValue("@cpName", txtCpName.Value);
        update.Parameters.AddWithValue("@cpEmail", txtCpEmail.Value);
        update.Parameters.AddWithValue("@cpPhone", txtCpPhone.Value);
        update.Parameters.AddWithValue("@postStart", txtpostStart.Value);
        update.Parameters.AddWithValue("@postEnd", txtpostEnd.Value);
        update.Parameters.AddWithValue("@opportunityStartDate", txtopportunityStartDate.Value);
        update.Parameters.AddWithValue("@postingID", Session["postID"].ToString());

        update.ExecuteNonQuery();

        //will need this for delete logic delete from posting_interest where postingid = 9 and interestID = 3
        List<Interests> interests = getPostingInterests();
        List<School> school = getPostingSchools();

        foreach(ListItem item in listBoxInterests.Items)
        {
            for(int i = 0; i < interests.Count; i++)
            {
                if (item.Text.Equals(interests[i].getName()) && item.Selected == false){
                    System.Data.SqlClient.SqlCommand deleteInterests = new System.Data.SqlClient.SqlCommand
                    {
                        Connection = sc,
                        CommandText = "delete from posting_interest where postingid = @postingID and interestID = @interestID"
                    };
                    deleteInterests.Parameters.AddWithValue("@postingID", Session["postID"].ToString());
                    deleteInterests.Parameters.AddWithValue("@interestID", item.Value);
                    deleteInterests.ExecuteNonQuery();
                }
            }
        }


        foreach (ListItem item in listBoxInterests.Items) {

                if (item.Selected == true)
                {
                    int count = 0; 
                    for (int i = 0; i < interests.Count; i++)
                    {
                        if (item.Text.Equals(interests[i].getName()))
                        {
                            count++;
                        }

                    }
                    if(count != 0)
                    {
                        continue;
                    } else if(count == 0)
                    {
                        PostingInterest pi = new PostingInterest(Convert.ToInt32(Session["postID"].ToString()), Convert.ToInt32(item.Value));
                        //do the sql
                        System.Data.SqlClient.SqlCommand postingInterests = new System.Data.SqlClient.SqlCommand
                        {
                            Connection = sc,
                            CommandText = "Insert into Posting_Interest values (@postingID, @interestID, @LastUpdatedBy, @LastUpdated)"
                        };
                        postingInterests.Parameters.AddWithValue("@postingID", pi.getPostingID());
                        postingInterests.Parameters.AddWithValue("@interestID", pi.getInterestID());
                        postingInterests.Parameters.AddWithValue("@LastUpdatedBy", pi.getLastUpdatedBy());
                        postingInterests.Parameters.AddWithValue("@LastUpdated", pi.getLastUpdated());

                        postingInterests.ExecuteNonQuery();
                    }
                }

        }

        //schoolforeachloops

        foreach (ListItem item in listBoxSchool.Items)
        {
            for (int i = 0; i < school.Count; i++)
            {
                if (item.Text.Equals(school[i].getName()) && item.Selected == false)
                {
                    System.Data.SqlClient.SqlCommand deleteSchools = new System.Data.SqlClient.SqlCommand
                    {
                        Connection = sc,
                        CommandText = "delete from posting_School where postingid = @postingID and SchoolID = @SchoolID"
                    };
                    deleteSchools.Parameters.AddWithValue("@postingID", Session["postID"].ToString());
                    deleteSchools.Parameters.AddWithValue("@SchoolID", item.Value);
                    deleteSchools.ExecuteNonQuery();
                }
            }
        }


        foreach (ListItem item in listBoxSchool.Items)
        {

            if (item.Selected == true)
            {
                int count = 0;
                for (int i = 0; i < school.Count; i++)
                {
                    if (item.Text.Equals(school[i].getName()))
                    {
                        count++;
                    }

                }
                if (count != 0)
                {
                    continue;
                }
                else if (count == 0)
                {
                    PostingSchool ps = new PostingSchool(Convert.ToInt32(Session["postID"].ToString()), Convert.ToInt32(item.Value));
                    //do the sql
                    System.Data.SqlClient.SqlCommand postingSchools = new System.Data.SqlClient.SqlCommand
                    {
                        Connection = sc,
                        CommandText = "Insert into Posting_School values (@postingID, @SchoolID, @LastUpdatedBy, @LastUpdated)"
                    };
                    postingSchools.Parameters.AddWithValue("@postingID", ps.getPostingID());
                    postingSchools.Parameters.AddWithValue("@SchoolID", ps.getSchoolID());
                    postingSchools.Parameters.AddWithValue("@LastUpdatedBy", ps.getLastUpdatedBy());
                    postingSchools.Parameters.AddWithValue("@LastUpdated", ps.getLastUpdated());

                    postingSchools.ExecuteNonQuery();
                }
            }

        }





        sc.Close();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        

        List<Interests> interests = getPostingInterests();
        List<School> school = getPostingSchools();
        

        for (int i = 0; i < interests.Count; i++)
        {
            foreach (ListItem item in listBoxInterests.Items)
            {
                
                if (item.Text.Equals(interests[i].getName()))
                {
                    item.Selected = true;
                }
            }
        }

        for (int i = 0; i < school.Count; i++)
        {
            foreach (ListItem item in listBoxSchool.Items)
            {

                if (item.Text.Equals(school[i].getName()))
                {
                    item.Selected = true;
                }
            }
        }
    }
    protected void StateSelection_Change(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        //   DataTable dt = new DataTable();
        System.Data.SqlClient.SqlCommand newCity = new System.Data.SqlClient.SqlCommand();
        newCity.Connection = sc;
        String State = DropDownList_State.SelectedValue;



        SqlDataSourceCity.SelectCommand = "select citycounty from cities where state = '" + State + "'";
        SqlDataSourceCity.DataBind();



        /*
        try
        {
            sc.Open();
            newCity.CommandText = "SELECT CityCounty FROM cities WHERE State = " + DropDownList_State.SelectedValue;
            string sqlStatement = "SELECT ColumnName * FROM TableName";
            SqlCommand sqlCmd = new SqlCommand(sqlStatement, sc);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DropDownList_City.DataSource = dt;
                DropDownList_City.DataTextField = "CityCounty"; // the items to be displayed in the list items
                DropDownList_City.DataValueField = "CityCounty"; // the id of the items displayed
                DropDownList_City.DataBind();
                sc.Close();
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Fetch Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            sc.Close();
        }
        */

    }

    protected void CitySelection_Change(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

        System.Data.SqlClient.SqlCommand newSchool = new System.Data.SqlClient.SqlCommand();
        newSchool.Connection = sc;
        String State = DropDownList_State.SelectedValue;
        String City = DropDownList_City.SelectedValue;

        PostingSchool.SelectCommand = "select SchoolID, SchoolName from School Where State = '" + State + "' and CityCounty = '" + City + "'";
        PostingSchool.DataBind();
    }

    protected void messageVisible(object sender, EventArgs e)
    {
        lblConfirmationDelete.Visible = true;
        btnYes.Visible = true;
        btnNo.Visible = true;
    }

    protected void messageHide(object sender, EventArgs e)
    {
        lblConfirmationDelete.Visible = false;
        btnYes.Visible = false;
        btnNo.Visible = false;
    }
    protected void deleteBtnClick(object sender, EventArgs e)
    {
        try
        {

            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
            sc.Open();

            System.Data.SqlClient.SqlCommand delete = new System.Data.SqlClient.SqlCommand
            {
                Connection = sc,

                CommandText = "delete from Posting_School where PostingID = @postingID " +
                              "delete from Posting_Interest where postingID = @postingID " +
                              "delete from Posting where postingID = @postingID"

            };

            delete.Parameters.AddWithValue("@postingID", Session["postID"].ToString());
            delete.ExecuteNonQuery();


            sc.Close();

            Response.Redirect("Listing.aspx");


        }
        catch
        {

        }
    }


}



