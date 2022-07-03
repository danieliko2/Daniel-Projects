using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class SelectedProduct : System.Web.UI.Page
{
    localhostService.Service srvs = new localhostService.Service();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["ProductID"] != null)
        {

            //ProductService productservice = new ProductService();
            localhostService.ProductDetails product = new localhostService.ProductDetails();
            int productid = int.Parse(Session["ProductID"].ToString());
            product = srvs.GetProductByID(productid);
            //product.ImageURL = srvs.GetProductByID(productid).ImageURL;
            //product.KindID = srvs.GetProductByID(productid).KindID;
            //product.ManufacturerID = srvs.GetProductByID(productid).ManufacturerID;
            //product.Price = srvs.GetProductByID(productid).Price;
            //product.ProductID = srvs.GetProductByID(productid).ProductID;
            //product.ProductName = srvs.GetProductByID(productid).ProductName;
            //product.UnitsInStock = srvs.GetProductByID(productid).UnitsInStock;
            //product.Rating = srvs.GetProductByID(productid).Rating;
            //product.UnitsInOrder = srvs.GetProductByID(productid).UnitsInOrder;
            //product.Description = srvs.GetProductByID(productid).Description;


            ImageButtonProduct.ImageUrl = product.ImageURL;
            LabelProductName.Text = product.ProductName.ToString();
            LabelPrice.Text = product.Price.ToString();
            if (Session["UserName"].ToString() == "daniel")
            {
                ButtonEditProduct.Visible = true;
                ButtonDeleteProduct.Visible = true;
            }
        }
        else Response.Redirect("Products.aspx");
    }
    protected void ImageButtonProduct_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["imgbtnsize"] == null)
        {
            Session["imgbtnsize"] = 1;
            ImageButtonProduct.Height = 400;
            ImageButtonProduct.Width = 400;

        }
        else
        {
            Session["imgbtnsize"] = null;
            ImageButtonProduct.Height = 150;
            ImageButtonProduct.Width = 150;
        }
    }
    protected void ButtonEditProduct_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditProduct.aspx");
    }
    protected void ButtonDeleteProduct_Click(object sender, EventArgs e)
    {
        srvs.DeleteProduct(int.Parse(Session["ProductID"].ToString()));
        Response.Redirect("DeletingDone.aspx");
    }
}
