using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Destinos.Create;
using Application.Destinos.Update;
using Application.Destinos.GetById;
using Application.Destinos.Delete;
using Application.Destinos.GetAll;
using ErrorOr;
using MediatR;

namespace Web.API.Controllers
{
    [Route("destinos")] // Cambiar a la ruta correspondiente
    public class DestinosController : ApiController // Cambiar el nombre del controlador y la clase base
    {
        private readonly ISender _mediator;

        public DestinosController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var destinosResult = await _mediator.Send(new GetAllDestinosQuery());

            return destinosResult.Match(
                destinos => Ok(destinos),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var destinoResult = await _mediator.Send(new GetDestinoByIdQuery(id));

            return destinoResult.Match(
                destino => Ok(destino),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDestinoCommand command)
        {
            var createResult = await _mediator.Send(command);

            return createResult.Match(
                destinoId => Ok(destinoId),
                errors => Problem(errors)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDestinoCommand command)
        {
            if (command.Id != id)
            {
                List<Error> errors = new()
                {
                    Error.Validation("Destino.UpdateInvalid", "The request Id does not match with the url Id.")
                };
                return Problem(errors);
            }

            var updateResult = await _mediator.Send(command);

            return updateResult.Match(
                destinoId => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _mediator.Send(new DeleteDestinoCommand(id));

            return deleteResult.Match(
                destinoId => NoContent(),
                errors => Problem(errors)
            );
        }
    }
}
