<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style16
        {
            width: 100%;
        }
        .style17
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div dir="rtl">
        <br />
        <table class="style16">
            <tr>
                <td>
                    שם מוצר</td>
                <td>
                    <asp:TextBox ID="TextBoxProductName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
                        ControlToValidate="TextBoxProductName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    סוג מוצר</td>
                <td>
                    <asp:DropDownList ID="DropDownListKind" runat="server" Height="22px" 
                        Width="170px">
                        <asp:ListItem Value="1">מעבד</asp:ListItem>
                        <asp:ListItem Value="2">כרטיס מסך</asp:ListItem>
                        <asp:ListItem Value="3">לוח אם</asp:ListItem>
                        <asp:ListItem Value="4">זכרון</asp:ListItem>
                        <asp:ListItem Value="5">דיסק קשיח</asp:ListItem>
                        <asp:ListItem Value="6">מארז</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorKind" runat="server" 
                        ControlToValidate="DropDownListKind" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style17">
                    יצרן</td>
                <td class="style17">
                    <asp:DropDownList ID="DropDownListManufacturer" runat="server" Width="168px">
                        <asp:ListItem Value="1">AMD</asp:ListItem>
                        <asp:ListItem Value="2">Intel</asp:ListItem>
                        <asp:ListItem Value="3">Acer</asp:ListItem>
                        <asp:ListItem Value="4">Gigabyte</asp:ListItem>
                        <asp:ListItem Value="5">Corsair</asp:ListItem>
                        <asp:ListItem Value="6">Samsung</asp:ListItem>
                        <asp:ListItem Value="7">Thermaltake</asp:ListItem>
                        <asp:ListItem Value="8">Corsair</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style17">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorManufacturer" 
                        runat="server" ControlToValidate="DropDownListManufacturer" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    מחיר</td>
                <td>
                    <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice" runat="server" 
                        ControlToValidate="TextBoxPrice" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPrice" 
                        runat="server" ControlToValidate="TextBoxPrice" ErrorMessage="חובה מספר" 
                        ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    יחידות</td>
                <td>
                    <asp:TextBox ID="TextBoxUnits" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUnits" runat="server" 
                        ControlToValidate="TextBoxUnits" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorUnits" 
                        runat="server" ControlToValidate="TextBoxUnits" ErrorMessage="חובה מספר" 
                        ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    תיאור</td>
                <td>
                    <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" 
                        runat="server" ControlToValidate="TextBoxDescription" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    תמונה</td>
                <td>
                    <asp:TextBox ID="TextBoxImage" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorImage" runat="server" 
                        ControlToValidate="TextBoxImage" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    דירוג</td>
                <td>
                    <asp:TextBox ID="TextBoxRating" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorRating" runat="server" 
                        ControlToValidate="TextBoxRating" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorRating" 
                        runat="server" ControlToValidate="TextBoxRating" ErrorMessage="חובה מספר" 
                        ValidationExpression="\d*"></asp:RegularExpressionValidator>
                </td>
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
                    <asp:Button ID="ButtonConfirm" runat="server" onclick="ButtonConfirm_Click" 
                        Text="הוסף מוצר" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="LabelMessage" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
    </div>
</asp:Content>

