using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Insfraestructure.Persistance.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
    }

    public async Task Add(Customer customer) => await _context.Customers.AddAsync(customer);
 
    public async Task<Customer?> GetByIdAsync(CustomerId id) => await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
}
