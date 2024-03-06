using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Domain.Customers;
using Customers.Common;

namespace Application.Customers.GetById
{
    internal sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, ErrorOr<CustomerResponse>>
    {
        private readonly ICustomerRepository _customerRepository;
        
        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }
        
        public async Task<ErrorOr<CustomerResponse>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _customerRepository.GetByIdAsync(new CustomerId(query.CustomerId)) is not Customer customer)
            {
                return Error.NotFound("Customer.NotFound", "The customer with the provided Id was not found.");
            }

            return new CustomerResponse(
                customer.Id.Value, 
                customer.Nombre, 
                customer.DUI, 
                customer.Email, 
                customer.PhoneNumber.Value, 
                new AddressResponse(
                    customer.Direccion.Country,
                    customer.Direccion.Line1,
                    customer.Direccion.Line2,
                    customer.Direccion.City,
                    customer.Direccion.State,
                    customer.Direccion.ZipCode
                ),
                customer.Active
            );
        }
    }
}