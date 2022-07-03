using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class AdminChooseProduct : System.Web.UI.Page
{
    localhostService.Service srvs = new localhostService.Service();
    protected void Page_Load(object sender, EventArgs e)
    {


        DataSet ds = new DataSet();
        ds = srvs.GetAllProducts();
        DataTable table = ds.Tables["Products"];
        foreach (DataRow dr in table.Rows)
        {
            DropDownListProducts.Items.Add(new ListItem(dr["ProductName"].ToString(), dr["ProductID"].ToString()));
        }
    }
    protected void ButtonConfirm_Click(object sender, EventArgs e)
    {
        Session["ProductID"] = TextBoxProductID.Text;
        srvs.DeleteProduct(int.Parse(Session["ProductID"].ToString()));
        Response.Redirect("DeletingDone.aspx");
    }
    protected void ButtonConfirm2_Click(object sender, EventArgs e)
    {
        Session["ProductID"] = DropDownListProducts.SelectedValue.ToString();
        srvs.DeleteProduct(int.Parse(Session["ProductID"].ToString()));
        Response.Redirect("DeletingDone.aspx");
    }
}