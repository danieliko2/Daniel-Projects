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

public partial class LoginForm : System.Web.UI.Page
{
    UserDetails user = new UserDetails();
    UserService service = new UserService();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void ButtonLogin_Click(object sender, EventArgs e)
    {

        if (service.IsUserExist(TextBoxUserName.Text))
        {
            user = service.GetUserByUserName(TextBoxUserName.Text);
            if (user.Password != TextBoxPassword.Text)
            {
                LabelMessage.Text = "שם משתמש או סיסמא שגויים";
            }
            else
            {
                Session["UserName"] = TextBoxUserName.Text;
                Session["Password"] = TextBoxPassword.Text;
                LabelMessage.Text = "התחברות הושלמה";
                Image img1 = (Image)Master.FindControl("ImgLogin");
                img1.Visible = false;
                Image img2 = (Image)Master.FindControl("ImgSignUp");
                img2.Visible = false;
                LinkButton lnk = (LinkButton)Master.FindControl("LinkButtonLogOut");
                lnk.Visible = true;
                LinkButton lnk2 = (LinkButton)Master.FindControl("LinkButtonMyOrders");
                lnk2.Visible = true;
                Label l1 = (Label)Master.FindControl("LabelWelcome");
                l1.Visible = true;
                Label l2 = (Label)Master.FindControl("LabelName");
                l2.Visible = true;
                Menu m = (Menu)Master.FindControl("MenuAdmin");
                m.Visible = true;

                l2.Text = TextBoxUserName.Text;
                LabelPassword.Visible = false;
                LabelUserName.Visible = false;
                TextBoxPassword.Visible = false;
                TextBoxUserName.Visible = false;
                ButtonLogin.Visible = false;
                if (Session["NeedToLogIn"]!=null && Session["NeedToLogIn"].ToString() == "true")
                    Response.Redirect("OrderPage.aspx");
            }
        }
        else LabelMessage.Text = "שם משתמש או סיסמא שגויים";
    }
}
