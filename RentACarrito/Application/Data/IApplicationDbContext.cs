using Domain.Customers;
using Domain.Reservaciones;
using Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers {get; set;}
    DbSet<Vehiculo> Vehiculos {get; set;}
    DbSet<Reservacion> Reservaciones {get; set;}

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}