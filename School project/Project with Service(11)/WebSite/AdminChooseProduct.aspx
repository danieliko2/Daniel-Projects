<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminChooseProduct.aspx.cs" Inherits="AdminDeleteProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style16
    {
        width: 100%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <table class="style16" dir="rtl">
        <tr>
            <td>
                לפי ProductID</td>
            <td>
                &nbsp;&nbsp; &nbsp;</td>
            <td>
                לפי שם</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBoxProductID" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:DropDownList ID="DropDownListProducts" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownListProducts_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ButtonConfirm" runat="server" onclick="ButtonConfirm_Click" 
                    Text="אשר" />
            </td>
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
    <br />
    <br />
    <br />
</div>
</asp:Content>

