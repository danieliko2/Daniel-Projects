using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for OrderDetails
/// </summary>
public class OrderDetails
{
    private int _orderID, _userID, _deliveryID;
    private DateTime _orderDate;
    private decimal _paymentSum;
    private string _orderAddress, _orderStatus;
    private ShoppingBagNew _shoppingbag;
	public OrderDetails()
	{

	}
    public int OrderID
    {
        get
        {
            return this._orderID;
        }
        set
        {
            _orderID = value;
        }
    }
    public int UserID
    {
        get
        {
            return this._userID;
        }
        set
        {
            _userID = value;
        }
    }
    public int DeliveryID
    {
        get
        {
            return this._deliveryID;
        }
        set
        {
            _deliveryID = value;
        }
    }
    public DateTime OrderDate
    {
        get
        {
            return this._orderDate;
        }
        set
        {
            _orderDate = value;
        }
    }
    public decimal PaymentSum
    {
        get
        {
            return this._paymentSum;
        }
        set
        {
            _paymentSum = value;
        }
    }
    public string OrderAddress
    {
        get
        {
            return this._orderAddress;
        }
        set
        {
            _orderAddress = value;
        }
    }
    public string OrderStatus
    {
        get
        {
            return this._orderStatus;
        }
        set
        {
            _orderStatus = value;
        }
    }
    public ShoppingBagNew ShoppingBag
    {
        get
        {
            return this._shoppingbag;
        }
        set
        {
            _shoppingbag = value;
        }
    }
}