using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for School_Postings
/// </summary>
public class School_Postings
{
    private School school;
    private Posting post;
    private String lastUpdatedBy;
    private String lastUpdated;


    public School_Postings(School school, Posting post)
    {

        setSchool(school);
        setPost(post);
        setLastUpdatedBy();
        setLastUpdated();
    }

    public void setSchool(School school)
    {
        this.school = school;
    }

    public void setPost(Posting post)
    {
        this.post = post;
    }

    public School getSchool()
    {
        return this.school;
    }

    public Posting getPosting()
    {
        return this.post;
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