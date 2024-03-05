using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Reservas.Create;
using Application.Reservas.Update;
using Application.Reservas.GetById;
using Application.Reservas.Delete;
using Application.Reservas.GetAll;
using ErrorOr;
using MediatR;

namespace Web.API.Controllers
{
    [Route("reservas")] // Cambiar a la ruta correspondiente
    public class ReservasController : ApiController // Cambiar el nombre del controlador y la clase base
    {
        private readonly ISender _mediator;

        public ReservasController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservasResult = await _mediator.Send(new GetAllReservasQuery());

            return reservasResult.Match(
                reservas => Ok(reservas),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var reservaResult = await _mediator.Send(new GetReservaByIdQuery(id));

            return reservaResult.Match(
                reserva => Ok(reserva),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservaCommand command)
        {
            var createResult = await _mediator.Send(command);

            return createResult.Match(
                reservaId => Ok(reservaId),
                errors => Problem(errors)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReservaCommand command)
        {
            if (command.Id != id)
            {
                List<Error> errors = new()
                {
                    Error.Validation("Reserva.UpdateInvalid", "The request Id does not match with the url Id.")
                };
                return Problem(errors);
            }

            var updateResult = await _mediator.Send(command);

            return updateResult.Match(
                reservaId => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _mediator.Send(new DeleteReservaCommand(id));

            return deleteResult.Match(
                reservaId => NoContent(),
                errors => Problem(errors)
            );
        }
    }
}
