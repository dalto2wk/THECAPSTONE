using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TopCandidate
/// </summary>
public class TopCandidate
{
    int studentID;
    String firstName;
    String lastName;
    double GPA;
    double finalValue;

    ArrayList studentInterest = new ArrayList();

  
public TopCandidate(int studentID, String firstName, String lastName, double GPA)
    {
        setStudentID(studentID);
        setFirstName(firstName);
        setLastName(lastName);
        setGPA(GPA);
    }

    public void setStudentID(int studentID)
    {
        this.studentID = studentID;
    }
    public int getsStudentID()
    {
        return this.studentID;
    }

    public String getFirstName()
    {
        return this.firstName;
    }
    public void setFirstName(String firstName)
    {
        this.firstName = firstName;
    }
    public String getLastName()
    {
        return this.lastName;
    }
    public void setLastName(String lastName)
    {
        this.lastName = lastName;
    }

    public void setGPA(double GPA)
    {
        this.GPA = GPA;
    }
    public double getGPA()
    {
        return this.GPA;
    }
}