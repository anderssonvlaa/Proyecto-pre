namespace Domain.Reservaciones;

public interface IReservacionRepository
{
    Task<Reservacion?> GetByIdAsinc(ReservacionId id);
    Task Add(Reservacion reservacion);

}