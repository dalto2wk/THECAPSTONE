using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class PostingInterest {
	private int postingID;
	private int interestID;
    private string lastUpdatedBy;
    private string lastUpdated;


    public PostingInterest(int postingID, int interestID) {
		setPostingID(postingID);
		setInterestID(interestID);
        setLastUpdatedBy();
        setLastUpdated();

    }
	public int getPostingID() {
		return this.postingID;
	}
	public void setPostingID(int postingID) {
		this.postingID = postingID;
	}
	public int getInterestID() {
		return this.interestID;
	}
	public void setInterestID(int interestID) {
		this.interestID = interestID;
	}

    public void setLastUpdated()
    {
        this.lastUpdated = DateTime.Now.ToString();
    }

    public void setLastUpdatedBy()
    {
        this.lastUpdatedBy = "CIS 484 Team";
    }

    public String getLastUpdated()
    {
        return this.lastUpdated;
    }
    public String getLastUpdatedBy()
    {
        return this.lastUpdatedBy;
    }
}
