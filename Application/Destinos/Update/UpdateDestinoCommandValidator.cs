using FluentValidation;

namespace Application.Destinos.Update
{
    public class UpdateDestinoCommandValidator : AbstractValidator<UpdateDestinoCommand>
    {
        public UpdateDestinoCommandValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();

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
