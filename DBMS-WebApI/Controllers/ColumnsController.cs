using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBMS_WebApI.Entities;
using DBMS_WebApI.CQRS.Columns.Models;
using DBMS_WebApI.CQRS.Columns.Queries.GetAllColumns;
using DBMS_WebApI.CQRS.Columns.Commands.CreateColumn;
using DBMS_WebApI.CQRS.Columns.Commands.DeleteColumn;

namespace DBMS_WebApI.Controllers
{
    public class ColumnsController : ApiController
    {
        private readonly DataBaseContext _context;

        public ColumnsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ColumnsList))]
        public async Task<ActionResult> GetColumns()
        {
            var result = await Mediator.Send(new GetColumns());
            return Ok(result);
        }

        [Route("dataBases/{DataBaseId}/tables/{TableId}/column")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ColumnsList))]
        public async Task<IActionResult> CreateColumn([FromBody] CreateColumnRequest createColumnRequest)
        {
            var result = await Mediator.Send(createColumnRequest);
            return Ok(result);
        }

        [Route("dataBases/{DataBaseId}/tables/{TableId}/columns/{Id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ColumnsList))]
        public async Task<IActionResult> DeleteColumn([FromQuery] DeleteColumnRequest deleteColumnRequest)
        {
            var result = await Mediator.Send(deleteColumnRequest);
            return Ok(result);
        }

    }
}
