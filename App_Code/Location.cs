using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Location
/// </summary>
public class Location
{
    private int LocationID;
    private String State;
    private String CityCounty;

    public Location(String name, int id)
    {
        setLocationID(id);
        setName(name);
    }

    public void setName(string name)
    {
        this.State = name;
    }

    public String getName()
    {
        return this.State;
    }

    public void setLocationID(int id)
    {
        this.LocationID = id;
    }

    public int getLocationID()
    {
        return this.LocationID;
    }
}