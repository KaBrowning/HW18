using System;

using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

/// <summary>
/// This class describes the second Checkout page
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public partial class CheckOut2 : System.Web.UI.Page
{
    private CartItemList _cart;
    private string _email;
    private string _invoiceNumber;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        this._cart = (CartItemList) Session["Cart"];
        this._email = (string)Session["Email"];
        if (!IsPostBack)
            this.LoadYears();
    }

    /// <summary>
    /// Loads the years.
    /// </summary>
    private void LoadYears()
    {
        var year = DateTime.Now.Year;
        for (var count = 0; count < 7; count++)
        {
            this.ddlYear.Items.Add(year.ToString());
            year += 1;
        }
    }

    /// <summary>
    /// Handles the Click event of the btnAccept control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        this.PutInvoice();
        this.GetInvoiceNumber();
        this.PutLineItems();
        Session.Remove("Cart");
        Response.Redirect("Confirmation.aspx");
    }

    /// <summary>
    /// Puts the invoice.
    /// </summary>
    private void PutInvoice()
    {
        this.SqlDataSource1.InsertParameters["CustEMail"].DefaultValue = this._email;
        this.SqlDataSource1.InsertParameters["OrderDate"].DefaultValue = DateTime.Today.ToString(new CultureInfo("en-US"));
        var quantity = this.Quantity();

        this.SqlDataSource1.InsertParameters["ShipMethod"].DefaultValue
            = this.rblShipping.SelectedValue;
        double shipping = 0;
        switch (this.rblShipping.SelectedValue)
        {
            case "UPS Ground":
                shipping = 3.95 + (quantity - 1) * 1.25;
                break;
            case "UPS Second Day":
                shipping = 7.95 + (quantity - 1) * 2.5;
                break;
            case "Federal Express Next Day":
                shipping = 19.95 + (quantity - 1) * 4.95;
                break;
        }
        this.SqlDataSource1.InsertParameters["Shipping"].DefaultValue
            = shipping.ToString(new CultureInfo("en-US"));

        var subTotal = this.SubTotal();
        this.SqlDataSource1.InsertParameters["Subtotal"].DefaultValue = subTotal.ToString(new CultureInfo("en-US"));
        var salesTax = subTotal * (decimal)0.075;
        this.SqlDataSource1.InsertParameters["SalesTax"].DefaultValue = salesTax.ToString(new CultureInfo("en-US"));
        var total = subTotal + salesTax;
        this.SqlDataSource1.InsertParameters["Total"].DefaultValue = total.ToString(new CultureInfo("en-US"));
        this.SqlDataSource1.InsertParameters["CreditCardType"].DefaultValue = this.lstCardType.SelectedValue;
        this.SqlDataSource1.InsertParameters["CardNumber"].DefaultValue = this.txtCardNumber.Text;
        this.SqlDataSource1.InsertParameters["ExpirationMonth"].DefaultValue = this.ddlMonth.SelectedValue;
        this.SqlDataSource1.InsertParameters["ExpirationYear"].DefaultValue = this.ddlYear.SelectedValue;
        this.SqlDataSource1.Insert();
    }

    /// <summary>
    /// Quantities this instance.
    /// </summary>
    /// <returns></returns>
    private int Quantity()
    {
        var quantity = 0;
        for (var count = 0; count < this._cart.Count; count++)
        {
            var cartItem = this._cart[count];
            quantity += cartItem.Quantity;
        }
        return quantity;
    }

    /// <summary>
    /// Subs the total.
    /// </summary>
    /// <returns></returns>
    private decimal SubTotal()
    {
        decimal subTotal = 0;
        for (var count = 0; count < this._cart.Count; count++)
        {
            var cartItem = this._cart[count];
            subTotal += cartItem.Quantity * cartItem.Product.UnitPrice;
        }
        return subTotal;
    }

    /// <summary>
    /// Gets the invoice number.
    /// </summary>
    private void GetInvoiceNumber()
    {
        var conString = ConfigurationManager.ConnectionStrings[
            "HalloweenConnectionString"].ConnectionString;
        var conHalloween =
            new SqlConnection(conString);
        var invoiceNoCommand = 
            new SqlCommand("Select Ident_Current('Invoices') From Invoices", conHalloween);
        conHalloween.Open();
        this._invoiceNumber = invoiceNoCommand.ExecuteScalar().ToString();
        conHalloween.Close();
    }

    /// <summary>
    /// Puts the line items.
    /// </summary>
    private void PutLineItems()
    {
        for (var count = 0; count < this._cart.Count; count++)
        {
            var cartItem = this._cart[count];
            this.SqlDataSource2.InsertParameters["InvoiceNumber"].DefaultValue = this._invoiceNumber;
            this.SqlDataSource2.InsertParameters["ProductId"].DefaultValue = cartItem.Product.ProductId;
            this.SqlDataSource2.InsertParameters["UnitPrice"].DefaultValue = cartItem.Product.UnitPrice.ToString(new CultureInfo("en-US"));
            this.SqlDataSource2.InsertParameters["Quantity"].DefaultValue = cartItem.Quantity.ToString();
            this.SqlDataSource2.Insert();
        }
    }

    /// <summary>
    /// Handles the Click event of the btnCancel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session.Remove("Cart");
        Response.Redirect("Order.aspx");
    }

}
