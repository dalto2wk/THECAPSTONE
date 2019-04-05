using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class School {
	private int schoolID;
	private String name;
	private String streetNumber;
	private String streetAddress;
	private String city;
	private String state;
	private String country;
	private String zip;
	
	
	
	public School(String name, String streetNumber, String streetAddress, String city, String state, String country,
			String zip) {
		
		setName(name);
		setStreetNumber(streetNumber);
		setStreetAddress(streetAddress);
		setCity(city);
		setState(state);
		setCountry(country);
		setZip(zip);
	}

    public School(String name, int id)
    {
        setSchoolID(id);
        setName(name);
    }

    public School(String name)
    {
        setName(name);
    }
	public int getSchoolID() {
		return this.schoolID;
	}
	public void setSchoolID(int id) {
        this.schoolID = id;
	}
	public String getName() {
		return this.name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getStreetNumber() {
		return this.streetNumber;
	}
	public void setStreetNumber(String streetNumber) {
		this.streetNumber = streetNumber;
	}
	public String getStreetAddress() {
		return this.streetAddress;
	}
	public void setStreetAddress(String streetAddress) {
		this.streetAddress = streetAddress;
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
	
	
}
