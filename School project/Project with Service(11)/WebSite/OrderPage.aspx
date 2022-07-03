<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderPage.aspx.cs" Inherits="OrderPage" %>

<%@ Register src="WebUserControlShoppingBag.ascx" tagname="WebUserControlShoppingBag" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style16
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:WebUserControlShoppingBag ID="WebUserControlShoppingBag1" runat="server" />
<p dir="rtl">
    <asp:Label ID="LabelIsLoggedIn" runat="server" Font-Bold="True" ForeColor="Red" 
        Text="עליך להיות מחובר על מנת לבצע רכישה"></asp:Label>
    </p>
    <div dir="rtl">
                    <a href="LoginForm.aspx"> <asp:Image ID="ImgLogin" runat="server" 
                        ImageUrl="~/Pics/התחבר.bmp" /></a>
                    <br />
                    <br />
                    <asp:Panel ID="Panel2" runat="server">
                        <br />
                        <asp:Panel ID="Panel1" runat="server">
                            <table class="style16">
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelCreditCompanyName" runat="server" 
                Text="שם חברת אשראי"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListCreditCompanyName" runat="server">
                                            <asp:ListItem>Visa</asp:ListItem>
                                            <asp:ListItem>MasterCard</asp:ListItem>
                                            <asp:ListItem>AmericanExpress</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelCreditNumber" runat="server" 
                Text="מספר כרטיס אשראי"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxCreditNumber" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCreditCard" 
                                            runat="server" ControlToValidate="TextBoxCreditNumber" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelIDNumber" runat="server" 
                Text="תעודת זהות"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxIDNumber" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIDNumber" runat="server" 
                                            ControlToValidate="TextBoxIDNumber" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                            ErrorMessage="CustomValidator" 
                                            onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                                    </td>
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
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonOrder" runat="server" onclick="ButtonOrder_Click" 
                            Text="הזמן" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                    </asp:Panel>
                    <p align="center">
                    <asp:Label ID="LabelMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </p>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>

