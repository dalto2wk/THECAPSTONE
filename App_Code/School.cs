using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This Program was created by Kyle Mangine and complies with the JMU Honor Code.
/// </summary>
public class School
{
    private String schoolName;
    private String schoolNickname;
    private String schoolAddress;
    private String lastUpdatedBy = "Kyle Mangine";
    private DateTime lastUpdated = DateTime.Today;

    public School(String schoolName, String schoolNickname, String schoolAddress, String lastUpdatedby, DateTime lastUpdated)
    {

        setSchoolName(schoolName);
        setSchoolNickname(schoolNickname);
        setSchoolAddress(schoolAddress);
        setLastUpdatedBy(lastUpdatedBy);
        setLastUpdated(lastUpdated);
    }

    public void setSchoolName(String schoolName)
    { this.schoolName = schoolName; }

    public String getSchoolName()
    { return schoolName; }

    public void setSchoolNickname(String schoolNickname)
    { this.schoolNickname = schoolNickname; }

    public String getSchoolNickname()
    { return schoolNickname; }

    public void setSchoolAddress(String schoolAddress)
    { this.schoolAddress = schoolAddress; }

    public String getSchoolAddress()
    { return schoolAddress; }

    public void setLastUpdatedBy(String lastUpdatedBy)
    { this.lastUpdatedBy = lastUpdatedBy; }

    public String getLastUpdatedBy()
    { return lastUpdatedBy; }

    public void setLastUpdated(DateTime lastUpdated)
    { this.lastUpdated = lastUpdated; }

    public DateTime getLastUpdated()
    { return lastUpdated; }
}