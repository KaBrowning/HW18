using System.Collections.Generic;
using System.Web;

/// <summary>
/// This class describes a Halloween Cart Item List
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public class CartItemList
{
    private readonly List<CartItem> _cartItems;

    /// <summary>
    /// Initializes a new instance of the <see cref="CartItemList"/> class.
    /// </summary>
    public CartItemList()
    {
        this._cartItems = new List<CartItem>();
    }

    /// <summary>
    /// Gets the count.
    /// </summary>
    /// <value>
    /// The count.
    /// </value>
    public int Count {
        get { return this._cartItems.Count; }
    }

    /// <summary>
    /// Gets or sets the <see cref="CartItem"/> at the specified index.
    /// </summary>
    /// <value>
    /// The <see cref="CartItem"/>.
    /// </value>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    public CartItem this[int index]
    {
        get { return this._cartItems[index]; }
        set { this._cartItems[index] = value; }
    }

    /// <summary>
    /// Gets the <see cref="CartItem"/> with the specified identifier.
    /// </summary>
    /// <value>
    /// The <see cref="CartItem"/>.
    /// </value>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public CartItem this[string id]
    {
        get {
            foreach (var c in this._cartItems)
                if (c.Product.ProductId == id) return c;
            return null;
        }
    }

    /// <summary>
    /// Gets the cart.
    /// </summary>
    /// <returns></returns>
    public static CartItemList GetCart()
    {
        var cart = (CartItemList) HttpContext.Current.Session["Cart"];
        if (cart == null)
            HttpContext.Current.Session["Cart"] = new CartItemList();
        return (CartItemList) HttpContext.Current.Session["Cart"];
    }

    /// <summary>
    /// Adds the item.
    /// </summary>
    /// <param name="product">The product.</param>
    /// <param name="quantity">The quantity.</param>
    public void AddItem(Product product, int quantity)
    {
        var c = new CartItem(product, quantity);
        this._cartItems.Add(c);
    }

    /// <summary>
    /// Removes at.
    /// </summary>
    /// <param name="index">The index.</param>
    public void RemoveAt(int index)
    {
        this._cartItems.RemoveAt(index);
    }

    /// <summary>
    /// Clears this instance.
    /// </summary>
    public void Clear()
    {
        this._cartItems.Clear();
    }
}