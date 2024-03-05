using FluentValidation;

namespace Application.Destino.Create
{
    public class CreateDestinoCommandValidator : AbstractValidator<CreateDestinoCommand>
    {
        public CreateDestinoCommandValidator()
        {
            RuleFor(r => r.Nombre)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(r => r.Descripcion)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(r => r.Ubicacion)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
