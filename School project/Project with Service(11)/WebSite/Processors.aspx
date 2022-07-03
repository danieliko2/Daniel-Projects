<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Processors.aspx.cs" Inherits="Processors" %>

<%@ Register src="WebUserControlDataList.ascx" tagname="WebUserControlDataList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:WebUserControlDataList ID="WebUserControlDataList1" runat="server" />
</asp:Content>

