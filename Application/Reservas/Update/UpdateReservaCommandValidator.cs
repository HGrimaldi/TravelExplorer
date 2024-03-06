using FluentValidation;

namespace Application.Reservas.Update
{
    public class UpdateReservaCommandValidator : AbstractValidator<UpdateReservaCommand>
    {
        public UpdateReservaCommandValidator()
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
