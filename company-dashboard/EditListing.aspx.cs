using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class company_dashboard_EditListing : System.Web.UI.Page
{

    public static int count1 = 0;
    public static int count2 = 0;
/// <summary>
/// Page load method that assigns session variables that are needed to populate the form with data
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

      //  Debug.WriteLine(count1);
      //  Debug.WriteLine(count2);



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
            //DropDownList_State.SelectedItem.Value = Session["state"].ToString();
            //DropDownList_City.SelectedItem.Value = Session["cityCounty"].ToString();



            




            



        }

        
    }

   
/// <summary>
/// Method that logs out the user and clears all session variables
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    public void logoutClick(object sender, EventArgs e)
    {
        count1 = 0;
        count2 = 0;
        Session.Abandon();
        Response.Redirect("/Login.aspx");
        
    }
    /// <summary>
    /// Gets all the interests related to a posting from the database
    /// </summary>
    /// <returns>A list of interests related to the current page posting</returns>
    protected List<Interests> getPostingInterests()
    {
        List<Interests> result = new List<Interests>();
        try
        {


            

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
            
        }
        catch
        {
           
        }
        return result;
    }
    /// <summary>
    /// Gets the state for a posting
    /// </summary>
    /// <returns>Returns the location state of a posting</returns>
    protected Location getPostingState()
    {
        Location result = null;
        try
        {


            
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
            sc.Open();

            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
            {
                Connection = sc,

                CommandText = "SELECT        cities.State, cities.LocationID FROM Posting INNER JOIN " +
                             "Posting_Location ON Posting.postingID = Posting_Location.postingID INNER JOIN " +
                             "cities ON Posting_Location.LocationID = cities.LocationID where posting.postingID = @postingID"

            };
            select.Parameters.AddWithValue("@postingID", Session["postID"].ToString());

            SqlDataReader reader = select.ExecuteReader();

            while (reader.Read())
            {
                result = new Location(reader.GetString(0), reader.GetInt32(1));
            }
            sc.Close();

            
        }
        catch
        {
            
        }
        return result;
    }
/// <summary>
/// Gets the schools that the current posting has been posted too
/// </summary>
/// <returns>A list of schools </returns>
    protected List<School> getPostingSchools()
    {
        List<School> result = new List<School>();
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
            sc.Open();

            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
            {
                Connection = sc,

                CommandText = "SELECT        School.SchoolName FROM            School INNER JOIN Posting_School ON School.SchoolID = Posting_School.SchoolID INNER JOIN Posting_Location ON Posting_School.PostingID = Posting_Location.PostingID where Posting_School.PostingID = @PostingID and Posting_Location.PostingID = @PostingID"

            };
            select.Parameters.AddWithValue("@postingID", Session["postID"].ToString());


            SqlDataReader reader = select.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new School(reader.GetString(0)));
            }
            sc.Close();
        }
        catch
        {

        }
        return result;        
    }
/// <summary>
/// Gets the city that a posting has been posted into 
/// </summary>
/// <returns>The current posting's city</returns>
    protected Location getPostingCity()
    {
        Location result = null;
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
            sc.Open();

            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
            {
                Connection = sc,

                CommandText = "SELECT        cities.CityCounty, cities.LocationID FROM Posting INNER JOIN " +
                             "Posting_Location ON Posting.postingID = Posting_Location.postingID INNER JOIN " +
                             "cities ON Posting_Location.LocationID = cities.LocationID where posting.postingID = @postingID"

            };
            select.Parameters.AddWithValue("@postingID", Session["postID"].ToString());

            SqlDataReader reader = select.ExecuteReader();

            while (reader.Read())
            {
                result = new Location(reader.GetString(0), reader.GetInt32(1));
            }
            sc.Close();
        }
        catch
        {

        }
        return result;
    }


