using FluentValidation;

namespace Application.Paquete.Create
{
    public class CreatePaqueteCommandValidator : AbstractValidator<CreatePaqueteCommand>
    {
        public CreatePaqueteCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty()
                .MaximumLength(255);
            
            RuleFor(p => p.Descripcion)
                .NotEmpty();

            RuleFor(p => p.FechaInicio)
                .NotEmpty()
                .GreaterThan(DateTime.Now);

            RuleFor(p => p.FechaFin)
                .NotEmpty()
                .GreaterThan(p => p.FechaInicio);

            RuleFor(p => p.Precio)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.DestinosIds)
                .NotEmpty();
        }
    }
}
