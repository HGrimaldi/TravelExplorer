using Domain.Customers;
using Domain.DomainErrors;
using Domain.Primitives;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Create
{
    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Guid>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var phoneNumber = PhoneNumber.Create(command.PhoneNumber);
            var direccion = Direccion.Create(command.Country, command.Line1, command.Line2, command.City,
                command.State, command.ZipCode);

            if (phoneNumber is null || direccion is null || DUI.Create(command.DUI) is null)
                return Errors.Customer.InvalidData;

            var customer = new Customer(
                new CustomerId(Guid.NewGuid()),
                command.Nombre,
                command.DUI,
                command.Email,
                phoneNumber,
                direccion,
                true
            );

            _customerRepository.Add(customer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return customer.Id.Value;
        }
    }
}
