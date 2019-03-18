using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class StudentInterest {
	private Student std;
	private Interests interest;
	
	
	
	
	public StudentInterest(Student std, Interests interest) {
		setStd(std);
		setInterest(interest);
	}
	public Student getStd() {
		return this.std;
	}
	public void setStd(Student std) {
		this.std = std;
	}
	public Interests getInterest() {
		return this.interest;
	}
	public void setInterest(Interests interest) {
		this.interest = interest;
	}
	
	
}
