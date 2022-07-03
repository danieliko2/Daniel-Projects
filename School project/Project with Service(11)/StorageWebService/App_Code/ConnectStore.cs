using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for Connect
/// </summary>
public class ConnectStore
{
    const string FILE_NAME = "StoreDB.mdb";
    public ConnectStore()
    {

    }
    public static string GetConnectionString()
    {
        string location = HttpContext.Current.Server.MapPath("~/App_Data/" + FILE_NAME);
        string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;data source=" + location;
        return ConnectionString;
    }
}
