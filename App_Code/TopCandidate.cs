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
    int studentInterestID;
    double finalValue;

    public static ArrayList studentInterest = new ArrayList();

  
public TopCandidate(int studentID, String firstName, String lastName, double GPA, int studentInterestID, double finalValue)
    {
        setStudentID(studentID);
        setFirstName(firstName);
        setLastName(lastName);
        setGPA(GPA);
        setStudentInterestID(studentInterestID);
        setFinalValue(finalValue);
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

    public void setStudentInterestID(int studentInterestID)
    {
        this.studentInterestID = studentInterestID;
    }
    public int getStudentInterestID()
    {
        return this.studentInterestID;
    }

    public void setFinalValue(double finalValue)
    {
        this.finalValue = finalValue;
    }
    public double getFinalValue()
    {
        return this.finalValue;
    }


    
   
}