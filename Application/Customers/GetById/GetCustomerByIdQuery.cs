using MediatR;
using Customers.Common;

namespace Application.Customers.GetById
{
    public record GetCustomerByIdQuery(Guid CustomerId) : IRequest<ErrorOr<CustomerResponse>>;
}
