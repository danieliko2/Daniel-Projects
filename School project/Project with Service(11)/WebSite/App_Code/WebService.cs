using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    public DataSet GetAllOrders()
    {
        OrderService ordrsrvs = new OrderService();
        return ordrsrvs.GetAllOrders();
    }
    [WebMethod]
    public DataSet GetNewOrders()
    {
        OrderService ordrsrvs = new OrderService();
        return ordrsrvs.GetNewOrders();
    }
    [WebMethod]
    public DataSet GetProductsInOrder(int orderid)
    {
        OrderService srvs = new OrderService();
        return srvs.GetProductsInOrderByOrderID(orderid);
    }
    [WebMethod]
    public void UpdateOrderStatus(string status, int orderid)
    {
        OrderDetails order = new OrderDetails();
        order.OrderID = orderid;
        order.OrderStatus = status;
        OrderService srvs = new OrderService();
        srvs.UpdateOrderStatus(order);
    }
    [WebMethod]
    public void UpdateOrderDeliveryID(int deliveryid, int orderid)
    {
        OrderService srvs = new OrderService();
        srvs.UpdateOrderDeliveryID(orderid, deliveryid);
    }
}
