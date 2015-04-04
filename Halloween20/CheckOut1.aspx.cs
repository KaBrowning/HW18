using System;
using System.Web.UI;

using System.Data;

/// <summary>
/// This class describes the first Checkout page
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public partial class CheckOut1 : Page
{
    private DataView _dvCustomer = new DataView();

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Email"] == null)
        {
            if (IsPostBack)
            {
                this.SqlDataSource1.SelectParameters["Email"].DefaultValue
                    = this.txtEmail.Text;
                this._dvCustomer = (DataView)
                    this.SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                return;
            }
            this.txtEmail.Enabled = true;
            this.txtEmail.Focus();
            return;                     
        }

        if (!IsPostBack)
        {
            this.SqlDataSource1.SelectParameters["Email"].DefaultValue
                = Request.Cookies["Email"].Value;
            this._dvCustomer = (DataView)
                this.SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            Session["CustomerView"] = this._dvCustomer;
            if (this._dvCustomer == null)
                return;

            if (this._dvCustomer.Count == 1)
            {
                this.DisplayCustomerData();
                this.txtEmail.Enabled = false;
                this.txtFirstName.Focus();
            }
            else
            {
                this.txtEmail.Enabled = true;
                this.txtEmail.Text = Request.Cookies["Email"].Value;
                this.txtFirstName.Focus();
            }
        }
        else
        {
            this._dvCustomer = (DataView)Session["CustomerView"];
        }
    }

    /// <summary>
    /// Displays the customer data.
    /// </summary>
    private void DisplayCustomerData()
    {
        this.txtEmail.Text = this._dvCustomer[0]["Email"].ToString();
        this.txtFirstName.Text = this._dvCustomer[0]["FirstName"].ToString();
        this.txtLastName.Text = this._dvCustomer[0]["LastName"].ToString();
        this.txtAddress.Text = this._dvCustomer[0]["Address"].ToString();
        this.txtCity.Text = this._dvCustomer[0]["City"].ToString();
        this.txtState.Text = this._dvCustomer[0]["State"].ToString();
        this.txtZipCode.Text = this._dvCustomer[0]["ZipCode"].ToString();
        this.txtPhone.Text = this._dvCustomer[0]["PhoneNumber"].ToString();
    }

    /// <summary>
    /// Handles the Click event of the btnCheckOut control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        if (this._dvCustomer.Count == 0)
            this.AddCustomer();
        else
            if (this.CustomerModified())
                this.UpdateCustomer();
        Session["Email"] = this.txtEmail.Text;
        Response.Redirect("CheckOut2.aspx");
    }

    /// <summary>
    /// Adds the customer.
    /// </summary>
    private void AddCustomer()
    {
        this.SqlDataSource1.InsertParameters["Email"].DefaultValue
            = this.txtEmail.Text;
        this.SqlDataSource1.InsertParameters["FirstName"].DefaultValue
            = this.txtFirstName.Text;
        this.SqlDataSource1.InsertParameters["LastName"].DefaultValue
            = this.txtLastName.Text;
        this.SqlDataSource1.InsertParameters["Address"].DefaultValue
            = this.txtAddress.Text;
        this.SqlDataSource1.InsertParameters["City"].DefaultValue
            = this.txtCity.Text;
        this.SqlDataSource1.InsertParameters["State"].DefaultValue
            = this.txtState.Text;
        this.SqlDataSource1.InsertParameters["ZipCode"].DefaultValue
            = this.txtZipCode.Text;
        this.SqlDataSource1.InsertParameters["PhoneNumber"].DefaultValue
            = this.txtPhone.Text;
        this.SqlDataSource1.Insert();
    }

    /// <summary>
    /// Customers the modified.
    /// </summary>
    /// <returns></returns>
    private bool CustomerModified()
    {
        return this._dvCustomer[0]["FirstName"].ToString() != this.txtFirstName.Text ||
               this._dvCustomer[0]["LastName"].ToString() != this.txtLastName.Text ||
               this._dvCustomer[0]["Address"].ToString() != this.txtAddress.Text ||
               this._dvCustomer[0]["City"].ToString() != this.txtCity.Text ||
               this._dvCustomer[0]["State"].ToString() != this.txtState.Text ||
               this._dvCustomer[0]["ZipCode"].ToString() != this.txtZipCode.Text ||
               this._dvCustomer[0]["PhoneNumber"].ToString() != this.txtPhone.Text;
    }

    /// <summary>
    /// Updates the customer.
    /// </summary>
    private void UpdateCustomer()
    {
        this.SqlDataSource1.UpdateParameters["FirstName"].DefaultValue
            = this.txtFirstName.Text;
        this.SqlDataSource1.UpdateParameters["LastName"].DefaultValue
            = this.txtLastName.Text;
        this.SqlDataSource1.UpdateParameters["Address"].DefaultValue
            = this.txtAddress.Text;
        this.SqlDataSource1.UpdateParameters["City"].DefaultValue
            = this.txtCity.Text;
        this.SqlDataSource1.UpdateParameters["State"].DefaultValue
            = this.txtState.Text;
        this.SqlDataSource1.UpdateParameters["ZipCode"].DefaultValue
            = this.txtZipCode.Text;
        this.SqlDataSource1.UpdateParameters["PhoneNumber"].DefaultValue
            = this.txtPhone.Text;
        this.SqlDataSource1.UpdateParameters["original_Email"].DefaultValue
            = this.txtEmail.Text;
        this.SqlDataSource1.Update();
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
