using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBMS_WebApI.Entities;
using DBMS_WebApI.CQRS.Rows.Models;
using DBMS_WebApI.CQRS.Rows.Queries.GetAllRows;
using DBMS_WebApI.CQRS.Rows.Commands.CreateRow;
using DBMS_WebApI.CQRS.Rows.Commands.DeleteRow;

namespace DBMS_WebApI.Controllers
{
    public class RowsController : ApiController
    {
        private readonly DataBaseContext _context;

        public RowsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RowsList))]
        public async Task<ActionResult> GetRows()
        {
            var result = await Mediator.Send(new GetRows());
            return Ok(result);
        }

        [Route("dataBases/{DataBaseId}/tables/{TableId}/row")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RowsList))]
        public async Task<IActionResult> CreateRow([FromBody] CreateRowRequest createRowRequest)
        {
            var result = await Mediator.Send(createRowRequest);
            return Ok(result);
        }

        [Route("dataBases/{DataBaseId}/tables/{TableId}/rows/{Id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RowsList))]
        public async Task<IActionResult> DeleteRow([FromQuery] DeleteRowRequest deleteRowRequest)
        {
            var result = await Mediator.Send(deleteRowRequest);
            return Ok(result);
        }

    }
}
