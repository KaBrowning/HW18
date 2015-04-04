<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorTest.aspx.cs" Inherits="ErrorTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chapter 20: Halloween Store</title>
    <link href="Styles/Main.css" rel="stylesheet" type="text/css" />
    <link href="Styles/ErrorTest.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <header>
        <img src="Images/banner.jpg" alt="Halloween Store" />
    </header>
    <section>
     <form id="form1" runat="server">

    
         <asp:Button ID="btnException" runat="server" Text="Generate Exception" CssClass="button" />
         <br/>
         <br/>
         <br/>
         <asp:Button ID="btnBrokenLink" runat="server" Text="Broken Link" CssClass="button"/>
         

     </form>
    </section>
</body>
</html>
