using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null || Session["Password"] != null)
        {
            ImgLogin.Visible = false;
            ImgSignup.Visible = false;
            LabelWelcome.Visible = true;
            LabelName.Text = Session["UserName"].ToString();
            LabelName.Visible = true;
            LinkButtonLogOut.Visible = true;
            LinkButtonMyOrders.Visible = true;
        }
        string un = (string)Session["UserName"];
        if (un == "daniel")
        {
            MenuAdmin.Visible = true;
        }
    }
    protected void LinkButtonLogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        ImgLogin.Visible = true;
        ImgSignup.Visible = true;
        Response.Redirect("Products.aspx");

    }
    protected void LinkButtonMyOrders_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyOrders.aspx");
    }
}
