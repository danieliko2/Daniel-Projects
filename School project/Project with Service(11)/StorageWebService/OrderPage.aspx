﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderPage.aspx.cs" Inherits="OrderPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridViewOrder" runat="server">
        </asp:GridView>
    
        <br />
        <asp:Button ID="ButtonApprove" runat="server" onclick="ButtonApprove_Click" 
            Text="אשר הזמנה" />
    
        <br />
        <br />
        <asp:Label ID="LabelMessage" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>