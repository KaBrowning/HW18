using System;

/// <summary>
/// This class describes the Confirmation page
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public partial class Confirmation : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblConfirm.Text = "Thank you for your order. It will be shipped on " +
            DateTime.Today.AddDays(1).ToShortDateString() + ".";
    }
}