using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for ProductInBag
/// </summary>
public class ProductInBag : Product
{
    protected ProductDetails _Product;
    protected int _Quantity;  //כמות
    protected double _Totalprice;
    public ProductInBag()
    {
        _Product = new ProductDetails();
        _Quantity = 0;
    }
    public ProductInBag(ProductDetails product)
    {
        _Product = product;
        _Quantity = 1;
        _Totalprice = Convert.ToInt32(product.Price) * _Quantity;

    }
    public ProductDetails Product
    {
        get
        {
            return _Product;
        }
        set
        {
            _Product = value;
        }

    }
    public int Quantity
    {
        get
        {
            return _Quantity;
        }
        set
        {
            _Quantity = value;
        }
    }
    public double TotalPrice
    {
        get
        {
            return _Totalprice;
        }
        set
        {
            _Totalprice = value;
        }
    }
    public void AddQuantity()
    {
        _Quantity++;
        _Totalprice = Convert.ToDouble(_Product.Price) * _Quantity;
    }

}