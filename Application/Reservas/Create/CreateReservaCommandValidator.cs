using FluentValidation;
using Domain.Reservas;

namespace Application.Reservas.Create
{
    public class CreateReservaCommandValidator : AbstractValidator<CreateReservaCommand>
    {
        public CreateReservaCommandValidator()
        {
            RuleFor(r => r.NombreCliente)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(r => r.EmailCliente)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255);

            RuleFor(r => r.TelefonoCliente)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(r => r.FechaViaje)
                .NotEmpty()
                .GreaterThan(DateTime.Now);
        }
    }
}
