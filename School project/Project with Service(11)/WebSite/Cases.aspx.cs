using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cases : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ProductsKindID"] = 6;
    }
    protected void DataListCases_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //Session["ProductID"] = Convert.ToInt32(DataListCases.DataKeys[e.Item.ItemIndex]);
        //Response.Redirect("SelectedProduct.aspx");
    }
}