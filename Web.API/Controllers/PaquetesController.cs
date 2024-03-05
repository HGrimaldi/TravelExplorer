using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Paquetes.Create;
using Application.Paquetes.Update;
using Application.Paquetes.GetById;
using Application.Paquetes.Delete;
using Application.Paquetes.GetAll;
using ErrorOr;
using MediatR;

namespace Web.API.Controllers
{
    [Route("paquetes")] // Cambiar a la ruta correspondiente
    public class PaquetesController : ApiController // Cambiar el nombre del controlador y la clase base
    {
        private readonly ISender _mediator;

        public PaquetesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var paquetesResult = await _mediator.Send(new GetAllPaquetesQuery());

            return paquetesResult.Match(
                paquetes => Ok(paquetes),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var paqueteResult = await _mediator.Send(new GetPaqueteByIdQuery(id));

            return paqueteResult.Match(
                paquete => Ok(paquete),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaqueteCommand command)
        {
            var createResult = await _mediator.Send(command);

            return createResult.Match(
                paqueteId => Ok(paqueteId),
                errors => Problem(errors)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePaqueteCommand command)
        {
            if (command.Id != id)
            {
                List<Error> errors = new()
                {
                    Error.Validation("Paquete.UpdateInvalid", "The request Id does not match with the url Id.")
                };
                return Problem(errors);
            }

            var updateResult = await _mediator.Send(command);

            return updateResult.Match(
                paqueteId => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _mediator.Send(new DeletePaqueteCommand(id));

            return deleteResult.Match(
                paqueteId => NoContent(),
                errors => Problem(errors)
            );
        }
    }
}
