using System;

/// <summary>
/// This class describes a Halloween Cart Item
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public class CartItem
{
    private Product _theProduct;
    private int _theQuantity;

    /// <summary>
    /// Initializes a new instance of the <see cref="CartItem"/> class.
    /// </summary>
    public CartItem() {}

    /// <summary>
    /// Initializes a new instance of the <see cref="CartItem"/> class.
    /// </summary>
    /// <param name="product">The product.</param>
    /// <param name="quantity">The quantity.</param>
    public CartItem(Product product, int quantity)
    {
        this.Product = product;
        this.Quantity = quantity;
    }

    /// <summary>
    /// Gets or sets the product.
    /// </summary>
    /// <value>
    /// The product.
    /// </value>
    /// <exception cref="ArgumentException">Invalid product</exception>
    public Product Product
    {
        get
        {
            return this._theProduct;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Invalid product");
            }
            this._theProduct = value;
        }
    }

    /// <summary>
    /// Gets or sets the quantity.
    /// </summary>
    /// <value>
    /// The quantity.
    /// </value>
    /// <exception cref="ArgumentException">Invalid quantity</exception>
    public int Quantity
    {
        get
        {
            return this._theQuantity;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid quantity");
            }
            this._theQuantity = value;
        }
    }

    /// <summary>
    /// Adds the quantity.
    /// </summary>
    /// <param name="quantity">The quantity.</param>
    public void AddQuantity(int quantity)
    {
        this.Quantity += quantity;
    }

    /// <summary>
    /// Displays this instance.
    /// </summary>
    /// <returns></returns>
    public string Display()
    {
        var displayString =
            this.Product.Name + " (" + this.Quantity.ToString()
            + " at " + this.Product.UnitPrice.ToString("c") + " each)";

        return displayString;
    }
    
}