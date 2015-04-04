<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckOut1.aspx.cs" Inherits="CheckOut1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Chapter 20: Halloween Store</title>
    <link href="Styles/Main.css" rel="stylesheet" type="text/css" />
    <link href="Styles/CheckOut1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <header>
        <img src="Images/banner.jpg" alt="Halloween Store" />
    </header>
    <section>
    <form id="form1" runat="server">
            <p>Please enter the following information:</p><br />
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" Width="150px" MaxLength="25" CssClass="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email is a required field." CssClass="validator"></asp:RequiredFieldValidator><br />
            <label>First name:</label>
            <asp:TextBox ID="txtFirstName" runat="server" Width="150px" MaxLength="20" CssClass="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstName"
                    ErrorMessage="First name is a required field." CssClass="validator"></asp:RequiredFieldValidator><br />
            <label>Last name:</label>
            <asp:TextBox ID="txtLastName" runat="server" Width="150px" MaxLength="20" CssClass="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastName"
                    ErrorMessage="Last name is a required field." CssClass="validator"></asp:RequiredFieldValidator><br />
            <label>Address:</label>
            <asp:TextBox ID="txtAddress" runat="server" Width="250px" MaxLength="40" CssClass="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress"
                    ErrorMessage="Address is a required field." CssClass="validator"></asp:RequiredFieldValidator><br />
            <label>City:</label>
            <asp:TextBox ID="txtCity" runat="server" Width="180px" MaxLength="30" CssClass="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                    ErrorMessage="City is a required field." CssClass="validator"></asp:RequiredFieldValidator><br />
            <label>State:</label>
            <asp:TextBox ID="txtState" runat="server" Width="25px" MaxLength="2" CssClass="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtState"
                    ErrorMessage="State is a required field." CssClass="validator"></asp:RequiredFieldValidator><br />
            <label>Zip code:</label>
            <asp:TextBox ID="txtZipCode" runat="server" Width="75px" MaxLength="9" CssClass="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtZipCode"
                    ErrorMessage="Zip code is a required field." CssClass="validator"></asp:RequiredFieldValidator><br />
            <label>Phone:</label>
            <asp:TextBox ID="txtPhone" runat="server" Width="150px" MaxLength="20" CssClass="entry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPhone"
                    Display="Dynamic" ErrorMessage="Phone is a required field." CssClass="validator"></asp:RequiredFieldValidator><br />
   
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:HalloweenConnectionString %>"
                DeleteCommand="DELETE FROM [Customers] WHERE [Email] = @original_Email"
                InsertCommand="INSERT INTO [Customers] ([Email], [LastName], [FirstName], [Address], [City], [State], [ZipCode], [PhoneNumber]) VALUES (@Email, @LastName, @FirstName, @Address, @City, @State, @ZipCode, @PhoneNumber)"
                SelectCommand="SELECT * FROM [Customers] WHERE ([Email] = @Email)"
                UpdateCommand="UPDATE [Customers] SET [LastName] = @LastName, [FirstName] = @FirstName, [Address] = @Address, [City] = @City, [State] = @State, [ZipCode] = @ZipCode, [PhoneNumber] = @PhoneNumber WHERE [Email] = @original_Email">
                <SelectParameters>
                    <asp:Parameter Name="Email" Type="String" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="original_Email" Type="String" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="ZipCode" Type="String" />
                    <asp:Parameter Name="PhoneNumber" Type="String" />
                    <asp:Parameter Name="original_Email" Type="String" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="City" Type="String" />
                    <asp:Parameter Name="State" Type="String" />
                    <asp:Parameter Name="ZipCode" Type="String" />
                    <asp:Parameter Name="PhoneNumber" Type="String" />
                </InsertParameters>
            </asp:SqlDataSource>
            <p id="buttons">
                <asp:Button ID="btnCheckOut" runat="server" Text="Continue Checkout" 
                    onclick="btnCheckOut_Click" CssClass="button" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel Order" 
                    CausesValidation="False" onclick="btnCancel_Click" CssClass="button" />
                <asp:Button ID="btnContinue" runat="server"
                    Text="Continue Shopping" CausesValidation="False" 
                    PostBackUrl="~/Order.aspx" CssClass="button" OnClick="btnContinue_Click" />
            </p>
    </form>
    </section>
</body>
</html>
