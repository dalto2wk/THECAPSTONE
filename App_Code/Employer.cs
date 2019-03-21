using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Employer
/// </summary>
public class Employer
{
    private int employerID;
    private string companyName;
    private int companySize;
    private string industry;
    private string description;
    private string cpName;
    private string cpUsername;
    private string cpPassword;
    private string email;
    private string phone;
    private string lastUpdatedBy;
    private string lastUpdated;


    public Employer(string name, int size, string industry, string description, string cpName, string cpUsername, string cpPWD, string email, string phone, int id)
    {
        setEmpID(id);
        setCompanyName(name);
        setCompanySize(size);
        setIndustry(industry);
        setDescription(description);
        setCpName(cpName);
        setCpUsername(cpUsername);
        setCpPassword(cpPWD);
        setEmail(email);
        setPhone(phone);
        setLastUpdatedBy();
        setLastUpdated();


    }

    public  void setLastUpdated()
    {
        this.lastUpdated = DateTime.Now.ToString();
    }

    public  void setLastUpdatedBy()
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

    public void setPhone(string phone)
    {
        this.phone = phone;
    }

    public void setCpPassword(string pwd)
    {
        this.cpPassword = pwd;
    }

    public void setCpName(string name)
    {
        this.cpName = name;
    }

    public void setEmail(string email)
    {
        this.email = email;
    }

    public void setCpUsername(string username)
    {
        this.cpUsername = username;
    }

    public void setDescription(string description)
    {
        this.description = description;
    }

    public void setIndustry(string industry)
    {
        this.industry = industry;
    }

    public void setCompanySize(int size)
    {
        this.companySize = size;
    }

    public void setCompanyName(string name)
    {
        this.companyName = name;
    }

    public int getEmpID()
    {
        return this.employerID;
        //any foreign key class to public int getEmpID(employer emp)

    }
    public void setEmpID(int id)
    {
        //make helper method to get the highestID and then add 1
        this.employerID = id;
    }
}