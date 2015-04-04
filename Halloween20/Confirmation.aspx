<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Confirmation.aspx.cs" Inherits="Confirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Chapter 20: Halloween Store</title>
    <link href="Styles/Main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <header>
        <img src="Images/banner.jpg" alt="Halloween Store" />
    </header>
    <section>
        <form id="form1" runat="server">
            <p>
                <asp:Label ID="lblConfirm" runat="server"></asp:Label><br /><br />
            </p>
            <p>
                <asp:Button ID="btnReturn" runat="server" Text="Return to Order Page" 
                    PostBackUrl="~/Order.aspx" CssClass="button" />
            </p>
        </form>
    </section>
</body>
</html>
