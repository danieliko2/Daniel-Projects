using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AdminDeleteProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        localhostService.Service srvs = new localhostService.Service();
        DataSet ds = new DataSet();
        ds = srvs.GetAllProducts();
        DataTable table = ds.Tables["Products"];
        foreach (DataRow dr in table.Rows)
        {
            DropDownListProducts.Items.Add(new ListItem(dr["ProductName"].ToString(), dr["ProductID"].ToString()));
        }
    }
    protected void DropDownListProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["ProductID"] = DropDownListProducts.SelectedValue.ToString();
        Response.Redirect("EditProduct.aspx");
    }
    protected void ButtonConfirm_Click(object sender, EventArgs e)
    {
        Session["ProductID"] = TextBoxProductID.Text;
        Response.Redirect("EditProduct.aspx");
    }
}