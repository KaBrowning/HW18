using System;
using System.Web.UI;

using System.Data;

/// <summary>
/// This class describes the Order page
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public partial class Order : Page
{
    private Product _selectedProduct;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.ddlProducts.DataBind();

        this._selectedProduct = this.GetSelectedProduct();
        this.lblName.Text = this._selectedProduct.Name;
        this.lblShortDescription.Text = this._selectedProduct.ShortDescription;
        this.lblLongDescription.Text = this._selectedProduct.LongDescription;
        this.lblUnitPrice.Text = this._selectedProduct.UnitPrice.ToString("c");
        this.imgProduct.ImageUrl = "Images/Products/" + this._selectedProduct.ImageFile;
    }

    /// <summary>
    /// Gets the selected product.
    /// </summary>
    /// <returns></returns>
    private Product GetSelectedProduct()
    {
        var productsTable = (DataView)
            this.SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        if (productsTable == null)
            return null;

        productsTable.RowFilter =
            "ProductId = '" + this.ddlProducts.SelectedValue + "'";
        var row = productsTable[0];

        var selectedProduct = new Product(row["ProductId"].ToString(),
            row["Name"].ToString(),
            row["ShortDescription"].ToString(),
            row["LongDescription"].ToString(),
            (decimal)row["UnitPrice"],
            row["ImageFile"].ToString());

        return selectedProduct;
    }

    /// <summary>
    /// Handles the Click event of the btnAdd control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        var cart = CartItemList.GetCart();
        var cartItem = cart[this._selectedProduct.ProductId];
        if (cartItem == null)
        {
            cart.AddItem(this._selectedProduct, Convert.ToInt32(this.txtQuantity.Text));
        }
        else
        {
            cartItem.AddQuantity(Convert.ToInt32(this.txtQuantity.Text));
        }
        Response.Redirect("Cart.aspx");
    }
}
