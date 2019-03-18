using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Interests {
	private int interestID;
	private String name;
	
	
	
	public Interests(String name) {
		setInterestID();
		setName(name);
	}
	public int getInterestID() {
		return this.interestID;
	}
	public void setInterestID() {
		//implement to db
	}
	public String getName() {
		return this.name;
	}
	public void setName(String name) {
		this.name = name;
	}
	
	
}
