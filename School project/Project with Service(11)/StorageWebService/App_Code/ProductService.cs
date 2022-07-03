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

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService
{

    private OleDbConnection myconn;
	public ProductService()
	{
        
        string connectionstring = ConnectStore.GetConnectionString();
        myconn = new OleDbConnection(connectionstring);
	}
    public DataSet GetAllProducts()
    {
        OleDbCommand objCmd = new OleDbCommand("GetAllProducts", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;
        try
        {
            OleDbDataAdapter adapter1 = new OleDbDataAdapter(objCmd);
            DataSet ds = new DataSet();
            adapter1.Fill(ds, "Products");
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
    public ProductDetails GetProductByID(int ProductID)
    {
        ProductDetails product = new ProductDetails();

        OleDbCommand objCmd = new OleDbCommand("GetProductByProductID", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objParam;

        objParam = objCmd.Parameters.Add("@ProductID", OleDbType.Integer);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = ProductID;
        try
        {
            myconn.Open();
            OleDbDataReader dr = objCmd.ExecuteReader();
            if (dr.Read())
            {
                product.ProductName = dr["ProductName"].ToString();
                product.KindID = int.Parse(dr["KindID"].ToString());
                product.ManufacturerID = int.Parse(dr["ManufacturerID"].ToString());
                product.Price = decimal.Parse(dr["Price"].ToString());
                product.UnitsInStock = int.Parse(dr["UnitsInStock"].ToString());
                product.UnitsInOrder = int.Parse(dr["UnitsInOrder"].ToString());
                product.Description = dr["Description"].ToString();
                product.ImageURL = dr["ImageUrl"].ToString();
                product.Rating = int.Parse(dr["Rating"].ToString());
            }
        }
            
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myconn.Close();
        }
        product.ProductID = ProductID;
        return product;
    }
    public DataSet GetProductsByKindID(int kindid)
    {

        OleDbCommand objCmd = new OleDbCommand("GetProductsByKindID", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objParam;

        objParam = objCmd.Parameters.Add("@KindID", OleDbType.Integer);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = kindid;
        try
        {
            OleDbDataAdapter adapter1 = new OleDbDataAdapter(objCmd);
            DataSet ds = new DataSet();
            adapter1.Fill(ds, "Products");
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
    public int GetUnitsInStock(int productid)
    {

        OleDbCommand objCmd = new OleDbCommand("GetUnitsInStockByProductID", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objParam;

        objParam = objCmd.Parameters.Add("@ProductID", OleDbType.Integer);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = productid;
        try
        {
            myconn.Open();
            return (int)objCmd.ExecuteScalar();
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
    public void UpdateUnitsInStock(ProductDetails product)
    {


        OleDbCommand mycmd = new OleDbCommand("UpdateUnitsInStockByProductID", myconn);
        mycmd.CommandType = CommandType.StoredProcedure;



        ProductService srvs = new ProductService();

        OleDbParameter objparam;
        objparam = mycmd.Parameters.Add("@UnitsInStock", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.UnitsInStock;

        objparam = mycmd.Parameters.Add("@ProductID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.ProductID;


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
    public void UpdateProduct(ProductDetails product)
    {


        OleDbCommand mycmd = new OleDbCommand("UpdateProduct", myconn);
        mycmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objparam;

        objparam = mycmd.Parameters.Add("@ProductName", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.ProductName;

        objparam = mycmd.Parameters.Add("@KindID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.KindID;

        objparam = mycmd.Parameters.Add("@ManufacturerID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.ManufacturerID;

        objparam = mycmd.Parameters.Add("@Price", OleDbType.Decimal);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.Price;

        objparam = mycmd.Parameters.Add("@UnitsInStock", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.UnitsInStock;

        objparam = mycmd.Parameters.Add("@UnitsInOrder", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.UnitsInOrder;

        objparam = mycmd.Parameters.Add("@Description", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.Description;

        objparam = mycmd.Parameters.Add("@ImageURL", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.ImageURL;

        objparam = mycmd.Parameters.Add("@Rating", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.Rating;

        objparam = mycmd.Parameters.Add("@ProductID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.ProductID;


        
        try
        {
            myconn.Open();
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
    public void AddProduct(ProductDetails product)
    {
        OleDbCommand mycmd = new OleDbCommand("InsertProduct", myconn);
        mycmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objparam;
        objparam = mycmd.Parameters.Add("@ProductName", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.ProductName;
        objparam = mycmd.Parameters.Add("@KindID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.KindID;
        objparam = mycmd.Parameters.Add("@ManufacturerID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.ManufacturerID;
        objparam = mycmd.Parameters.Add("@Price", OleDbType.Decimal);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.Price;
        objparam = mycmd.Parameters.Add("@UnitsInStock", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.UnitsInStock;
        objparam = mycmd.Parameters.Add("@UnitsInOrder", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.UnitsInOrder;
        objparam = mycmd.Parameters.Add("@Description", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.Description;
        objparam = mycmd.Parameters.Add("@ImageURL", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.ImageURL;
        objparam = mycmd.Parameters.Add("@Rating", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = product.Rating;

        try
        {
            myconn.Open();
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
    public void DeleteProduct(int productid)
    {
        OleDbCommand mycmd = new OleDbCommand("DeleteProductByID", myconn);
        mycmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objparam;
        objparam = mycmd.Parameters.Add("@ProductID", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = productid;

        try
        {
            myconn.Open();
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
    public void InsertProductInDelivery(ProductInDeliveryDetails pid)
    {

        OleDbCommand mycmd = new OleDbCommand("AddProductInDelivery", myconn);
        mycmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objparam;

        objparam = mycmd.Parameters.Add("@DeliveryID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = pid.DeliveryID;

        objparam = mycmd.Parameters.Add("@ProductID", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = pid.ProductID;

        objparam = mycmd.Parameters.Add("@Quantity", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = pid.Quantity;

        objparam = mycmd.Parameters.Add("@TotalPrice", OleDbType.Decimal);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = pid.TotalPrice;

        try
        {
            myconn.Open();
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
