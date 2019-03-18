using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public class Application {
	private int applicationID;
	private String jobTitle;
	private String companyName;
	private Posting postID;
	private Student studentID;
	private Counselor counselorID;
	
	
	
	public Application(String jobTitle, String companyName, Posting postID, Student studentID, Counselor counselorID) {
		setApplicationID();
		setJobTitle(jobTitle);
		setCompanyName(companyName);
		setPostID(postID);
		setStudentID(studentID);
		setCounselorID(counselorID);
	}
	public int getApplicationID() {
		return this.applicationID;
	}
	public void setApplicationID() {
		//implement with db id
	}
	public String getJobTitle() {
		return this.jobTitle;
	}
	public void setJobTitle(String jobTitle) {
		this.jobTitle = jobTitle;
	}
	public String getCompanyName() {
		return this.companyName;
	}
	public void setCompanyName(String companyName) {
		this.companyName = companyName;
	}
	public Posting getPostID() {
		return this.postID;
	}
	public void setPostID(Posting postID) {
		this.postID = postID;
	}
	public Student getStudentID() {
		return this.studentID;
	}
	public void setStudentID(Student studentID) {
		this.studentID = studentID;
	}
	public Counselor getCounselorID() {
		return this.counselorID;
	}
	public void setCounselorID(Counselor counselorID) {
		this.counselorID = counselorID;
	}
	
	
}
