using Microsoft.AspNetCore.Mvc;
using MediatR;
using DBMS_WebApI.CQRS.Tables.Models;
using DBMS_WebApI.CQRS.Tables.Queries.GetAllTables;
using DBMS_WebApI.CQRS.Tables.Queries.GetTableById;
using DBMS_WebApI.CQRS.Tables.Commands.UpdateTable;
using DBMS_WebApI.CQRS.Tables.Commands.CreateTable;
using DBMS_WebApI.CQRS.Tables.Commands.DeleteTable;

namespace DBMS_WebApI.Controllers
{
    public class TablesController : ApiController
    {
        public TablesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TablesList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetTables());
            return Ok(result);
        }

        [Route("dataBases/{DataBaseId}/tables/{Id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TablesList))]
        public async Task<IActionResult> GetById([FromQuery] GetTableByIdRequest getTableById)
        {
            var result = await Mediator.Send(getTableById);
            return Ok(result);
        }

        [Route("dataBases/{DataBaseId}/tables/{Id}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TablesList))]
        public async Task<IActionResult> UpdateTable([FromBody] UpdateTableRequest updateTableRequest)
        {
            var result = await Mediator.Send(updateTableRequest);
            return Ok(result);
        }

        [Route("dataBases/{DataBaseId}/table")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TablesList))]
        public async Task<IActionResult> CreateTable([FromBody] CreateTableRequest createTableRequest)
        {
            var result = await Mediator.Send(createTableRequest);
            return Ok(result);
        }

        [Route("dataBases/{DataBaseId}/tables/{Id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TablesList))]
        public async Task<IActionResult> DeleteTable([FromQuery] DeleteTableRequest deleteTableRequest)
        {
            var result = await Mediator.Send(deleteTableRequest);
            return Ok(result);
        }

    }
}
