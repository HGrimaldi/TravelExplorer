namespace Application.Customers.Update
{
    public record UpdateCustomerCommand(
        Guid Id,
        string Nombre,
        string DUI,
        string Email,
        string PhoneNumber,
        string Country,
        string Line1,
        string Line2,
        string City,
        string State,
        string ZipCode,
        bool Active) : IRequest<ErrorOr<Unit>>;
}
