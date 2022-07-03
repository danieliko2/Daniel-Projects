<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControlShoppingBag.ascx.cs" Inherits="WebUserControlShoppingBag" %>
<asp:GridView ID="GridViewShoppingBag" runat="server" 
    AutoGenerateColumns="False" DataKeyNames="ProductID" 
    EnableModelValidation="True" 
    onrowcancelingedit="GridViewShoppingBag_RowCancelingEdit" 
    onrowdatabound="GridViewShoppingBag_RowDataBound" 
    onrowdeleting="GridViewShoppingBag_RowDeleting" 
    onrowediting="GridViewShoppingBag_RowEditing" 
    onrowupdating="GridViewShoppingBag_RowUpdating" 
    onselectedindexchanged="GridViewShoppingBag_SelectedIndexChanged" 
    onsorting="GridViewShoppingBag_Sorting" ShowFooter="True" 
    
    
    style="z-index: 1; left: 10px; top: 15px; position: relative; height: 75px; width: 495px" 
    BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
    CellPadding="3" GridLines="Horizontal" HorizontalAlign="Center">
    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
    <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" 
            SortExpression="ProductID" Visible="False" />
        <asp:BoundField DataField="ProductName" HeaderText="שם מוצר" ReadOnly="True" 
            SortExpression="ProductName" />
        <asp:BoundField DataField="Quantity" HeaderText="כמות" 
            SortExpression="Quantity" />
        <asp:BoundField DataField="Price" HeaderText="מחיר" ReadOnly="True" 
            SortExpression="Price" />
        <asp:TemplateField HeaderText="מחיר כולל" SortExpression="TotalPrice">
            <EditItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("TotalPrice") %>'></asp:Label>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:Label ID="LabelFooter" runat="server" Text="Label"></asp:Label>
            </FooterTemplate>
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("TotalPrice") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" />
        <asp:CommandField ShowDeleteButton="True" />
    </Columns>
    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
    <AlternatingRowStyle BackColor="#F7F7F7" />
</asp:GridView>

