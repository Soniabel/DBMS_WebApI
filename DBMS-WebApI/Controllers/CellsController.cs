using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBMS_WebApI.Entities;
using MediatR;
using DBMS_WebApI.CQRS.Cells.Models;
using DBMS_WebApI.CQRS.Cells.Queries.GetAllCells;
using DBMS_WebApI.CQRS.Cells.Commands.CreateCell;
using DBMS_WebApI.CQRS.Cells.Commands.DeleteCell;

namespace DBMS_WebApI.Controllers
{
    public class CellsController : ApiController
    {
        public CellsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CellsList))]
        public async Task<ActionResult> GetCells()
        {
            var result = await Mediator.Send(new GetCells());
            return Ok(result);
        }

        [Route("dataBases/{DataBaseId}/tables/{TableId}/columns/{ColumnId}/rows/{RowId}/cell")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CellsList))]
        public async Task<ActionResult> CreateCell([FromBody] CreateCellRequest createCellRequest)
        {
            var result = await Mediator.Send(createCellRequest);
            return Ok(result);
        }

        [Route("dataBases/{DataBaseId}/tables/{TableId}/columns/{ColumnId}/rows/{RowId}/cells/{Id}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CellsList))]
        public async Task<IActionResult> DeleteCell([FromQuery] DeleteCellRequest deleteCellRequest)
        {
            var result = await Mediator.Send(deleteCellRequest);
            return Ok(result);
        }
    }
}
