using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/* Created By: Kyle Mangine 
 * This work complies with the JMU honor code. 
 * 
*/
/// This class contains the data fields, constructors, array, as well as getter and setter
/// methods for the StudentActivity object.
public class StudentActivity
{
    int studentID;
    int activityID;
    private String lastUpdatedBy = "Kyle Mangine";
    private DateTime lastUpdated = DateTime.Today;


    public StudentActivity(String lastUpdatedBy, DateTime lastUpdated)
    {
        setStudentID(studentID);
        setActivityID(activityID);
        setLastUpdatedBy(lastUpdatedBy);
        setLastUpdated(lastUpdated);
    }


    public void setStudentID(int studentID)
    { this.studentID = studentID; }

    public int getStudentID()
    { return studentID; }

    public void setActivityID(int activityID)
    { this.activityID = activityID; }

    public int getActivityID()
    { return activityID; }

    public void setLastUpdatedBy(String lastUpdatedBy)
    { this.lastUpdatedBy = lastUpdatedBy; }

    public String getLastUpdatedBy()
    { return lastUpdatedBy; }

    public void setLastUpdated(DateTime lastUpdated)
    { this.lastUpdated = lastUpdated; }

    public DateTime getLastUpdated()
    { return lastUpdated; }



}