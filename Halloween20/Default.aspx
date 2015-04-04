<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

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
            <asp:Menu ID="Menu1" runat="server" DataSourceID="smHalloween" ForeColor="#FF6600">
            </asp:Menu>
            <asp:SiteMapDataSource ID="smHalloween" runat="server" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="#FF6600" Text="Chapter 20 Exercises"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnOrder" runat="server" PostBackUrl="~/Order.aspx" Text="Order Products" Width="150px" Height="35px" />
            <br />
            <br />
            <asp:Button ID="btnTestError" runat="server" Text="Test Error Pages" Width="150px" Height="35px" />
        </form>
    </section>

</body>
</html>