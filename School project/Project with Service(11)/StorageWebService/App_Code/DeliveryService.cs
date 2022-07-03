using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Collections;

/// <summary>
/// Summary description for DeliveryService
/// </summary>
public class DeliveryService
{
    private OleDbConnection myconn;
    private OleDbTransaction objtrans;
    private OleDbDataAdapter adapter;

	public DeliveryService()
	{
        string connectionString = ConnectStore.GetConnectionString();
        myconn = new OleDbConnection(connectionString);
	}
    //public DeliveryDetails ConvertToDelivery(OrderDetails order)
    //{
    //    DeliveryDetails delivery = new DeliveryDetails();
    //    delivery.UserID = order.OrderID;
    //    delivery.Date = DateTime.Now;

    //    return delivery;
    //}
    public void InsertDelivery(DeliveryDetails delivery)
    {


        OleDbCommand mycmd = new OleDbCommand("InsertDelivery", myconn);
        mycmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objparam; 

        objparam = mycmd.Parameters.Add("@Date", OleDbType.Date);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = delivery.Date;

        objparam = mycmd.Parameters.Add("@UserID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = delivery.UserID;

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
    public DataSet GetAllDeliveries()
    {
        OleDbCommand objCmd = new OleDbCommand("GetAllDeliveries", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;


        try
        {
            OleDbDataAdapter adapter1 = new OleDbDataAdapter(objCmd);
            DataSet ds = new DataSet();
            adapter1.Fill(ds, "Deliveries");
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
    public int GetLastDelivery()
    {
        int deliveryid = 0;
        string sSql = "select max(DeliveryID) from Deliveries";
        OleDbCommand mycmd = new OleDbCommand(sSql, myconn);
        mycmd.Transaction = objtrans;
        try
        {
            myconn.Open();
            deliveryid = int.Parse(mycmd.ExecuteScalar().ToString());

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myconn.Close();
        }
        return deliveryid;
    }
}