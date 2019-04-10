using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class Posting {
	private int postingID;
	private String postingTitle;
	private String description;
	
	private String jobRequirements;
	private String contactInfo;
	private Employer emp;
    //private School schoolName;
    private string lastUpdatedBy;
    private string lastUpdated;
    private string cpEmail;
    private string cpPhone;
    private string postStart;
    private string postEnd;
    private string opportunityStartDate;
    private Stream file; 


    public Posting(String postingTitle, String description, String jobRequirements,
            String contactInfo, Employer empID,  string cpPhone,string cpEmail, string postStart, string postEnd, string opportunityStartDate) {
		setPostingTitle(postingTitle);
        setDescription(description);
		setJobRequirements(jobRequirements);
		setContactInfo(contactInfo);
		setEmp(empID);
       // setSchoolName(schoolName);
        setLastUpdatedBy();
        setLastUpdated();
        setcpPhone(cpPhone);
        setcpEmail(cpEmail);
        setPostStart(postStart);
        setPostEnd(postEnd);
        setOppStart(opportunityStartDate);
        this.file = null;
    }


    public void setfile(Stream file)
    {
        this.file = file;
    }

    public Stream getFile()
    {
        return this.file;
    }
  /*  public void setSchoolName(School schoolName)
    {
        this.schoolName = schoolName;
    } 

    public School getSchoolName()
    {
        return this.schoolName;
    } */

    public string getStartDate()
    {
        return this.postStart;
    }
    public string getPostEndDate()
    {
        return this.postEnd;
    }
    public string getOpportunityStartDate()
    {
        return this.opportunityStartDate;
    }

    public string getCpEmail()
    {
        return this.cpEmail;
    }
    public string getCpPhone()
    {
        return this.cpPhone;
    }

    public void setOppStart(string opportunityStartDate)
    {
        this.opportunityStartDate = opportunityStartDate;
    }

    public void setPostEnd(string postEnd)
    {
        this.postEnd = postEnd;

    }

    public void setPostStart(string postStart)
    {
        this.postStart = postStart;
    }

    public void setcpEmail(string cpEmail)
    {
        this.cpEmail = cpEmail;
    }

    public void setcpPhone(string cpPhone)
    {
        this.cpPhone = cpPhone;
    }

    public int getPostingID() {
		return this.postingID;
	}
	public void setPostingID() {
		//implement to db
	}
	public String getPostingTitle() {
		return this.postingTitle;
	}
	public void setPostingTitle(String postingTitle) {
		this.postingTitle = postingTitle;
	}
	public String getDescription() {
		return this.description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	
	public String getJobRequirements() {
		return this.jobRequirements;
	}
	public void setJobRequirements(String jobRequirements) {
		this.jobRequirements = jobRequirements;
	}
	public String getContactInfo() {
		return this.contactInfo;
	}
	public void setContactInfo(String contactInfo) {
		this.contactInfo = contactInfo;
	}
	public Employer getEmp() {
		return this.emp;
	}
	public void setEmp(Employer emp) {
		this.emp = emp;
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
