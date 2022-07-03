using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class OrderPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateGridViewOrder();
    }
    protected void PopulateGridViewOrder()
    {
        localhostService.Service srvs = new localhostService.Service();
        GridViewOrder.DataSource = srvs.GetProductsInOrder(Convert.ToInt32(Session["OrderID"]));
        GridViewOrder.DataBind();
    }

    protected void ButtonApprove_Click(object sender, EventArgs e)
    {
        InsertDelivery();
    }

    protected void InsertDelivery()
    {
        localhostService.Service srvs = new localhostService.Service();
        DeliveryDetails delivery = new DeliveryDetails();
        DeliveryService dservs = new DeliveryService();
        delivery.UserID = Convert.ToInt32(Session["UserID"]);
        delivery.Date = DateTime.Now;



        bool flag = true;
        bool flag2 = true;
        ProductService psrvs=new ProductService();

        for (int i = 0; i < GridViewOrder.Rows.Count; i++)
        {
            GridViewRow row = GridViewOrder.Rows[i];
            ProductDetails product = new ProductDetails();

            product.UnitsInOrder = Convert.ToInt32(row.Cells[3].Text);
            product.ProductID = Convert.ToInt32(row.Cells[1].Text);
            product.Price = Convert.ToInt32(row.Cells[4].Text);

            if (psrvs.GetUnitsInStock(product.ProductID) < product.UnitsInStock)
            {
                i = GridViewOrder.Rows.Count;
                LabelMessage.Text = " כמות המוצרים של מוצר מס' " + product.ProductID.ToString() + " קטנה מידיי";
                flag = false;
            }
            else
            {
                if (flag2)
                {
                    dservs.InsertDelivery(delivery);
                    flag2 = false;
                }
                product.UnitsInStock = psrvs.GetUnitsInStock(product.ProductID) - product.UnitsInStock;
              // עדכון הכמות של המוצרים במלאי
                psrvs.UpdateUnitsInStock(product);

                int deliveryID = dservs.GetLastDelivery();
                srvs.UpdateOrderDeliveryID(deliveryID, int.Parse(Session["OrderID"].ToString()));
                ProductInDeliveryDetails pid = new ProductInDeliveryDetails();
                pid.DeliveryID = deliveryID;
                pid.ProductID = product.ProductID;
                pid.Quantity = product.UnitsInOrder;
                pid.TotalPrice = product.Price;
                psrvs.InsertProductInDelivery(pid);

            }
        }
        if (flag)
        {

            srvs.UpdateOrderStatus("In Delivery / Delivered", Convert.ToInt32(Session["OrderID"]));
            LabelMessage.Text = "הועבר למשלוח בהצלחה, מספר משלוח: "+dservs.GetLastDelivery().ToString()+".";
        }
            ButtonApprove.Enabled = false;

    }
}