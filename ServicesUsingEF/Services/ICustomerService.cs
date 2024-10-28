using ServicesUsingEF.Models;

namespace ServicesUsingEF.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> AddCustomer(AddUpdateCustomer customer);
        Task<Customer> UpdateCustomer(int id, AddUpdateCustomer customer);
        Task<bool> DeleteCustomer(int id);
    }
}
