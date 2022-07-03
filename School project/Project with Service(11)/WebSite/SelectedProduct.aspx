<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SelectedProduct.aspx.cs" Inherits="SelectedProduct" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style16
    {
        width: 100%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <br />
    <table align="center" class="style16" dir="ltr" frame="void" 
        style="border-style: solid">
        <tr>
            <td>
                &nbsp; &nbsp;</td>
            <td align="center">
                <asp:Label ID="LabelProductName" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center" style="border-style: solid">
                <asp:ImageButton ID="ImageButtonProduct" runat="server" Height="150px" 
                    onclick="ImageButtonProduct_Click" Width="150px" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="ButtonEditProduct" runat="server" 
                    onclick="ButtonEditProduct_Click" Text="ערוך מוצר" Visible="False" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="ButtonDeleteProduct" runat="server" 
                    onclick="ButtonDeleteProduct_Click" Text="מחק מוצר" Visible="False" onClientClick="return confirm('בטוח שאתה רוצה למחוק?\n\nClick \'OK\' to continue or click \'Cancel\'');"/>
            </td>
            <td>
                <asp:Label ID="LabelPrice" runat="server"></asp:Label>
            </td>
            <td dir="rtl">
                מחיר:</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</p>
</asp:Content>

