using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Parent {
	private int parentID;
	private String name;
	private String email;
	private String phone;
	private Student studentID;
	
	
	
	public Parent(String name, String email, String phone, Student studentID) {
		setParentID();
		setName(name);
		setEmail(email);
		setPhone(phone);
		setStudentID(studentID);
		
	}
	public String getName() {
		return this.name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getEmail() {
		return this.email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getPhone() {
		return this.phone;
	}
	public void setPhone(String phone) {
		this.phone = phone;
	}
	public Student getStudentID() {
		return this.studentID;
	}
	public void setStudentID(Student studentID) {
		this.studentID = studentID;
	}
	public int getParentID() {
		return this.parentID;
	}
	public void setParentID() {
		//match id in db
	}
	
	
}
