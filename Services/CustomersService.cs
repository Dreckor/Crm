using CRM.Models;
namespace CRM.Services;

public class CustomersService : ICustomersService
{
    CRMContext customerContext;
    public CustomersService(CRMContext customerContext)
    {
        this.customerContext = customerContext;
    }
    public IEnumerable<Customer> Get()
    {
        
        return customerContext.Customers;
    }

    public async Task Add(Customer customer)
    {
        customerContext.Add(customer);
        await customerContext.SaveChangesAsync();
    }

    public async Task Update(int id, Customer customer)
    {
        var currentSeller = customerContext.Customers.Find(id);
        if(currentSeller != null){
            currentSeller.CustomerName = customer.CustomerName;
            await customerContext.SaveChangesAsync();
        }
        
    }

    public async Task Delete(int id)
    {
        var currentSeller = customerContext.Sellers.Find(id);
        if(currentSeller != null){
            customerContext.Remove(currentSeller);
            await customerContext.SaveChangesAsync();
        }
   
    }
    public async Task CreateTable()
    {
        customerContext.Database.EnsureCreated();
        
    }
}

public interface ICustomersService
{
    IEnumerable<Customer> Get();
    Task Add(Customer customer);
    Task Update(int id, Customer customer);
    Task Delete(int id);
    Task CreateTable();
}