using Domain.Primitives;
using Domain.ValueObjects;
using Microsoft.Win32.SafeHandles;

namespace Domain.Reservaciones;

public sealed class Reservacion : AggregateRoot 
{
    public Reservacion(ReservacionId id, string name, string lastName, string email,PhoneNumber phoneNumber, string date)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Date = date;
    }

    private Reservacion()
    {

    }

    public ReservacionId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public PhoneNumber PhoneNumber { get; private set; }
    public string Date { get; private set; } 
}