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
/// Summary description for UserService
/// </summary>
public class UserService
{

    private OleDbConnection myconn;
	public UserService()
	{
        
        string connectionstring = ConnectSite.GetConnectionString();
        myconn = new OleDbConnection(connectionstring);
	}
    public void InsertUser(UserDetails user)
    {
        OleDbCommand objCmd = new OleDbCommand("InsertUser", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objParam;

        objParam = objCmd.Parameters.Add("@NewUserName", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = user.UserName;

        objParam = objCmd.Parameters.Add("@NewPassword", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = user.Password;

        objParam = objCmd.Parameters.Add("@NewEmail", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = user.Email;

        objParam = objCmd.Parameters.Add("@NewFirstName", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = user.FirstName;

        objParam = objCmd.Parameters.Add("@NewLastName", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = user.LastName;

        objParam = objCmd.Parameters.Add("@NewPhoneNumber", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = user.PhoneNumber;

        objParam = objCmd.Parameters.Add("@NewCity", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = user.City;

        objParam = objCmd.Parameters.Add("@NewAddress", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = user.Address;

        objParam = objCmd.Parameters.Add("@NewZipCode", OleDbType.Integer);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = user.ZipCode;


        try
        {
            myconn.Open();
            objCmd.ExecuteNonQuery();
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
    public UserDetails GetUserByUserName(string UserName)
    {
        UserDetails user = new UserDetails();

        OleDbCommand objCmd = new OleDbCommand("GetUserByUserName", myconn);
        objCmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objParam;

        objParam = objCmd.Parameters.Add("@UserName", OleDbType.BSTR);
        objParam.Direction = ParameterDirection.Input;
        objParam.Value = UserName;
        try
        {
            myconn.Open();
            OleDbDataReader dr = objCmd.ExecuteReader();
            if (dr.Read())
            {
                user.UserID = int.Parse(dr["UserID"].ToString());
                user.UserName = dr["UserName"].ToString();
                user.Password = dr["Password"].ToString();
                user.Email = dr["Email"].ToString();
                user.FirstName = dr["FirstName"].ToString();
                user.PhoneNumber = dr["PhoneNumber"].ToString();
                user.City = dr["City"].ToString();
                user.Address = dr["Address"].ToString();
                user.ZipCode = int.Parse(dr["ZipCode"].ToString());
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
        return user;
    }

    public bool IsUserExist(string UserName)
    {
        UserService service = new UserService();
        UserDetails user=new UserDetails();
        user = service.GetUserByUserName(UserName);
        if (user.UserID == 0)
        {
            return false;
        }
        else return true;
    }


}
