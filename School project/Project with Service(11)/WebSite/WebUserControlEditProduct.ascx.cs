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

public partial class WebUserControlEditProduct : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack )
      {
          Show_Product();
      }
    }
  protected void Show_Product()
    {

        localhostService.Service srvs = new localhostService.Service();
        localhostService.ProductDetails product = new localhostService.ProductDetails();
        product = srvs.GetProductByID(int.Parse(Session["ProductID"].ToString()));

        TextBoxProductName.Text = product.ProductName;
        DropDownListKind.SelectedIndex = product.KindID;
        DropDownListManufacturer.SelectedIndex = product.ManufacturerID;
        TextBoxPrice.Text = product.Price.ToString();
        TextBoxUnits.Text = product.UnitsInStock.ToString();
        TextBoxDescription.Text = product.Description;
        TextBoxImage.Text = product.ImageURL;
        TextBoxRating.Text = product.Rating.ToString();

    }
    protected void ButtonConfirm_Click(object sender, EventArgs e)
    {
        localhostService.Service srvs = new localhostService.Service();
        localhostService.ProductDetails product = new localhostService.ProductDetails();
        product.ProductName = TextBoxProductName.Text;
        product.KindID = int.Parse(DropDownListKind.SelectedValue);
        product.ManufacturerID = int.Parse(DropDownListManufacturer.SelectedValue);
        product.Price = int.Parse(TextBoxPrice.Text);
        product.UnitsInStock = int.Parse(TextBoxUnits.Text);
        product.Description = TextBoxDescription.Text;
        product.ImageURL = TextBoxImage.Text;
        product.Rating = int.Parse(TextBoxRating.Text);
        product.ProductID = int.Parse(Session["ProductID"].ToString());
        product.UnitsInOrder = 0;
        srvs.UpdateProduct(product);
        LabelMessage.Text = "מוצר עודכן!";
        ButtonConfirm.Enabled = false;
    }
}
