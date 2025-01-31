namespace Application.Customers.Create
{
    public record CreateCustomerCommand(
        string Nombre,
        string DUI,
        string Email,
        string PhoneNumber,
        string Country,
        string Line1,
        string Line2,
        string City,
        string State,
        string ZipCode) : IRequest<ErrorOr<Guid>>;
}