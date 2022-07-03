using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for ProductDetails
/// </summary>
public class ProductDetails
{
    int _productID, _kindID, _manufacturerID, _unitsInStock, _unitsInOrder, _rating;
    string _productName, _description, _imageURL;
    decimal _price;
	public ProductDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ProductID
    {
        get
        {
            return _productID;
        }
        set
        {
            this._productID = value;
        }

    }
    public int KindID
    {
        get
        {
            return _kindID;
        }
        set
        {
            this._kindID = value;
        }

    }
    public int ManufacturerID
    {
        get
        {
            return _manufacturerID;
        }
        set
        {
            this._manufacturerID = value;
        }

    }
    public int UnitsInStock
    {
        get
        {
            return _unitsInStock;
        }
        set
        {
            this._unitsInStock = value;
        }

    }
    public int UnitsInOrder
    {
        get
        {
            return _unitsInOrder;
        }
        set
        {
            this._unitsInOrder = value;
        }

    }
    public int Rating
    {
        get
        {
            return _rating;
        }
        set
        {
            this._rating = value;
        }

    }
    public string ProductName
    {
        get
        {
            return _productName;
        }
        set
        {
            this._productName = value;
        }

    }
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            this._description = value;
        }

    }
    public string ImageURL
    {
        get
        {
            return _imageURL;
        }
        set
        {
            this._imageURL = value;
        }

    }
    public decimal Price
    {
        get
        {
            return _price;
        }
        set
        {
            this._price = value;
        }

    }
}
