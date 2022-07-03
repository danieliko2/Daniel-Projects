using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderPage : System.Web.UI.Page
{
    bool b = true;
    protected OrderService srvs = new OrderService();
    protected ShoppingBagNew mShoppingBag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null && Session["myShoppingBag"] == null)
        {
            ImgLogin.Visible = false;
            if (Session["myShoppingBag"] == null)
            {
                LabelIsLoggedIn.Text = "אין מוצרים בסל הקניות.";
                foreach (Control c in Panel1.Controls)
                {
                    if (c is Button)
                        ((Button)c).Enabled = false;
                    if (c is Label)
                        ((Label)c).Enabled = false;
                    if (c is TextBox)
                        ((TextBox)c).Enabled = false;
                    if (c is DropDownList)
                        ((DropDownList)c).Enabled = false;
                }
            }
        }
        if (Session["UserName"] != null && Session["myShoppingBag"] != null)
        {
            ImgLogin.Visible = false;
            LabelIsLoggedIn.Visible = false;
            foreach (Control c in Panel1.Controls)
            {
                if (c is Button)
                    ((Button)c).Enabled = true;
                if (c is Label)
                    ((Label)c).Enabled = true;
                if (c is TextBox)
                    ((TextBox)c).Enabled = true;
                if (c is DropDownList)
                    ((DropDownList)c).Enabled = true;
            }
        }

        if (Session["UserName"] == null)
        {

            foreach (Control c in Panel1.Controls)
            {
                if (c is Button)
                    ((Button)c).Enabled = false;
                if (c is Label)
                    ((Label)c).Enabled = false;
                if (c is TextBox)
                    ((TextBox)c).Enabled = false;
                if (c is DropDownList)
                    ((DropDownList)c).Enabled = false;
                LabelIsLoggedIn.Visible = true;
                ImgLogin.Visible = true;
                Session["NeedToLogIn"] = "true";
            }
        }
    }
    protected void ButtonOrder_Click(object sender, EventArgs e)
    {

        string un;
        mShoppingBag = (ShoppingBagNew)Session["myShoppingBag"];
        OrderDetails order = new OrderDetails();
        UserService userservice = new UserService();
        UserDetails user = new UserDetails();
        OrderService orderservice = new OrderService();
        un = Session["UserName"].ToString();
        user = userservice.GetUserByUserName(un);
        order.UserID = user.UserID;
        order.OrderAddress = user.Address;
        order.OrderDate = DateTime.Now;
        order.OrderStatus = "New";
        order.ShoppingBag = mShoppingBag;
        order.PaymentSum = (decimal)mShoppingBag.GetFinalPrice();
        orderservice.createOrder(order);
        foreach (Control c in Panel1.Controls)
        {

            if (c is Button)
                ((Button)c).Enabled = false;
            if (c is Label)
                ((Label)c).Enabled = false;
            if (c is TextBox)
                ((TextBox)c).Enabled = false;
            if (c is DropDownList)
                ((DropDownList)c).Enabled = false;

        }
        LabelMessage.Text = "רכישה הושלמה! מספר הזמנה: " + srvs.GetLastOrderID().ToString();
        Session["myShoppingBag"] = null;
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }
}