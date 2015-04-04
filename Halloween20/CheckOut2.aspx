<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckOut2.aspx.cs" Inherits="CheckOut2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Chapter 20: Halloween Store</title>
    <link href="Styles/Main.css" rel="stylesheet" />
    <link href="Styles/CheckOut2.css" rel="stylesheet" />
</head>
<body>
    <header>
        <img src="Images/banner.jpg" alt="Halloween Store" />
    </header>
    <section>
        <form id="form1" runat="server">
            <h2>Shipping method:</h2>
            <asp:RadioButtonList ID="rblShipping" runat="server">
                <asp:ListItem Selected="True">UPS Ground</asp:ListItem>
                <asp:ListItem>UPS Second Day</asp:ListItem>
                <asp:ListItem>Federal Express Overnight</asp:ListItem>
            </asp:RadioButtonList>
            <h2>Payment information:</h2>
            <div id="payment">
                <asp:ListBox ID="lstCardType" runat="server" Width="155px" Rows="4">
                    <asp:ListItem Selected="True" Value="None">--Select a credit card--</asp:ListItem>
                    <asp:ListItem>VISA</asp:ListItem>
                    <asp:ListItem Value="MC">MasterCard</asp:ListItem>
                    <asp:ListItem Value="AMEX">American Express</asp:ListItem>
                </asp:ListBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lstCardType"
                    Display="Dynamic" ErrorMessage="You must select a credit card." InitialValue="None" CssClass="validator">
                </asp:RequiredFieldValidator><br /><br />
                
                <label>Card number:</label>
                <asp:TextBox ID="txtCardNumber" runat="server" MaxLength="20" Width="160px" CssClass="entry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCardNumber"
                        ErrorMessage="Credit card number is required." Display="Dynamic" CssClass="validator"></asp:RequiredFieldValidator><br />
                <label>Expiration date:</label>
                    <asp:DropDownList ID="ddlMonth" runat="server" Width="100px" CssClass="entry">
                        <asp:ListItem Value="1">January</asp:ListItem>
                        <asp:ListItem Value="2">February</asp:ListItem>
                        <asp:ListItem Value="3">March</asp:ListItem>
                        <asp:ListItem Value="4">April</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">June</asp:ListItem>
                        <asp:ListItem Value="7">July</asp:ListItem>
                        <asp:ListItem Value="8">August</asp:ListItem>
                        <asp:ListItem Value="9">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="1">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlYear" runat="server" Width="58px" CssClass="entry">
                    </asp:DropDownList><br />
            </div>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HalloweenConnectionString %>"
                 InsertCommand="INSERT INTO Invoices (CustEMail, OrderDate, Subtotal, ShipMethod, Shipping, SalesTax, Total, CreditCardType, CardNumber, ExpirationMonth, ExpirationYear) VALUES (@CustEMail, @OrderDate, @Subtotal, @ShipMethod, @Shipping, @SalesTax, @Total, @CreditCardType, @CardNumber, @ExpirationMonth, @ExpirationYear)">
                <InsertParameters>
                    <asp:Parameter Name="CustEMail" />
                    <asp:Parameter Name="OrderDate" />
                    <asp:Parameter Name="Subtotal" Type="Decimal"/>
                    <asp:Parameter Name="ShipMethod" />
                    <asp:Parameter Name="Shipping" Type="Decimal" />
                    <asp:Parameter Name="SalesTax" Type="Decimal" />
                    <asp:Parameter Name="Total" Type="Decimal" />
                    <asp:Parameter Name="CreditCardType" />
                    <asp:Parameter Name="CardNumber" />
                    <asp:Parameter Name="ExpirationMonth" Type="Int16" />
                    <asp:Parameter Name="ExpirationYear" Type="Int16" />
                </InsertParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HalloweenConnectionString %>"
                InsertCommand="INSERT INTO LineItems (InvoiceNumber, ProductId, UnitPrice, Quantity)
                               VALUES (@InvoiceNumber, @ProductId, @UnitPrice, @Quantity)">
                <InsertParameters>
                    <asp:Parameter Name="InvoiceNumber" />
                    <asp:Parameter Name="ProductId" />
                    <asp:Parameter Name="UnitPrice" Type="Decimal" />
                    <asp:Parameter Name="Quantity" Type="Int32" />
                </InsertParameters>
            </asp:SqlDataSource>
            <p id="buttons">
                <asp:Button ID="btnAccept" runat="server" Text="Accept Order" 
                    OnClick="btnAccept_Click" CssClass="button" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel Order" 
                    CausesValidation="False" onclick="btnCancel_Click" CssClass="button" />
                <asp:Button ID="btnContinue" runat="server" Text="Continue Shopping" 
                    PostBackUrl="~/Order.aspx" CausesValidation="False" CssClass="button" />
            </p>
        </form>
    </section>
</body>
</html>
