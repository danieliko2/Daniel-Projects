using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    protected int _productID;
    protected string _productName;  

	public Product()
	{

        this._productID = -1;
        this._productName = null;
	}
     public Product(Product p)
    {
        this._productID = p._productID;
        this._productName = p._productName;
    }
    public Product(int inProductID, string inProductName)
    {
        this._productID = inProductID;
        this._productName = inProductName;
    }
    public Product(int inProductID)
    {
        this._productID = inProductID;
    }
    public int ProductID
    {
        get
        {
            return _productID;
        }
        set
        {
            _productID = value;
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
            _productName = value;
        }
    }
}