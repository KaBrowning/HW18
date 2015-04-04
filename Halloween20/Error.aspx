<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ch20: Halloween Store</title>
    <link href="Styles/Main.css" rel="stylesheet" />
</head>
<body>
    <header><img src="Images/banner.jpg" alt="Halloween Store" /></header>
    <section>
        <form id="form1" runat="server">
            <h1>An error has occurred</h1>
            <p><asp:Label ID="lblOutputMessage" runat="server" CssClass="error"></asp:Label></p><br />
            <p><asp:Button ID="btnReturn" runat="server" Text="Return to Order Page" 
                PostBackUrl="~/Order.aspx" CssClass="button" /></p>
        </form>
    </section>
</body>
</html>
