using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeliveryDetails
/// </summary>
public class DeliveryDetails
{
    private DateTime _date;
    private int _userID;
	public DeliveryDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DateTime Date
    {
        get
        {
            return _date;
        }
        set
        {
            this._date = value;
        }

    }
    public int UserID
    {
        get
        {
            return _userID;
        }
        set
        {
            this._userID = value;
        }

    }
}