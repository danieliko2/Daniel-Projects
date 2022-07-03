<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllOrders.aspx.cs" Inherits="Approve" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridViewOrders" runat="server" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            EnableModelValidation="True" onrowcommand="GridViewOrders_RowCommand">
            <Columns>
                <asp:ButtonField Text="עבור להזמנה" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
