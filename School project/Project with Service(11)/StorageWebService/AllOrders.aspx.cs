using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Approve : System.Web.UI.Page
{
    localhostService.Service srvs = new localhostService.Service();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = srvs.GetNewOrders();
        GridViewOrders.DataSource = ds;
        GridViewOrders.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridViewOrders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = GridViewOrders.Rows[index];

        int orderid =Convert.ToInt32(row.Cells[1].Text);
        int userid = Convert.ToInt32(row.Cells[2].Text);
        Session["UserID"] = userid;
        Session["OrderID"] = orderid;
        Label1.Text = orderid.ToString();
        Response.Redirect("OrderPage.aspx");
    }
}