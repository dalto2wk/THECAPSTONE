using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PostingSchool
/// </summary>
public class PostingSchool
{
    private int postingID;
    private int SchoolID;
    private string lastUpdatedBy;
    private string lastUpdated;


    public PostingSchool(int postingID, int SchoolID)
    {
        setPostingID(postingID);
        setSchoolID(SchoolID);
        setLastUpdatedBy();
        setLastUpdated();

    }
    public int getPostingID()
    {
        return this.postingID;
    }
    public void setPostingID(int postingID)
    {
        this.postingID = postingID;
    }
    public int getSchoolID()
    {
        return this.SchoolID;
    }
    public void setSchoolID(int interestID)
    {
        this.SchoolID = interestID;
    }

    public void setLastUpdated()
    {
        this.lastUpdated = DateTime.Now.ToString();
    }

    public void setLastUpdatedBy()
    {
        this.lastUpdatedBy = "CIS 484 Team";
    }

    public String getLastUpdated()
    {
        return this.lastUpdated;
    }
    public String getLastUpdatedBy()
    {
        return this.lastUpdatedBy;
    }
}
