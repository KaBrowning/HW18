<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Chapter 20: Halloween Store</title>
    <link href="Styles/Main.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Order.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <header>
        <img src="Images/banner.jpg" alt="Halloween Store" />
    </header>
    <section>
    <form id="form1" runat="server">
        <label>
        <asp:Menu ID="Menu1" runat="server" DataSourceID="smHalloween" ForeColor="#FF6600">
        </asp:Menu>
        <asp:SiteMapDataSource ID="smHalloween" runat="server" />
        <br />
        Please select a product&nbsp;</label>
        <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource1" DataTextField="Name" 
            DataValueField="ProductId">
        </asp:DropDownList><br />
        <div id="productData">
            <asp:Label ID="lblName" runat="server"></asp:Label>
            <asp:Label ID="lblShortDescription" runat="server"></asp:Label>
            <asp:Label ID="lblLongDescription" runat="server"></asp:Label>
            <asp:Label ID="lblUnitPrice" runat="server"></asp:Label>
            <label>Quantity&nbsp;</label>
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validator"
                    runat="server" ControlToValidate="txtQuantity" Display="Dynamic" 
                    ErrorMessage="Quantity is a required field."></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" CssClass="validator" 
                    ControlToValidate="txtQuantity" Display="Dynamic" 
                    ErrorMessage="Quantity must range from 1 to 500."
                    MaximumValue="500" MinimumValue="1" Type="Integer"></asp:RangeValidator><br />
            <asp:Button ID="btnAdd" runat="server" Text="Add to Cart" 
                onclick="btnAdd_Click" CssClass="button" />
            <asp:Button ID="btnCart" runat="server" Text="Go to Cart" 
                PostBackUrl="~/Cart.aspx" CausesValidation="False" CssClass="button" />
            <asp:Button ID="btnCheckOut" runat="server" Text="Check Out" 
                PostBackUrl="~/CheckOut1.aspx" CausesValidation="False" CssClass="button" />
        </div>
        <asp:Image ID="imgProduct" runat="server" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString='<%$ ConnectionStrings:HalloweenConnectionString %>' 
            SelectCommand="SELECT [ProductId], [Name], [ShortDescription], 
            [LongDescription], [ImageFile], [UnitPrice] FROM [Products] ORDER BY [Name]">
        </asp:SqlDataSource>
    </form>
    </section></body>
</html>
