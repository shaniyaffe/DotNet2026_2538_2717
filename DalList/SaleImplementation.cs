using DalApi;
using DalFacade.Do;

namespace Dal;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        int id = DataSource.Config.NextSaleId;

        Sale sale = item with { SaleId = id };

        DataSource.Sales.Add(sale);

        return id;
    }

    public Sale? Read(int id)
    {
        foreach (Sale? sale in DataSource.Sales)
        {
            if (sale != null && sale.SaleId == id)
            {
                return sale;
            }
        }

        return null;
    }

    public List<Sale> ReadAll()
    {
        List<Sale> sales = new List<Sale>();

        foreach (Sale? sale in DataSource.Sales)
        {
            if (sale != null)
            {
                sales.Add(sale);
            }
        }

        return sales;
    }

    public void Update(Sale item)
    {
        Sale? sale = Read(item.SaleId);

        if (sale == null)
        {
            throw new Exception("There is no sale with this ID.");
        }

        DataSource.Sales.Remove(sale);
        DataSource.Sales.Add(item);
    }

    public void Delete(int id)
    {
        Sale? sale = Read(id);

        if (sale == null)
        {
            throw new Exception("There is no sale with this ID.");
        }

        DataSource.Sales.Remove(sale);
    }
}