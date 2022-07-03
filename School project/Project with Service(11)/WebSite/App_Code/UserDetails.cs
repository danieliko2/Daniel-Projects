using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for UserDetails
/// </summary>
public class UserDetails
{
    int _userID, _zipCode;
    string _userName, _passWord, _email, _firstName, _lastName, _phoneNumber, _city, _address;

	public UserDetails()
	{
        
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
    public string UserName
    {
        get
        {
            return _userName;
        }
        set
        {
            this._userName = value;
        }

    }

    public string Password
    {
        get
        {
            return _passWord;
        }
        set
        {
            this._passWord = value;
        }

    }

    public string Email
    {
        get
        {
            return _email;
        }
        set
        {
            this._email = value;
        }

    }
    public string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            this._firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return _lastName;
        }
        set
        {
            this._lastName = value;
        }
    }

    public string PhoneNumber
    {
        get
        {
            return _phoneNumber;
        }
        set
        {
            this._phoneNumber = value;
        }
    }
    public string City
    {
        get
        {
            return _city;
        }
        set
        {
            this._city = value;
        }
    }
    public string Address
    {
        get
        {
            return _address;
        }
        set
        {
            this._address = value;
        }
    }

    public int ZipCode
    {
        get
        {
            return _zipCode;
        }
        set
        {
            this._zipCode = value;
        }

    }
}