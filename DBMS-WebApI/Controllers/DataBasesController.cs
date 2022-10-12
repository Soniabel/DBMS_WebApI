using Microsoft.AspNetCore.Mvc;
using MediatR;
using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.CQRS.DataBases.Queries.GetAllDataBases;
using DBMS_WebApI.CQRS.DataBases.Queries.GetDataBaseById;
using DBMS_WebApI.CQRS.DataBases.Commands.UpdateDataBase;
using DBMS_WebApI.CQRS.DataBases.Commands.CreateDataBase;
using DBMS_WebApI.CQRS.DataBases.Commands.DeleteDataBase;

namespace DBMS_WebApI.Controllers
{
    public class DataBasesController : ApiController
    {
        public DataBasesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataBaseList))]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetDataBases());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataBaseList))]
        public async Task<IActionResult> GetById([FromQuery] GetDataBaseByIdRequest getDataBaseById)
        {
            var result = await Mediator.Send(getDataBaseById);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataBaseList))]
        public async Task<IActionResult> UpdateDataBase([FromBody] UpdateDataBaseRequest updateDataBaseRequest)
        {
            var result = await Mediator.Send(updateDataBaseRequest);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DataBaseList))]
        public async Task<IActionResult> CreateDataBase([FromBody] CreateDataBaseRequest createDataBaseRequest)
        {
            var result = await Mediator.Send(createDataBaseRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataBaseList))]
        public async Task<IActionResult> DeleteDataBase([FromQuery] DeleteDataBaseRequest deleteDataBaseRequest)
        {
            var result = await Mediator.Send(deleteDataBaseRequest);
            return Ok(result);
        }

    }
}
