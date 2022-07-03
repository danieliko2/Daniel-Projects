<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControlDataList.ascx.cs" Inherits="WebUserControlDataList" %>
    <%@ Register src="WebUserControlShoppingBag.ascx" tagname="WebUserControlShoppingBag" tagprefix="uc1" %>
    <p>
        &nbsp;</p>
<uc1:WebUserControlShoppingBag ID="WebUserControlShoppingBag1" runat="server" />
<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonConfirm" runat="server" onclick="ButtonConfirm_Click" 
            Text="בצע קניה" />
        </p>
    <asp:DataList ID="DataListProductSelected" runat="server" BorderColor="#CCCCCC" 
        BorderWidth="1px" CellPadding="1" CellSpacing="1" DataKeyField="ProductID" 
        DataSourceID="ObjectDataSourceProductsSelected" Font-Bold="False" Font-Italic="False" 
        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
        GridLines="Both" HorizontalAlign="Center"  RepeatColumns="3" 
    onitemcommand="DataLstProductSelected_ItemCommand">
        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
            Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" Height="200px" 
                    ImageUrl='<%# Bind("ImageURL") %>' Width="200px" />
            <br />
            <asp:Button ID="ButtonProduct" runat="server" 
                Text='<%# Bind("ProductName") %>' onclick="ButtonProduct_Click" />
            <br />
            <asp:Label ID="LabelProductDetails" runat="server" 
                Text='<%# Bind("Description") %>'></asp:Label>
            <asp:Label ID="LabelProductID" runat="server" Text='<%# Bind("ProductID") %>' 
                Visible="False"></asp:Label>
            <br />
            <asp:ImageButton ID="ImageButtonAddToCart" runat="server" Height="16px" 
                ImageUrl="~/Pics/product_add_to_cart.gif" 
                onclick="ImageButtonAddToCart_Click" />
            &nbsp;<asp:Label ID="LabelPrice" runat="server" Font-Bold="True" ForeColor="Red" 
                Text='<%# Bind("Price") %>'></asp:Label>
            &nbsp;מחיר
            <br />
            <asp:LinkButton ID="LinkButtonEdit" runat="server" Visible="False">ערוך מוצר</asp:LinkButton>
        </ItemTemplate>
    </asp:DataList>
    <br />
<br />
    <br />
        <br />
    <asp:ObjectDataSource ID="ObjectDataSourceProductsSelected" runat="server" 
        SelectMethod="GetProductByKindID" TypeName="localhostService.Service" 
    onselecting="ObjectDataSourceProductsSelected_Selecting">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="KindID" 
                SessionField="ProductsKindID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

<asp:ObjectDataSource ID="ObjectDataSourceAllProducts" runat="server" 
    SelectMethod="GetAllProducts" TypeName="localhostService.Service">
</asp:ObjectDataSource>


