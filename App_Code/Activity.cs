using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This Program was created by Kyle Mangine and complies with the JMU Honor Code.
/// </summary>
public class Activity
{

    private String activityDescription;
    private String lastUpdatedBy = "Kyle Mangine";
    private DateTime lastUpdated = DateTime.Today;
    private Char activeInd;

    public Activity(String activityDescription, String lastUpdatedby, DateTime lastUpdated, Char activeInd)
    {
        setActivityDescription(activityDescription);
        setLastUpdatedBy(lastUpdatedBy);
        setLastUpdated(lastUpdated);
        setActiveInd(activeInd);
    }

    public void setActivityDescription(String activityDescription)
    { this.activityDescription = activityDescription; }

    public String getActivityDescription()
    { return activityDescription; }

    public void setLastUpdatedBy(String lastUpdatedBy)
    { this.lastUpdatedBy = lastUpdatedBy; }

    public String getLastUpdatedBy()
    { return lastUpdatedBy; }

    public void setLastUpdated(DateTime lastUpdated)
    { this.lastUpdated = lastUpdated; }

    public DateTime getLastUpdated()
    { return lastUpdated; }

    public void setActiveInd(Char activeInd)
    { this.activeInd = activeInd; }

    public Char getActiveInd()
    { return activeInd; }

}