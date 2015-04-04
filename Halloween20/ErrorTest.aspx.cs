using System;


/// <summary>
/// This class describes the Error Test page
/// </summary>
/// <author>Kathryn Browning</author>
/// <version>April 4, 2015</version>
public partial class ErrorTest : System.Web.UI.Page
{
    /// <summary>
    /// Handles the Click event of the btnException control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <exception cref="Exception">This is a planned Exception</exception>
    protected void btnException_Click(object sender, EventArgs e)
    {
        try
        {
            throw new Exception("This is a planned Exception");
        }
        catch (Exception ex)
        {
            Session.Add("Exception", ex);
            Response.Redirect("Error.aspx");
        }
    }

    /// <summary>
    /// Handles the Click event of the btnBrokenLink control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnBrokenLink_Click(object sender, EventArgs e)
    {
        Response.Redirect("UnknownPage.aspx");
    }
}