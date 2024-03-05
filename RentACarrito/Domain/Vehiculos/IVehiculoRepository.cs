namespace Domain.Vehiculos;

public interface IVehiculoRepository
{
    Task<Vehiculo?> GetByIdAsync(VehiculoId id);
    Task Add(Vehiculo vehiculo);
}