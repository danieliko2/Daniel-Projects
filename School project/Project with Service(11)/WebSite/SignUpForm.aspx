<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUpForm.aspx.cs" Inherits="SignUpForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style10
        {
            width: 123px;
        }
        .style12
        
        {
            width: 145px;
        }
        .style11
        {
            height: 24px;
            width: 123px;
        }
        .style13
        {
            height: 24px;
            width: 145px;
        }
        .style9
        {
            height: 24px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p dir="rtl">
                    <asp:Label ID="LabelMessage" runat="server" Font-Bold="True" 
                        ForeColor="#FF3300"></asp:Label>
                    </p>
    <div dir="rtl">
        <asp:Panel ID="Panel1" runat="server">
            <p dir="rtl">
                &nbsp;</p>
            <div dir="rtl">
                <div dir="rtl">
                    <table class="style1">
                        <tr>
                            <td class="style10">
                                שם משתמש<br />
                                <br />
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" 
                                    ControlToValidate="TextBoxUserName" ErrorMessage="הכנס שם משתמש"></asp:RequiredFieldValidator>
                                &nbsp;<br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                סיסמא<br />
                                <br />
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" 
                                    Width="150px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" 
                                    ControlToValidate="TextBoxPassword" ErrorMessage="הכנס סיסמא"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                אשר סיסמא<br />
                                <br />
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TextBoxConfirmPassword" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" 
                                    runat="server" ControlToValidate="TextBoxConfirmPassword" 
                                    ErrorMessage="הכנס אישור סיסמא"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                אימייל<br />
                                <br />
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" 
                                    ControlToValidate="TextBoxEmail" ErrorMessage="הכנס דואר אלקטרוני"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                אשר אימייל<br />
                                <br />
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TextBoxConfirmEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmEmail" 
                                    runat="server" ControlToValidate="TextBoxEmail" 
                                    ErrorMessage="הכנס אישור דואר אלקטרוני"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                שם פרטי<br />
                                <br />
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName" runat="server" 
                                    ControlToValidate="TextBoxFirstName" ErrorMessage="הכנס שם פרטי"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                שם משפחה<br />
                                <br />
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" 
                                    ControlToValidate="TextBoxLastName" ErrorMessage="הכנס שם משפחה"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                מספר טלפון<br />
                                <br />
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" 
                                    ControlToValidate="TextBoxPhone" ErrorMessage="הכנס מספר טלפון"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                עיר מגורים<br />
                                <br />
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TextBoxCity" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server" 
                                    ControlToValidate="TextBoxCity" ErrorMessage="הכנס עיר מגורים"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                כתובת+מס&#39; בית<br />
                                <br />
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" 
                                    ControlToValidate="TextBoxAddress" ErrorMessage="הכנס כתובת"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                מיקוד<br />
                                <br />
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TextBoxZipCode" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorZipCode" runat="server" 
                                    ControlToValidate="TextBoxZipCode" ErrorMessage="הכנס מיקוד"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                &nbsp;</td>
                            <td class="style12">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style11">
                            </td>
                            <td class="style13">
                                &nbsp;</td>
                            <td class="style9">
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                &nbsp;</td>
                            <td class="style12">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="ButtonConfirm" runat="server" Text="הרשם" 
                        onclick="ButtonConfirm_Click" />
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
        <br />
    </div>
</asp:Content>

