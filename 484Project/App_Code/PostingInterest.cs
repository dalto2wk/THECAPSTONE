using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class PostingInterest {
	private Posting postingID;
	private Interests interestID;
	
	
	
	public PostingInterest(Posting postingID, Interests interestID) {
		setPostingID(postingID);
		setInterestID(interestID);
		
	}
	public Posting getPostingID() {
		return this.postingID;
	}
	public void setPostingID(Posting postingID) {
		this.postingID = postingID;
	}
	public Interests getInterestID() {
		return this.interestID;
	}
	public void setInterestID(Interests interestID) {
		interestID = interestID;
	}
	
	
}
