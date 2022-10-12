using MediatR;
using DBMS_WebApI.CQRS.DataBases.Models;

namespace DBMS_WebApI.CQRS.DataBases.Commands.CreateDataBase
{
    public class CreateDataBaseRequest : IRequest<DataBaseModel>
    {
        public string Name { get; set; }
    }
}
