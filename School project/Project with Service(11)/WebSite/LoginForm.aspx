<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginForm.aspx.cs" Inherits="LoginForm" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style15
    {
        width: 100%;
        height: 159px;
    }
    .style16
    {
        width: 214px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div dir="rtl">

        <br />

        <br />
    <table class="style15">
        <tr>
            <td class="style16">
                &nbsp;</td>
            <td>
                <asp:Label ID="LabelMessage" runat="server" Font-Bold="True" 
                    ForeColor="#FF3300"></asp:Label>
                                        </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="LabelUserName" runat="server" Text="שם משתמש"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxUserName" runat="server" Width="137px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" 
                    ControlToValidate="TextBoxUserName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style16">
                <asp:Label ID="LabelPassword" runat="server" Text="סיסמא"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" 
                    ControlToValidate="TextBoxPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style16">
                &nbsp;</td>
            <td>
                <asp:Button ID="ButtonLogin" runat="server" Text="התחבר" 
                    onclick="ButtonLogin_Click" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />

    <br />

</div>
<br />
</asp:Content>

