using DBMS_WebApI.CQRS.DataBases.Models;
using MediatR;

namespace DBMS_WebApI.CQRS.DataBases.Commands.UpdateDataBase
{
    public class UpdateDataBaseRequest : IRequest<DataBaseModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
