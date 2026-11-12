using DalApi;
using DalFacade.Do;
using System.Xml.Linq;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        foreach (Customer? customer in DataSource.Customers)
        {
            if (customer != null &&
                customer.CustomerId == item.CustomerId)
            {
                throw new Exception("Customer with this name already exists");
            }
        }

        DataSource.Customers.Add(item);
        return item.CustomerId;
    }

    public Customer? Read(int id)
    {
        foreach (Customer? customer in DataSource.Customers)
        {
            if (customer != null && customer.CustomerId == id)
            {
                return customer;
            }
        }

        return null;
    }

    public List<Customer> ReadAll()
    {
        List<Customer> customers = new List<Customer>();

        foreach (Customer? customer in DataSource.Customers)
        {
            if (customer != null)
            {
                customers.Add(customer);
            }
        }

        return customers;
    }

    public void Update(Customer item)
    {
        Customer? customer = Read(item.CustomerId);

        if (customer == null)
        {
            throw new Exception("Not exists Customer with this name");
        }

        DataSource.Customers.Remove(customer);
        DataSource.Customers.Add(item);
    }

    public void Delete(int id)
    {
        Customer? customer = Read(id);

        if (customer == null)
        {
            throw new Exception("Not exists Customer with this name");
        }

        DataSource.Customers.Remove(customer);
    }
}