/// <summary>
/// Handles the update button being clicked. Updates the current posting with inputted data
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    protected void updateBtnClick(object sender, EventArgs e)
    {
        //try
        //{
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
            update.Parameters.AddWithValue("@postingTitle", HttpUtility.HtmlEncode(txtJobTitle.Value));
            update.Parameters.AddWithValue("@description", HttpUtility.HtmlEncode(txtDescription.Value));
            update.Parameters.AddWithValue("@jobRequirements", HttpUtility.HtmlEncode(txtRequirements.Value));
            update.Parameters.AddWithValue("@cpName", HttpUtility.HtmlEncode(txtCpName.Value));
            update.Parameters.AddWithValue("@cpEmail", HttpUtility.HtmlEncode(txtCpEmail.Value));
            update.Parameters.AddWithValue("@cpPhone", HttpUtility.HtmlEncode(txtCpPhone.Value));
            update.Parameters.AddWithValue("@postStart", HttpUtility.HtmlEncode(txtpostStart.Value));
            update.Parameters.AddWithValue("@postEnd", HttpUtility.HtmlEncode(txtpostEnd.Value));
            update.Parameters.AddWithValue("@opportunityStartDate", HttpUtility.HtmlEncode(txtopportunityStartDate.Value));
            update.Parameters.AddWithValue("@postingID", Session["postID"].ToString());

            update.ExecuteNonQuery();

            //will need this for delete logic delete from posting_interest where postingid = 9 and interestID = 3
            List<Interests> interests = getPostingInterests();
            List<School> school = getPostingSchools();
            Location State = getPostingState();
            Location City = getPostingCity();

            foreach (ListItem item in DropDownList_State.Items)
            {
                if (item.Text.Equals(State.getName()) && item.Selected == false)
                {
                    System.Data.SqlClient.SqlCommand deleteState = new System.Data.SqlClient.SqlCommand
                    {
                        Connection = sc,
                        CommandText = "delete posting_location where postingid = @postingID and locationID = @locationID"
                    };
                    deleteState.Parameters.AddWithValue("@postingID", Session["postID"].ToString());
                    deleteState.Parameters.AddWithValue("@locationID", item.Value);
                    deleteState.ExecuteNonQuery();
                }
            }



            foreach (ListItem item in DropDownList_City.Items)
            {
                if (item.Text.Equals(City.getName()) && item.Selected == false)
                {
                    System.Data.SqlClient.SqlCommand deleteCity = new System.Data.SqlClient.SqlCommand
                    {
                        Connection = sc,
                        CommandText = "delete posting_location where postingid = @postingID and locationID = @locationID"
                    };
                    deleteCity.Parameters.AddWithValue("@postingID", Session["postID"].ToString());
                    deleteCity.Parameters.AddWithValue("@locationID", item.Value);
                    deleteCity.ExecuteNonQuery();
                }
            }

            foreach (ListItem item in DropDownList_City.Items)
            {
                if (item.Selected == true && cityAlreadyPostedTo(Convert.ToInt32(Session["postID"].ToString()), Convert.ToInt32(item.Value)) == false)
                {
                    PostingLocation pl = new PostingLocation(Convert.ToInt32(Session["postID"].ToString()), Convert.ToInt32(item.Value));
                    Debug.WriteLine(item.Value);
                    //do the sql
                    System.Data.SqlClient.SqlCommand postingLocation = new System.Data.SqlClient.SqlCommand
                    {
                        Connection = sc,
                        CommandText = "Insert into Posting_Location values (@postingID, @LocationID)"
                    };
                    postingLocation.Parameters.AddWithValue("@postingID", pl.getPostingID());
                    postingLocation.Parameters.AddWithValue("@locationID", pl.getLocationID());


                    postingLocation.ExecuteNonQuery();
                }
            }



            foreach (ListItem item in listBoxInterests.Items)
            {
                for (int i = 0; i < interests.Count; i++)
                {
                    if (item.Text.Equals(interests[i].getName()) && item.Selected == false)
                    {
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


            foreach (ListItem item in listBoxInterests.Items)
            {

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
                    if (count != 0)
                    {
                        continue;
                    }
                    else if (count == 0)
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
            if (fileUp.HasFile == true)
            {
                //set file to null in constructor and then other wise use set file and call the method 
                //post.setfile();
                //post.setfile(fileUp.FileContent);
                System.Data.SqlClient.SqlCommand images = new System.Data.SqlClient.SqlCommand
                {
                    Connection = sc,
                    CommandText = "Insert into Posting_Images values (@postingID, @imageFile)"
                };
                images.Parameters.AddWithValue("@postingID", getMaxPostingID());
                images.Parameters.Add("@imageFile", SqlDbType.VarBinary);
                HttpFileCollection fileCollection = Request.Files;
                for (int i = 0; i < fileCollection.Count; i++)
                {
                    HttpPostedFile postedFile = fileCollection[i];
                    if (postedFile.ContentLength > 0)
                    {
                        Stream fStream = postedFile.InputStream;
                        byte[] contents = new byte[fStream.Length];
                        fStream.Read(contents, 0, (int)fStream.Length);
                        fStream.Close();
                        images.Parameters["@imageFile"].Value = contents;


                    }

                    images.ExecuteNonQuery();
                }

                sc.Close();
            }
        //}
        //catch
        //{

        //}
    }

    public bool cityAlreadyPostedTo(int postingID, int locationID)
    {
        bool result = true;
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand
        {
            Connection = sc,

            CommandText = "select postingid, locationid from Posting_Location where postingID=@postingID and locationID=@locationID"

        };
        select.Parameters.AddWithValue("@postingID", postingID);
        select.Parameters.AddWithValue("@locationID", locationID);
        SqlDataReader reader = select.ExecuteReader();

        

        return reader.Read(); 
    }

    /// <summary>
    /// populates the page with the data from the database
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_PreRender(object sender, EventArgs e)
    {


        //try
        //{
            List<Interests> interests = getPostingInterests();
            List<School> school = getPostingSchools();
            Location State = getPostingState();
            Location City = getPostingCity();

            //   if (count1 < 1)

            if (IsPostBack == false)

            {
                foreach (ListItem item in DropDownList_State.Items)
                {
                    if (item.Text.Equals(State.getName()))
                    {

                        item.Selected = true;
                        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

                        System.Data.SqlClient.SqlCommand newSchool = new System.Data.SqlClient.SqlCommand();
                        newSchool.Connection = sc;

                        listBoxSchool.AutoPostBack = false;
                        PostingSchool.SelectCommand = "select SchoolID, SchoolName from School Where State = '" + State.getName() + "' and CityCounty = '" + City.getName() + "'";
                        PostingSchool.DataBind();

                        Debug.WriteLine(State.getName());

                        SqlDataSourceCity.SelectCommand = "select locationID, citycounty from cities where state = '" + State.getName() + "'";

                        SqlDataSourceCity.DataBind();

                    }

                }


            }



            //   if (count2 < 1)

            if (IsPostBack == false)

            {
                foreach (ListItem item in DropDownList_City.Items)
                {
                    if (item.Text.Equals(City.getName()))
                    {

                        item.Selected = true;
                        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

                        System.Data.SqlClient.SqlCommand newSchool = new System.Data.SqlClient.SqlCommand();
                        newSchool.Connection = sc;
                        listBoxSchool.AutoPostBack = false;
                        PostingSchool.SelectCommand = "select SchoolID, SchoolName from School Where State = '" + State.getName() + "' and CityCounty = '" + City.getName() + "'";
                        PostingSchool.DataBind();
                    }




                }


            }

        //i need to loop through the image datalist and find the element id of postImage and call writeImage or break up the write method to do an image at a time

        //uploadedImage.ImageUrl = "~\\listingFiles\\" + Session["username"].ToString() + "_" + Session["title"].ToString() + ".jpg";

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
            
        //}
        //catch
        //{

        //}
    }

    protected String writeImage()
    {
        String result = "";

        
        System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        cn.Open();

        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select imageFile,postingImageID from Posting_Images where postingID= @postingID", cn);
        cmd.Parameters.AddWithValue("@postingID", Session["postID"].ToString());

        System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default);
        string postingImageID = "";
        while (dr.Read())
        {
            byte[] fileData = (byte[])dr.GetValue(0);
            postingImageID = dr.GetInt32(1).ToString();
            string savedFilePath = Server.MapPath("~\\listingFiles\\" + Session["username"].ToString() + "_" + Session["title"].ToString() + postingImageID+ ".jpg");
            System.IO.FileStream fs = new System.IO.FileStream(savedFilePath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);

            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
            //Response.ContentType = "images/jpeg";
            //Response.BinaryWrite(fileData);
            bw.Write(fileData);
            bw.Close();
            //var image = (Page.FindControl("Image1") as Image).Controls.OfType<Image>();
            
            //foreach(Control c in image)
            //{
            //    if(c is Image)
            //    {
            //        ((Image)c).ImageUrl = "~\\listingFiles\\" + Session["username"].ToString() + "_" + Session["title"].ToString() + postingImageID + ".jpg";
            //    }
            //}

            
        }
        
        
        //HtmlGenericControl image = DataList1.Item.FindControl("Image1") as HtmlGenericControl;
        dr.Close();
        //the below way stores to solution using response.binarywrite is better
        //Response.Redirect("~\\Files\\Report.pdf");


        return "~\\listingFiles\\" + Session["username"].ToString() + "_" + Session["title"].ToString() + postingImageID + ".jpg";
    }

  
    protected void StateSelection_Change(object sender, EventArgs e)
    {
        count1 = 1;
        
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        //   DataTable dt = new DataTable();
        System.Data.SqlClient.SqlCommand newCity = new System.Data.SqlClient.SqlCommand();
        newCity.Connection = sc;
        String State = DropDownList_State.SelectedItem.Text;
        String City = DropDownList_City.SelectedItem.Text;




        SqlDataSourceCity.SelectCommand = "select citycounty from cities where state = '" + State + "'";
        SqlDataSourceCity.DataBind();

        PostingSchool.SelectCommand = "select SchoolID, SchoolName from School Where State = '" + State + "' and CityCounty = '" + City + "'";
        PostingSchool.DataBind();



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
        count2 = 1;

        

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);

        System.Data.SqlClient.SqlCommand newSchool = new System.Data.SqlClient.SqlCommand();
        newSchool.Connection = sc;
        String State = DropDownList_State.SelectedItem.Text;
        String City = DropDownList_City.SelectedItem.Text;
       
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
    protected void populate_Click(object sender, EventArgs e)
    {
        txtJobTitle.Value = "Summer coding camp";
        txtDescription.Value = "This is a shadowing and learning opportunity for a high school student to spend two weeks learning how to code";
        txtpostStart.Value = "04/16/2019";
        txtpostEnd.Value = "04/21/2019";
        txtopportunityStartDate.Value = "04/28/2019";
        txtCpName.Value = "John Madison";
        txtCpEmail.Value = "jmad@gmail.com";
        txtCpPhone.Value = "555/555-5555";
        txtRequirements.Value = "Must be interested in technology and have some basic computer skills";
    }

    /// <summary>
    /// Method that gets the highest posting ID from the database
    /// </summary>
    /// <returns></returns>
    private int getMaxPostingID()
    {
        int result = 0;

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        sc.Open();

        System.Data.SqlClient.SqlCommand maxID = new System.Data.SqlClient.SqlCommand();
        maxID.Connection = sc;
        maxID.CommandText = "select max(PostingID) from Posting";

        result = Convert.ToInt32(maxID.ExecuteScalar());
        maxID.ExecuteNonQuery();

        sc.Close();

        return result;
    }

    protected void writeImage(object sender, DataListItemEventArgs e)
    {
        System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["AWSString"].ConnectionString);
        cn.Open();

        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("select imageFile,postingImageID from Posting_Images where postingID= @postingID", cn);
        cmd.Parameters.AddWithValue("@postingID", Session["postID"].ToString());

        System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.Default);
        string postingImageID = "";
        while (dr.Read())
        {
            byte[] fileData = (byte[])dr.GetValue(0);
            postingImageID = dr.GetInt32(1).ToString();
            string savedFilePath = Server.MapPath("~\\listingFiles\\" + Session["username"].ToString() + "_" + Session["title"].ToString() + postingImageID + ".jpg");
            System.IO.FileStream fs = new System.IO.FileStream(savedFilePath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);

            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
            //Response.ContentType = "images/jpeg";
            //Response.BinaryWrite(fileData);
            bw.Write(fileData);
            bw.Close();
            fs.Close();
            //var image = (Page.FindControl("Image1") as Image).Controls.OfType<Image>();

            //foreach (Control c in image)
            //{
            //    if (c is Image)
            //    {
            //        ((Image)c).ImageUrl = "~\\listingFiles\\" + Session["username"].ToString() + "_" + Session["title"].ToString() + postingImageID + ".jpg";
            //    }
            //}

            if(e.Item.ItemType == ListItemType.Item)
            {
                DataRowView drv = (DataRowView)(e.Item.DataItem);
                Image image = (Image)e.Item.FindControl("Image1");
                image.ImageUrl = "~\\listingFiles\\" + Session["username"].ToString() + "_" + Session["title"].ToString() + postingImageID + ".jpg";
                //((Image)(e.Item.DataItem)).ImageUrl = "~\\listingFiles\\" + Session["username"].ToString() + "_" + Session["title"].ToString() + postingImageID + ".jpg";
            }


        }


        //HtmlGenericControl image = DataList1.Item.FindControl("Image1") as HtmlGenericControl;
        dr.Close();
        //the below way stores to solution using response.binarywrite is better
        //Response.Redirect("~\\Files\\Report.pdf");

    }
}



