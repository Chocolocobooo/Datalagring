using Business.Models;
using Data.Repositories;
using Business.Factories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class CustomerService(CustomerRepository customerRepostiory, DataContext context)
{
    private readonly CustomerRepository _customerRepostiory = customerRepostiory;
    private readonly DataContext _context = context;

    public async Task CreateCustomerAsync(CustomerRegistrationForm form)
    {
        var customerEntity = CustomerFactory.Create(form);
        await _customerRepostiory.CreateAsync(customerEntity!);
    }

    public async Task<IEnumerable<Customer?>> GetCustomersAsync()
    {
        var customerEntities = await _customerRepostiory.GetAsync();
        return customerEntities.Select(CustomerFactory.Create);
    }

    public async Task<Customer?> GetCostumerByIdAsync(int id)
    {
        var customerEntity = await _customerRepostiory.GetAsync(x => x.Id == id);
        return CustomerFactory.Create(customerEntity!);
    }

    public async Task<Customer?> GetCostumerByCustomerNameAsync(string customerName)
    {
        var customerEntity = await _customerRepostiory.GetAsync(x => x.CustomerName == customerName);
        return CustomerFactory.Create(customerEntity!);
    }

    public async Task<bool> UpdateCustomerAsync(Customer customer)
    {
        var existingCustomer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerName == customer.CustomerName);
        if (customer != null)
        {
            _context.Customers.Update(existingCustomer);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {

        var customerEntity = await _customerRepostiory.GetAsync(x => x.Id == id);
        if (customerEntity != null)
        {
            await _customerRepostiory.DeleteAsync(customerEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
