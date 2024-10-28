using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesUsingEF.Entity;
using ServicesUsingEF.Models;
using ServicesUsingEF.Services;

namespace ServicesUsingEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService service)
        {
            customerService = service;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await customerService.GetAllCustomers();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, AddUpdateCustomer customer)
        {
            var cust = await customerService.UpdateCustomer(id,customer);
            if (cust == null)
            {
                return NotFound();
            }
            return Ok(cust);

        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(AddUpdateCustomer customer)
        {
            var cust = await customerService.AddCustomer(customer);
            if (cust == null)
            {
                return NotFound();
            }
            return Ok(cust);

        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var flag = await customerService.DeleteCustomer(id);
            if (flag)
                return Ok(new
                {
                    message = "Record Deleted"
                });
            return BadRequest();
        }

        
    }
}
