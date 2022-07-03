using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ProductDetails product = new ProductDetails();
        ProductService srvs = new ProductService();
        product = srvs.GetProductByID(38);
        product.Description = "asd";
        product.ImageURL = "asdf";
        product.KindID = 2;
        product.ManufacturerID = 3;
        product.Price = 900;
        product.ProductName = "sad";
        product.Rating = 1;
        product.UnitsInOrder = 1;
        product.UnitsInStock = 2;
        srvs.UpdateProduct(product);
    }
}
