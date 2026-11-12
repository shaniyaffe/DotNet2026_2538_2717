using DalApi;
using DalFacade.Do;

namespace Dal;

internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        int id = DataSource.Config.NextProductId;

        Product product = item with { ProductId = id };

        DataSource.Products.Add(product);

        return id;
    }

    public Product? Read(int id)
    {
        foreach (Product? product in DataSource.Products)
        {
            if (product != null && product.ProductId == id)
            {
                return product;
            }
        }

        return null;
    }

    public List<Product> ReadAll()
    {
        List<Product> products = new List<Product>();

        foreach (Product? product in DataSource.Products)
        {
            if (product != null)
            {
                products.Add(product);
            }
        }

        return products;
    }

    public void Update(Product item)
    {
        Product? product = Read(item.ProductId);

        if (product == null)
        {
            throw new Exception("There is no product with this ID.");
        }

        DataSource.Products.Remove(product);
        DataSource.Products.Add(item);
    }

    public void Delete(int id)
    {
        Product? product = Read(id);

        if (product == null)
        {
            throw new Exception("There is no product with this ID.");
        }

        DataSource.Products.Remove(product);
    }
}