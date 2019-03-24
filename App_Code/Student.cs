using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
public class Student {
	private int StudentID;
	private String firstName;
	private String lastName;
	private String middleName;
	private String houseNbr;
	private String street;
	private String city;
	private String state;
	private String country;
	private String zip;
	private String dateOfBirth;
	private String academicYear;
	private String email;
	private String phone;
	private School schoolID;
    private double GPA;
	
	
	
	
	public Student(String firstName, String lastName, String middleName, String houseNbr, String street, String city,
			String state, String country, String zip, String dateOfBirth, String academicYear, String email,
			String phone, School schoolID, double GPA) {
		setStudentID();
		setFirstName(firstName);
		setLastName(lastName);
		setMiddleName(middleName);
		setHouseNbr(houseNbr);
		setStreet(street);
		setCity(city);
		setState(state);
		setCountry(country);
		setZip(zip);
		setDateOfBirth(dateOfBirth);
		setAcademicYear(academicYear);
		setEmail(email);
		setPhone(phone);
		setSchoolID(schoolID);
        setGPA(GPA);
	}

    public void setGPA(double GPA)
    {
        this.GPA = GPA;
    }
    public double getGPA()
    {
        return this.GPA;
    }

    public int getStudentID() {
		return this.StudentID;
	}
	public void setStudentID() {
		//implement to db
	}
	public String getFirstName() {
		return this.firstName;
	}
	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}
	public String getLastName() {
		return this.lastName;
	}
	public void setLastName(String lastName) {
		this.lastName = lastName;
	}
	public String getMiddleName() {
		return this.middleName;
	}
	public void setMiddleName(String middleName) {
		this.middleName = middleName;
	}
	public String getHouseNbr() {
		return this.houseNbr;
	}
	public void setHouseNbr(String houseNbr) {
		this.houseNbr = houseNbr;
	}
	public String getStreet() {
		return this.street;
	}
	public void setStreet(String street) {
		this.street = street;
	}
	public String getCity() {
		return this.city;
	}
	public void setCity(String city) {
		this.city = city;
	}
	public String getState() {
		return this.state;
	}
	public void setState(String state) {
		this.state = state;
	}
	public String getCountry() {
		return this.country;
	}
	public void setCountry(String country) {
		this.country = country;
	}
	public String getZip() {
		return this.zip;
	}
	public void setZip(String zip) {
		this.zip = zip;
	}
	public String getDateOfBirth() {
		return this.dateOfBirth;
	}
	public void setDateOfBirth(String dateOfBirth) {
		this.dateOfBirth = dateOfBirth;
	}
	public String getAcademicYear() {
		return this.academicYear;
	}
	public void setAcademicYear(String academicYear) {
		this.academicYear = academicYear;
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
	public School getSchoolID() {
		return this.schoolID;
	}
	public void setSchoolID(School schoolID) {
		this.schoolID = schoolID;
	}
	
	
	
}
