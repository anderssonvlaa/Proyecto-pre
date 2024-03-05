using Domain.Primitives;

namespace Domain.Vehiculos;

public sealed class Vehiculo : AggregateRoot
{
    public Vehiculo(VehiculoId id, string plates, string brand, string model, int year, string price){
        Id = id;
        Plates = plates;
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
    }
    private Vehiculo(){

    }
    public VehiculoId Id {get; private set;}
    public string Plates { get; private set; } = string.Empty;
    public string Brand { get; private set; } = string.Empty;
    public string Model { get; private set; } = string.Empty;
    public int Year { get; private set; } 
    public string Price { get; private set; } = string.Empty;
}