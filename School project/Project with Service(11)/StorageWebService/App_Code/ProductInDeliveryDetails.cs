using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductInDeliveryDetails
/// </summary>
public class ProductInDeliveryDetails
{
    int _deliveryID, _productID, _quantity;
    decimal _totalPrice;
	public ProductInDeliveryDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int DeliveryID
    {
        get
        {
            return _deliveryID;
        }
        set
        {
            this._deliveryID = value;
        }
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
    public int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            this._quantity = value;
        }
    }
    public decimal TotalPrice
    {
        get
        {
            return _totalPrice;
        }
        set
        {
            this._totalPrice = value;
        }
    }
}