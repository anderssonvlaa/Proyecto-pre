using Domain.Primitives;
using Domain.Reservaciones;
using Domain.ValueObjects;
using MediatR;

namespace Application.Reservaciones.Create;

public sealed class CreateReservacionCommandHandler : IRequestHandler<CreateReservationCommand, Unit>
{
    private readonly IReservacionRepository _reservacionRepository;
    private readonly IUnitOfWork _unitOfWork;
     public CreateReservacionCommandHandler(IReservacionRepository reservacionRepository, IUnitOfWork unitOfWork)
    {
        _reservacionRepository = reservacionRepository?? throw new ArgumentNullException(nameof(reservacionRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<Unit> Handle(CreateReservationCommand command, CancellationToken cancellationToken)
    {
        if (PhoneNumber.Create(command.PhoneNumber)is not PhoneNumber phoneNumber)
        {
            throw new ArgumentException(nameof(phoneNumber));
        }

        var reservacion = new Reservacion(
            new ReservacionId(Guid.NewGuid()),
            command.Name,
            command.LastName,
            command.Email,
            phoneNumber,
            command.Date
        );

        await _reservacionRepository.Add(reservacion);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}