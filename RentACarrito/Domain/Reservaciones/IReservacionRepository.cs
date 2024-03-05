namespace Domain.Reservaciones;

public interface IResercionRepository
{
    Task<Reservacion?> GetByIdAsinc(ReservacionId id);
    Task Add(Reservacion reservacion);

}