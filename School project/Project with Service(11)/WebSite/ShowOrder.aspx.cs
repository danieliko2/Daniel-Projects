using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ShowOrder : System.Web.UI.Page
{
    localhostService.Service srvs = new localhostService.Service();
    protected void Page_Load(object sender, EventArgs e)
    {

        OrderService srvs = new OrderService();
        GridViewOrder.DataSource = srvs.GetProductsInOrderByOrderID(Convert.ToInt32(Session["OrderID"]));
        GridViewOrder.DataBind();
    }
}