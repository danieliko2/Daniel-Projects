using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;
using System.Collections;

/// <summary>
/// Summary description for OrderService
/// </summary>
public class OrderService
{
    private OleDbConnection myconn;
    private OleDbTransaction objtrans;
    private OleDbDataAdapter adapter;
	public OrderService()
	{
        string connectionString = ConnectSite.GetConnectionString();
        myconn = new OleDbConnection(connectionString);
        string sql = "select * from ProductsInOrder";
        adapter = new OleDbDataAdapter(sql, myconn);
	}
    public int createOrder(OrderDetails order)
    {
        int orderNumber = 0;
        //מוסיפה הזמנה לבסיס הנתונים לטבלת         
        // Orders
        try
        {
            myconn.Open();
            objtrans = myconn.BeginTransaction();
            InsertOrder(order);
            orderNumber = OrderNumber();
            objtrans.Commit();

        }
        catch (Exception ex)
        {
            objtrans.Rollback();
            throw ex;
        }
        finally
        {
            myconn.Close();
        }
        InsertProductsInOrder(order, orderNumber);
        return orderNumber;
    }
    public void InsertOrder(OrderDetails order)
    {
        // UserID, FirstName, LastName, Phone, Address, ZipCode, Email, CreditCardKind, CreditCardOwner, 
        //CreditCardNumber, CreditCardTokef, CreditCardAishor, Status, OrderDate, RequiredDate )

        OleDbCommand mycmd = new OleDbCommand("InsertOrder", myconn);
        mycmd.CommandType = CommandType.StoredProcedure;

        mycmd.Transaction = objtrans;
        OleDbParameter objparam;
        objparam = mycmd.Parameters.Add("@UserID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = order.UserID;
        objparam = mycmd.Parameters.Add("@OrderDate", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = order.OrderDate;
        objparam = mycmd.Parameters.Add("@PaymentSum", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = order.PaymentSum;
        objparam = mycmd.Parameters.Add("@OrderAddress", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = order.OrderAddress;
        objparam = mycmd.Parameters.Add("@OrderStatus", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = order.OrderStatus;
        objparam = mycmd.Parameters.Add("@DeliveryID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = order.DeliveryID;
        
        try
        {
            mycmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public int GetLastOrderID()
    {
        int id;
        try
        {
            myconn.Open();
            id = OrderNumber();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myconn.Close();
        }
        return id;
    }
    public int OrderNumber()
    {
        int orderid = 0;
        string sSql = "select max(OrderID) from Orders";
        OleDbCommand mycmd = new OleDbCommand(sSql, myconn);
        mycmd.Transaction = objtrans;
        try
        {
            
            orderid = int.Parse(mycmd.ExecuteScalar().ToString());

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return orderid;
    }
    public DataSet GetOrderByOrderID(int OrderID)
    {
        DataSet ds = new DataSet();
        OleDbCommand objCmd = new OleDbCommand("GetOrderByOrderID", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objparam;

        objparam = objCmd.Parameters.Add("@OrderID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = OrderID;
        try
        {
            myconn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(objCmd);
            adapter.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myconn.Close();
        }
        return ds;
    }
    public void InsertProductsInOrder(OrderDetails order, int orderid)
    {

        ShoppingBagNew shoppingbag = order.ShoppingBag;
        OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
        adapter.InsertCommand = builder.GetInsertCommand();
        adapter.Update(shoppingbag.ConvertToViewDataTable2(orderid));
    }
    public DataSet GetAllOrders()
    {
        OleDbCommand objCmd = new OleDbCommand("GetAllOrders", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;


        try
        {
            OleDbDataAdapter adapter1 = new OleDbDataAdapter(objCmd);
            DataSet ds = new DataSet();
            adapter1.Fill(ds, "Orders");
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myconn.Close();
        }
    }
    public DataSet GetNewOrders()
    {

        OleDbCommand objCmd = new OleDbCommand("GetNewOrders", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objparam;
        objparam = objCmd.Parameters.Add("@OrderStatus", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = "New";

        try
        {
            OleDbDataAdapter adapter1 = new OleDbDataAdapter(objCmd);
            DataSet ds = new DataSet();
            adapter1.Fill(ds, "NewOrders");
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myconn.Close();
        }


    }
    public DataSet GetProductsInOrderByOrderID(int orderid)
    {

        DataSet ds = new DataSet();
        OleDbCommand objCmd = new OleDbCommand("GetProductsInOrderByOrderID", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objparam;

        objparam = objCmd.Parameters.Add("@OrderID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = orderid;
        try
        {
            myconn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(objCmd);
            adapter.Fill(ds, "ProductsInOrder");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myconn.Close();
        }
        return ds;


    }
    public void UpdateOrderStatus(OrderDetails order)
    {

        OleDbCommand mycmd = new OleDbCommand("UpdateOrderStatusByOrderID", myconn);
        mycmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objparam;


        objparam = mycmd.Parameters.Add("@OrderStatus", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = order.OrderStatus;

        objparam = mycmd.Parameters.Add("@OrderID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = order.OrderID;


        myconn.Open();
        try
        {
            mycmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myconn.Close();
        }

    }
    public DataSet GetOrdersByUserID(int userid)
    {

        DataSet ds = new DataSet();
        OleDbCommand objCmd = new OleDbCommand("GetOrdersByUserID", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objparam;

        objparam = objCmd.Parameters.Add("@UserID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = userid;
        try
        {
            myconn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(objCmd);
            adapter.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myconn.Close();
        }
        return ds;
    }
    public void UpdateOrderDeliveryID(int orderid, int deliveryid)
    {

        OleDbCommand mycmd = new OleDbCommand("UpdateDeliveryID", myconn);
        mycmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objparam;


        objparam = mycmd.Parameters.Add("@DeliveryID", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = deliveryid;

        objparam = mycmd.Parameters.Add("@OrderID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = orderid;


        myconn.Open();
        try
        {
            mycmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myconn.Close();
        }
    }

}