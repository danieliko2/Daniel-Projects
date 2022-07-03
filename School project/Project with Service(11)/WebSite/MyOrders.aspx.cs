using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OrderService ordersrvs = new OrderService();
        UserDetails user=new UserDetails();
        UserService usersrvs=new UserService();
        user=usersrvs.GetUserByUserName(Session["UserName"].ToString());
        GridViewOrders.DataSource = ordersrvs.GetOrdersByUserID(user.UserID);
        GridViewOrders.DataBind();
    }
    protected void GridViewOrders_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = GridViewOrders.Rows[index];

        int orderid = Convert.ToInt32(row.Cells[1].Text);
        int userid = Convert.ToInt32(row.Cells[2].Text);
        Session["UserID"] = userid;
        Session["OrderID"] = orderid;
        Label1.Text = orderid.ToString();
        Response.Redirect("ShowOrder.aspx");
    }
}