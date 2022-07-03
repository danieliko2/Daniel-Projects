using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUpForm2 : System.Web.UI.Page
{
    UserDetails NewUser = new UserDetails();
    UserService service = new UserService();
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void ButtonConfirm_Click(object sender, EventArgs e)
    {
        NewUser.UserName = TextBoxUserName.Text;
        NewUser.Password = TextBoxPassword.Text;
        NewUser.Email = TextBoxEmail.Text;
        NewUser.FirstName = TextBoxFirstName.Text;
        NewUser.LastName = TextBoxLastName.Text;
        NewUser.PhoneNumber = TextBoxPhone.Text;
        NewUser.City = TextBoxCity.Text;
        NewUser.Address = TextBoxAddress.Text;
        NewUser.ZipCode = int.Parse(TextBoxZipCode.Text);

        if (service.IsUserExist(NewUser.UserName) == false)
        {
            service.InsertUser(NewUser);
            LabelMessage.Text = "הרשמה הושלמה!";

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
        else LabelMessage.Text = "שם משתמש קיים, בחר שם משתמש חדש";

    }
}