<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Expired.aspx.cs" Inherits="Expired" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chapter 20: Halloween Store</title>
    <link href="Styles/Main.css" rel="stylesheet" />
</head>
<body>
    <header><img src="Images/banner.jpg" alt="Halloween Store" /></header>
    <section>
        <form id="form1" runat="server">
            <asp:Menu ID="Menu1" runat="server" DataSourceID="smHalloween" ForeColor="#FF6600">
            </asp:Menu>
            <p>
                <asp:SiteMapDataSource ID="smHalloween" runat="server" />
                <br />
            </p>
            <p>The page you are trying to access has expired. To view an updated page, click the
               Refresh button below.
            </p><br />
            <p>
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" 
                    PostBackUrl="~/Cart.aspx" CssClass="button" />
            </p>
        </form>
    </section>
</body>
</html>
