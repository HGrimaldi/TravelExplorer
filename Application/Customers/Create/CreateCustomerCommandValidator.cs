using FluentValidation;

namespace Application.Customers.Create
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(r => r.Nombre)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(r => r.DUI)
                .NotEmpty()
                .MaximumLength(9)
                .WithName("DUI");

            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255);

            RuleFor(r => r.PhoneNumber)
                .NotEmpty()
                .MaximumLength(9)
                .WithName("Phone Number");

            RuleFor(r => r.Country)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(r => r.Line1)
                .NotEmpty()
                .MaximumLength(30)
                .WithName("Addres Line 1");

            RuleFor(r => r.Line2)
                .MaximumLength(30)
                .WithName("Addres Line 2");

            RuleFor(r => r.City)
                .NotEmpty()
                .MaximumLength(40);

            RuleFor(r => r.State)
                .NotEmpty()
                .MaximumLength(40);

            RuleFor(r => r.ZipCode)
                .NotEmpty()
                .MaximumLength(10)
                .WithName("Zip Code");
        }
    }
}
