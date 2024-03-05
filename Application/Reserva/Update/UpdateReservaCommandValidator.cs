using FluentValidation;

namespace Application.Reserva.Update
{
    public class UpdateReservaCommandValidator : AbstractValidator<UpdateReservaCommand>
    {
        public UpdateReservaCommandValidator()
        {
            RuleFor(r => r.Nombre)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255);

            RuleFor(r => r.NumeroTelefono)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(r => r.FechaInicio)
                .NotEmpty()
                .GreaterThan(DateTime.Now);

            RuleFor(r => r.FechaFin)
                .NotEmpty()
                .GreaterThan(r => r.FechaInicio);
        }
    }
}
