using Application.Customers.GetAll;
using Customers.Common;
using Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.GetAll
{
    internal sealed class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ErrorOr<IReadOnlyList<CustomerResponse>>>
    {
        private readonly ICustomerRepository _customerRepository;
        
        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }
        
        public async Task<ErrorOr<IReadOnlyList<CustomerResponse>>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
        {
            IReadOnlyList<Customer> customers = await _customerRepository.GetAll();

            return customers.Select(customer => new CustomerResponse(
                    customer.Id.Value,
                    customer.Nombre,
                    customer.DUI,
                    customer.Email,
                    customer.PhoneNumber.Value,
                    new AddressResponse(customer.Direccion.Country,
                        customer.Direccion.Line1,
                        customer.Direccion.Line2,
                        customer.Direccion.City,
                        customer.Direccion.State,
                        customer.Direccion.ZipCode),
                    customer.Active
                )).ToList();
        }
    }
}
