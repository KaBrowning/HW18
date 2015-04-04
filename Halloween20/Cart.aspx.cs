using System;

/// <summary>
/// This class describes the Cart page
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public partial class Cart : System.Web.UI.Page
{
    private CartItemList _cart;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        this._cart = CartItemList.GetCart();
        if (!IsPostBack)
            this.DisplayCart();
    }

    /// <summary>
    /// Displays the cart.
    /// </summary>
    private void DisplayCart()
    {
        this.lstCart.Items.Clear();
        for (var count = 0; count < this._cart.Count; count++)
        {
            var item = this._cart[count];
            this.lstCart.Items.Add(item.Display());
        }
    }

    /// <summary>
    /// Handles the Click event of the btnRemove control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (this._cart.Count <= 0)
            return;

        if (this.lstCart.SelectedIndex > -1)
        {
            this._cart.RemoveAt(this.lstCart.SelectedIndex);
            this.DisplayCart();
        }
        else
        {
            this.lblMessage.Text = "Please select the item you want to remove.";
        }
    }

    /// <summary>
    /// Handles the Click event of the btnEmpty control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnEmpty_Click(object sender, EventArgs e)
    {
        if (this._cart.Count <= 0)
            return;

        this._cart.Clear();
        this.lstCart.Items.Clear();
    }
}