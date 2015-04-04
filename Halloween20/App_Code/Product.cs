using System;

/// <summary>
/// This class describes a Halloween Product
/// </summary>
/// <author>
/// Murach's ASP
/// </author>
/// <version>
/// Spring 2015
/// </version>
public class Product
{
    private string _productId;
    private string _name;
    private string _shortDescription;
    private string _longDescription;
    private decimal _unitPrice;
    private string _imageFile;

    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class.
    /// </summary>
    public Product()
    {
        
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <param name="name">The name.</param>
    /// <param name="shortDescription">The short description.</param>
    /// <param name="longDescription">The long description.</param>
    /// <param name="unitPrice">The unit price.</param>
    /// <param name="imageFile">The image file.</param>
    public Product(string productId, string name, string shortDescription,
        string longDescription, decimal unitPrice, string imageFile)
    {
        this.ProductId = productId;
        this.Name = name;
        this.ShortDescription = shortDescription;
        this.LongDescription = longDescription;
        this.UnitPrice = unitPrice;
        this.ImageFile = imageFile;
    }

    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    /// <value>
    /// The product identifier.
    /// </value>
    /// <exception cref="ArgumentException">Invalid product id</exception>
    public string ProductId
    {
        get
        {
            return this._productId;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Invalid product id");
            }
            this._productId = value;
        }
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    /// <exception cref="ArgumentException">Invalid product name</exception>
    public string Name
    {
        get
        {
            return this._name;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Invalid product name");
            }
            this._name = value;
        }
    }

    /// <summary>
    /// Gets or sets the short description.
    /// </summary>
    /// <value>
    /// The short description.
    /// </value>
    /// <exception cref="ArgumentException">Invalid product short description</exception>
    public string ShortDescription
    {
        get
        {
            return this._shortDescription;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Invalid product short description");
            }
            this._shortDescription = value;
        }
    }

    /// <summary>
    /// Gets or sets the long description.
    /// </summary>
    /// <value>
    /// The long description.
    /// </value>
    /// <exception cref="ArgumentException">Invalid product long description</exception>
    public string LongDescription
    {
        get
        {
            return this._longDescription;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Invalid product long description");
            }
            this._longDescription = value;
        }
    }

    /// <summary>
    /// Gets or sets the unit price.
    /// </summary>
    /// <value>
    /// The unit price.
    /// </value>
    /// <exception cref="ArgumentException">Invalid product price</exception>
    public decimal UnitPrice
    {
        get
        {
            return this._unitPrice;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid product price");
            }
            this._unitPrice = value;
        }
    }

    /// <summary>
    /// Gets or sets the image file.
    /// </summary>
    /// <value>
    /// The image file.
    /// </value>
    /// <exception cref="ArgumentException">Invalid product image</exception>
    public string ImageFile
    {
        get
        {
            return this._imageFile;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Invalid product image");
            }
            this._imageFile = value;
        }
    }
}