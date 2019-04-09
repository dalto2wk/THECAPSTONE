using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PostingLocation
/// </summary>
public class PostingLocation
{
    private int postingID;
    private int LocationID;
    private string lastUpdatedBy;
    private string lastUpdated;


    public PostingLocation(int postingID, int LocationID)
    {
        setPostingID(postingID);
        setLocationID(LocationID);
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
    public int getLocationID()
    {
        return this.LocationID;
    }
    public void setLocationID(int LocationID)
    {
        this.LocationID = LocationID;
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