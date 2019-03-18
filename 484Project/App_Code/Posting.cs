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
	private Employer empID;
	
	
	
	public Posting(String postingTitle, String description, String interests, String jobRequirements,
			String contactInfo, Employer empID) {
		setPostingTitle(postingTitle);
		setDescription(description);
		setInterests(interests);
		setJobRequirements(jobRequirements);
		setContactInfo(contactInfo);
		setEmpID(empID);
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
	public Employer getEmpID() {
		return this.empID;
	}
	public void setEmpID(Employer empID) {
		this.empID = empID;
	}
	
	
}
