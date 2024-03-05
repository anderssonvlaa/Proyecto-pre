using System.Data;
using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using MediatR;

namespace Application.Customers.Create;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

 
    public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        if (PhoneNumber.Create(command.PhoneNumber)is not PhoneNumber phoneNumber)
        {
            throw new ArgumentException(nameof(phoneNumber));
        }

        if (DuiNumber.Create(command.DuiNumber)is not DuiNumber duiNumber)
        {
            throw new ArgumentException(nameof(duiNumber));
        }

        if(Address.Create(command.Departamento, command.Municipio, command.Distrito, command.Direccion)is not Address address)
        {
            throw new ArgumentException(nameof(address));
        }

        var customer = new Customer(
            new CustomerId(Guid.NewGuid()),
            command.Name,
            command.LastName,
            command.Email,
            duiNumber,
            phoneNumber,
            address,
            true
        );

        await _customerRepository.Add(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
 