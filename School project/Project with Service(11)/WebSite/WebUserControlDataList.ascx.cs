using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControlDataList : System.Web.UI.UserControl
{
    protected ShoppingBagNew mShoppingBag=new ShoppingBagNew();
    bool buttoninfo, addtocart;
    protected void Page_Load(object sender, EventArgs e)
    {
        //string un = (string)Session["UserName"];
        //if (!Page.IsPostBack && Session["UserName"]!=null && un=="daniel")
        //{
            
        //    LinkButton l = (LinkButton)DataListProductSelected.FindControl("LinkButtonEdit");
        //    l.Visible = false;
        //}
        string str = (string)(Session["ProductsKindID"].ToString());
        localhostService.Service srvs = new localhostService.Service();
        if(str=="all")
        {
            DataListProductSelected.DataSourceID = "ObjectDataSourceAllProducts";

        }
        if (Session["myShoppingBag"] == null)
        {
            mShoppingBag = new ShoppingBagNew();
            ButtonConfirm.Visible = false;
        }
        else
        {
            mShoppingBag = (ShoppingBagNew)Session["myShoppingBag"];
            ButtonConfirm.Visible = true;
        }
    }
    protected void DataLstProductSelected_ItemCommand(object source, DataListCommandEventArgs e)
    {
        Button b = (Button)(DataListProductSelected.FindControl("ButtonProduct"));
        if (buttoninfo)
        {
            Session["ProductID"] = Convert.ToInt32(DataListProductSelected.DataKeys[e.Item.ItemIndex]);
            Response.Redirect("SelectedProduct.aspx");
        }
        if (addtocart)
        {

            int index = e.Item.ItemIndex;
            //מוצא את השורה שנלחצה על ידי המשתמש
            DataListItem Item = DataListProductSelected.Items[index];
            int ProductID = int.Parse(((Label)e.Item.FindControl("LabelProductID")).Text);
            localhostService.Service srvs = new localhostService.Service();
            localhostService.ProductDetails product = srvs.GetProductByID(ProductID);
            ProductDetails newproduct = new ProductDetails();

            newproduct.Description = product.Description;
            newproduct.ImageURL = product.ImageURL;
            newproduct.KindID = product.KindID;
            newproduct.ManufacturerID = product.ManufacturerID;
            newproduct.Price = product.Price;
            newproduct.ProductID = product.ProductID;
            newproduct.ProductName = product.ProductName;
            newproduct.UnitsInStock = product.UnitsInStock;
            newproduct.Rating = product.Rating;
            newproduct.UnitsInOrder = product.UnitsInOrder;

            ProductInBag newp = new ProductInBag(newproduct);
            mShoppingBag.AddProduct(newp);
            ButtonConfirm.Visible = true;
            Page.Session["myShoppingBag"] = mShoppingBag;
            GridView gv = (GridView)WebUserControlShoppingBag1.FindControl("GridViewShoppingBag");
            gv.DataSource = mShoppingBag.ConvertToViewDataTable();
            gv.DataBind();
        }
    }
    protected void populate_GridViewShoppingBag()
    {

    }
    protected void ButtonProduct_Click(object sender, EventArgs e)
    {
        buttoninfo=true;
    }
    protected void ObjectDataSourceProductsSelected_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
    protected void ImageButtonAddToCart_Click(object sender, ImageClickEventArgs e)
    {
        addtocart = true;
    }
    protected void ButtonConfirm_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderPage.aspx");
    }
}