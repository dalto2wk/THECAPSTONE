using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Posting {
	private int postingID;
	private String postingTitle;
	private String description;
	private String interests;
	private String jobRequirements;
	private String contactInfo;
	private Employer emp;
    private string lastUpdatedBy;
    private string lastUpdated;


    public Posting(String postingTitle, String description, String interests, String jobRequirements,
			String contactInfo, Employer empID) {
		setPostingTitle(postingTitle);
		setDescription(description);
		setInterests(interests);
		setJobRequirements(jobRequirements);
		setContactInfo(contactInfo);
		setEmp(empID);
        setLastUpdatedBy();
        setLastUpdated();
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
	public String getInterests() {
		return this.interests;
	}
	public void setInterests(String interests) {
		this.interests = interests;
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
