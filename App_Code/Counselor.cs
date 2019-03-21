using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public class Counselor {
	private int counselorID;
	private String name;
	private String phone;
	private School schoolID;
	
    public Counselor(String name, String phone, School schoolID) {
		
		setCounselorID();
		setName(name);
		setPhone(phone);
		setSchoolID(schoolID);
	}
	
	public int getCounselorID() {
		return this.counselorID;
	}
	public String getName() {
		return this.name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getPhone() {
		return this.phone;
	}
	public void setPhone(String phone) {
		this.phone = phone;
	}
	public School getSchoolID() {
		return this.schoolID;
	}
	public void setSchoolID(School schoolID) {
		this.schoolID = schoolID;
	}
	public void setCounselorID() {
		//add db stuff
	}
	
	
	
	
}
