using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonConfirm_Click(object sender, EventArgs e)
    {
        localhostService.Service srvs = new localhostService.Service();
        localhostService.ProductDetails product = new localhostService.ProductDetails();

        product.Description = TextBoxDescription.Text;
        product.ImageURL = TextBoxImage.Text;
        product.KindID = int.Parse(DropDownListKind.SelectedValue.ToString());
        product.ManufacturerID = int.Parse(DropDownListManufacturer.SelectedValue.ToString());
        product.Price =Convert.ToDecimal(TextBoxPrice.Text);
        product.ProductName = TextBoxProductName.Text;
        product.Rating = int.Parse(TextBoxRating.Text);
        product.UnitsInStock = int.Parse(TextBoxUnits.Text);
        srvs.AddProduct(product);
        ButtonConfirm.Enabled = false;
        LabelMessage.Text = "נוסף המוצר";
    }
}