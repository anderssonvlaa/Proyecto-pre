namespace Domain.ValueObjects;

public partial record Address
{
    public Address(string departamento, string municipio, string distrito, string direccion)
    {
        Departamento = departamento;
        Municipio = municipio;
        Distrito =distrito;
        Direccion = direccion;
    }
    public string Departamento {get; init;}
    public string Municipio {get; init;}
    public string Distrito {get; init;}
    public string Direccion {get; init;}

    public static Address? Create(string departamento, string municipio, string distrito, string direccion)
    {
        if(string.IsNullOrEmpty(departamento) || string.IsNullOrEmpty(municipio) ||
        string.IsNullOrEmpty(distrito)|| string.IsNullOrEmpty(direccion))
        {
            return null;
        }
        return new Address(departamento,municipio,distrito,direccion);
    }
}