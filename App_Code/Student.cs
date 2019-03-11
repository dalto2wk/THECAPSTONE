using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/* Created By: Kyle Mangine 
 * This work complies with the JMU honor code. 
 * 
*/
////// This class contains the data fields, constructors, array, as well as getter and setter
/// methods for the StudentActivity object.
public class Student
{
    private String firstName;
    private String middleName;
    private String lastName;
    private DateTime dateOfBirth;
    private String academicYear;
    private String houseNumber;
    private String street;
    private String cityCounty;
    private String homeState;
    private String country;
    private int zip;
    private String lastUpdatedBy = "Kyle Mangine";
    private DateTime lastUpdated = DateTime.Today;

    private int schoolID;
    public static int StudentID;
    


    public Student(String firstName, String middleName, String lastName,
        String academicYear, String houseNumber, String street, String cityCounty, String homeState,
        String country, int zip, DateTime dateOfBirth, int schoolID, String lastUpdatedBy, DateTime lastUpdated)
    {

        setFirstName(firstName);
        setMiddleName(middleName);
        setLastName(lastName);
        setAcademicYear(academicYear);
        setHouseNumber(houseNumber);
        setStreet(street);
        setCityCounty(cityCounty);
        setHomeState(homeState);
        setCountry(country);
        setZip(zip);
        setDateOfBirth(dateOfBirth);
        setSchoolID(schoolID);
        setLastUpdatedBy(lastUpdatedBy);
        setLastUpdated(lastUpdated);


    }


    public void setFirstName(String firstName)
    { this.firstName = firstName; }

    public String getfirstName()
    { return firstName; }

    public void setMiddleName(String middleNam)
    { middleName = middleNam; }

    public String getMiddleName()
    { return middleName; }

    public void setLastName(String lastName)
    { this.lastName = lastName; }

    public String getLastName()
    { return lastName; }

    public void setAcademicYear(String academicYear)
    { this.academicYear = academicYear; }

    public String getAcademicYear()
    { return academicYear; }

    public void setHouseNumber(String houseNumber)
    { this.houseNumber = houseNumber; }

    public String getHouseNumber()
    { return houseNumber; }

    public void setStreet(String street)
    { this.street = street; }

    public String getStreet()
    { return street; }

    public void setCityCounty(String cityCounty)
    { this.cityCounty = cityCounty; }

    public String getCityCounty()
    { return cityCounty; }

    public void setHomeState(String homeState)
    { this.homeState = homeState; }

    public String getHomeState()
    { return homeState; }

    public void setCountry(String country)
    { this.country = country; }

    public String getCountry()
    { return country; }

    public void setZip(int zip)
    { this.zip = zip; }                                                                                                                                                                                                                                                                                                                                                                                                                                                 

    public int getZip()
    { return zip; }

    public void setDateOfBirth(DateTime dateOfBirth)
    { this.dateOfBirth = dateOfBirth; }

    public DateTime getDateOfBirth()
    { return dateOfBirth; }

    public void setSchoolID(int schoolID)
    { this.schoolID = schoolID; }

    public int getSchoolID()
    { return schoolID; }

    public void setLastUpdatedBy(String lastUpdatedBy)
    { this.lastUpdatedBy = lastUpdatedBy; }

    public String getLastUpdatedBy()
    { return lastUpdatedBy; }

    public void setLastUpdated(DateTime lastUpdated)
    { this.lastUpdated = lastUpdated; }

    public DateTime getLastUpdated()
    { return lastUpdated; }

    ///This method fills the studentArray with the most recent student created when 
    ///clicking the insert button


    public String toString()
    {
        return this.getfirstName() + this.getMiddleName() + this.getLastName();
    }

    //This method clears the array

}