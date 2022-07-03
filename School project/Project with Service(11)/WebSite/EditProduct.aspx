<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="EditProduct" Title="Untitled Page" %>

<%@ Register src="WebUserControlEditProduct.ascx" tagname="WebUserControlEditProduct" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:WebUserControlEditProduct ID="WebUserControlEditProduct1" runat="server" />
</asp:Content>

