using Application.Common;
using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Update
{
    internal sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ErrorOr<Unit>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        
        public async Task<ErrorOr<Unit>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            if (!await _customerRepository.ExistsAsync(new CustomerId(command.Id)))
            {
                return Error.NotFound("Customer.NotFound", "The customer with the provided Id was not found.");
            }

            if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
            {
                return Error.Validation("Customer.PhoneNumber", "Phone number has not valid format.");
            }

            if (Direccion.Create(command.Country, command.Line1, command.Line2, command.City,
                        command.State, command.ZipCode) is not Direccion direccion)
            {
                return Error.Validation("Customer.Address", "Address is not valid.");
            }

            Customer customer = await _customerRepository.GetByIdAsync(new CustomerId(command.Id));
            customer.Update(
                command.Nombre,
                command.DUI,
                command.Email,
                phoneNumber,
                direccion,
                command.Active
            );

            _customerRepository.Update(customer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
