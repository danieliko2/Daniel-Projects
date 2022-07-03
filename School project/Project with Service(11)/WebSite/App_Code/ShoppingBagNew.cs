using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;

/// <summary>
/// Summary description for ShoppingBagNew
/// </summary>
public class ShoppingBagNew
{
    ArrayList _Products;
    double sum = 0;

    public ShoppingBagNew()
    {
        _Products = new ArrayList();

    }



    public ArrayList Products
    {
        get
        {
            return _Products;
        }
    }

    public int Length
    {
        get
        {
            return _Products.Count;
        }
    }



    public double GetFinalPrice()
    {
        //מחזיר מחיר של כל המוצרים בסל
        sum = 0;
        for (int i = 0; i < _Products.Count; i++)
        {
            ProductInBag Product = (ProductInBag)_Products[i];

            sum = sum + Product.TotalPrice;
        }
        return sum;


    }

    private int SearchProduct(int ProductID)
    {
        //מחפש מוצר בסל
        for (int i = 0; i < _Products.Count; i++)
        {
            if (((ProductInBag)_Products[i]).Product.ProductID == ProductID) return i;
        }
        return -1;
    }


    public void AddProduct(ProductInBag inProduct)
    {
        //מוסיף מוצר לסל .אם קיים כבר בסל מעלה את הכמות ב1
        int i = SearchProduct(inProduct.Product.ProductID);
        if (i == -1)
        {
            _Products.Add(inProduct);
        }
        else
        {
            ProductInBag Product = (ProductInBag)_Products[i];
            Product.AddQuantity();
        }
    }
    public void DeleteProduct(ProductInBag inProduct)
    {
        //מבטל מוצר מהסל

        _Products.RemoveAt(SearchProduct(inProduct.Product.ProductID));
    }


    public void UpdateProduct(ProductInBag inProduct)
    {
        //מעדכן כמות של מוצר בסל
        ProductInBag Product = (ProductInBag)_Products[SearchProduct(inProduct.Product.ProductID)];
        Product.TotalPrice = inProduct.TotalPrice;
        Product.Quantity = inProduct.Quantity;


    }
    public DataTable ConvertToViewDataTable()
    {
        DataTable dtShoppingBag = new DataTable();
        DataColumn[] dtColumns = new DataColumn[] { new DataColumn("ProductID"), new DataColumn("ProductName"), new DataColumn("Price"), new DataColumn("Quantity"), new DataColumn("TotalPrice") };
        dtShoppingBag.Columns.AddRange(dtColumns);
        for (int i = 0; i < this._Products.Count; i++)
        {
            DataRow currRow = dtShoppingBag.NewRow();
            currRow["ProductID"] = ((ProductInBag)_Products[i]).Product.ProductID;
            currRow["ProductName"] = ((ProductInBag)_Products[i]).Product.ProductName;
            currRow["Price"] = ((ProductInBag)_Products[i]).Product.Price;
            currRow["Quantity"] = ((ProductInBag)_Products[i]).Quantity;
            currRow["TotalPrice"] = ((ProductInBag)_Products[i]).TotalPrice;
            dtShoppingBag.Rows.Add(currRow);
        }
        return dtShoppingBag;
    }
    public DataTable ConvertToViewDataTable2(int orderid)
    {
        DataTable dtShoppingBag = new DataTable();
        DataColumn[] dtColumns = new DataColumn[] { new DataColumn("OrderID"), new DataColumn("ProductID"), new DataColumn("Price"), new DataColumn("Quantity"), new DataColumn("TotalPrice") };
        dtShoppingBag.Columns.AddRange(dtColumns);
        for (int i = 0; i < this._Products.Count; i++)
        {
            DataRow currRow = dtShoppingBag.NewRow();
            currRow["OrderID"] = orderid;
            currRow["ProductID"] = ((ProductInBag)_Products[i]).Product.ProductID;
            currRow["Price"] = ((ProductInBag)_Products[i]).Product.Price;
            currRow["Quantity"] = ((ProductInBag)_Products[i]).Quantity;
            currRow["TotalPrice"] = ((ProductInBag)_Products[i]).TotalPrice;
            dtShoppingBag.Rows.Add(currRow);
        }
        return dtShoppingBag;

    }
}