using System;

/// <summary>
/// This class describes the Custom Error page
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public partial class Error : System.Web.UI.Page
{

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        var ex = (Exception) Session["Exception"];

        if (ex != null)
        {
            this.lblOutputMessage.Text = ex.Message;
        }
    }
}
