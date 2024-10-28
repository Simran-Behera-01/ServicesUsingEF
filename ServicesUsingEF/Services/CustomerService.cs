using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ServicesUsingEF.Entity;
using ServicesUsingEF.Models;

namespace ServicesUsingEF.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext dbContext;
        public CustomerService(CustomerDbContext context)
        {
            dbContext = context;
        }
        public async Task<Customer> AddCustomer(AddUpdateCustomer customer)
        {
            var cust = new Customer()
            {
                Name = customer.Name,
                Gender = customer.Gender,
                City = customer.City,
            };
            dbContext.Customers.Add(cust);
            await dbContext.SaveChangesAsync();
            return cust;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var cust = await dbContext.Customers.FirstOrDefaultAsync(cust => cust.Id == id);
            if (cust != null)
            {
                dbContext.Customers.Remove(cust);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await dbContext.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        }

        public async Task<Customer> UpdateCustomer(int id, AddUpdateCustomer customer)
        {
            var cust = await dbContext.Customers.FirstOrDefaultAsync(cust => cust.Id == id);
            if (cust != null)
            {
                cust.Name = customer.Name;
                cust.Gender = customer.Gender;
                cust.City = customer.City;
                await dbContext.SaveChangesAsync();
            }
            return cust;
        }
    }
}
