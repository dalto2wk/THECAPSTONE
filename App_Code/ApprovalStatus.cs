using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ApprovalStatus
/// </summary>
public class ApprovalStatus
{
    private int employerID;
    private int counselorID;
    private char approvalStatus;
    private String lastUpdatedBy;
    private String lastUpdated;

    public ApprovalStatus(int employerID, int counselorID, char approvalStatus)
    {
        setApprovalStatus(approvalStatus);
        setCounselorID(counselorID);
        setEmpID(employerID);
        setLastUpdated();
        setLastUpdatedBy();
    }

    public int getEmpID()
    {
        return this.employerID;

    }
    public void setEmpID(int id)
    {
        this.employerID = id;
    }

    public int getCounselorID()
    {
        return this.counselorID;
    }
    public void setCounselorID(int id)
    {
        this.counselorID = id;
    }

    public char getApprovalStatus()
    {
        return this.approvalStatus;
    }
    public void setApprovalStatus(char status)
    {
        this.approvalStatus = status;
    }

    public String getLastUpdatedBy()
    {
        return this.lastUpdatedBy;
    }
    public void setLastUpdatedBy()
    {
        this.lastUpdatedBy = "484 Team";
    }

    public String getLastUpdated()
    {
        return this.lastUpdated;
    }

    public void setLastUpdated()
    {
        this.lastUpdated = DateTime.Today.ToString("yyyy-MM-dd");
    }


}