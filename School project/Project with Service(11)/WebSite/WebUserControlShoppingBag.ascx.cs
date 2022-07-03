using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControlShoppingBag : System.Web.UI.UserControl
{
    ShoppingBagNew myShoppingBag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["myShoppingBag"] != null)
        {

            myShoppingBag = (ShoppingBagNew)Session["myShoppingBag"];
            if (!Page.IsPostBack)
                Populate_GridViewShoppingBag();
        }
    }
    public void Populate_GridViewShoppingBag()
    {

        this.GridViewShoppingBag.DataSource = myShoppingBag.ConvertToViewDataTable();
        this.GridViewShoppingBag.DataBind();
    }
    protected void myShoppingBag_myEventBag(object sender, EventArgs e)
    {
        Populate_GridViewShoppingBag();
    }

    protected void GridViewShoppingBag_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewShoppingBag.EditIndex = -1;
        Populate_GridViewShoppingBag();
    }
    protected void GridViewShoppingBag_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        myShoppingBag = (ShoppingBagNew)Session["myShoppingBag"];
        ProductInBag gameInBag = new ProductInBag();
        int rowIndex = e.RowIndex;
        GridViewRow row = GridViewShoppingBag.Rows[rowIndex];
        gameInBag.Product.ProductID = Convert.ToInt32(this.GridViewShoppingBag.DataKeys[rowIndex].Value.ToString());
        myShoppingBag.DeleteProduct(gameInBag);
        Session["myShoppingBag"] = myShoppingBag;
        GridViewShoppingBag.EditIndex = -1;
        Populate_GridViewShoppingBag();
    }
    protected void GridViewShoppingBag_RowEditing(object sender, GridViewEditEventArgs e)
    {
         GridViewShoppingBag.EditIndex = e.NewEditIndex;
         Populate_GridViewShoppingBag();
    }
    protected void GridViewShoppingBag_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        myShoppingBag = (ShoppingBagNew)Session["myShoppingBag"];
        ProductInBag p = new ProductInBag();
        GridViewRow row = GridViewShoppingBag.Rows[e.RowIndex];

        p.Product.ProductID = Convert.ToInt32(this.GridViewShoppingBag.DataKeys[e.RowIndex].Value.ToString());
        localhostService.Service srvs = new localhostService.Service();
        p.Product.Price = srvs.GetProductByID(p.Product.ProductID).Price;
        p.Quantity = int.Parse(((TextBox)row.Cells[2].Controls[0]).Text);
        p.TotalPrice = (double)p.Product.Price * (double)p.Quantity;

        myShoppingBag.UpdateProduct(p);
        Session["myShoppingBag"] = myShoppingBag;
        GridViewShoppingBag.EditIndex = -1;
        Populate_GridViewShoppingBag();
    }
    protected void GridViewShoppingBag_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridViewShoppingBag_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridViewShoppingBag_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       // if (e.Row.RowType != DataControlRowType.Header &&
       //e.Row.RowType != DataControlRowType.Footer &&
       //e.Row.RowType != DataControlRowType.Pager)
       // {
       //     int Quantity = 0;
       //     if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate) &&
       //           e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Normal))
       //     {
       //         Label l1 = (Label)e.Row.Cells[4].FindControl("Label1");
       //         Quantity = Convert.ToInt32(e.Row.Cells[2].Text);
       //         decimal Price = Convert.ToDecimal(e.Row.Cells[3].Text);
       //         decimal s = (decimal)(Price * Quantity);
       //         l1.Text = s.ToString();
       //     }
       //     else
       //     {
       //         Label l2 = (Label)e.Row.Cells[4].FindControl("Label2");
       //         Quantity = Convert.ToInt32(((TextBox)e.Row.Cells[2].Controls[0]).Text);
       //         decimal Price = Convert.ToDecimal(e.Row.Cells[3].Text);
       //         decimal s = (decimal)(Price * Quantity);
       //         l2.Text = s.ToString();
       //     }
       // }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label l2 = (Label)e.Row.Cells[4].FindControl("LabelFooter");
            myShoppingBag = (ShoppingBagNew)Session["myShoppingBag"];
            double k = myShoppingBag.GetFinalPrice();
            l2.Text = k.ToString();
        }
    }
}