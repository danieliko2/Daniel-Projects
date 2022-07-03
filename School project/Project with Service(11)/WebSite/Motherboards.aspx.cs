using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Motherboards : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ProductsKindID"] = 3;
    }
    protected void DataListMotherBoards_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //Session["ProductID"] = Convert.ToInt32(DataListMotherBoards.DataKeys[e.Item.ItemIndex]);
        //Response.Redirect("SelectedProduct.aspx");
    }
}