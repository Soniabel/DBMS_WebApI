using DBMS_WebApI.CQRS.DataBases.Models;
using MediatR;

namespace DBMS_WebApI.CQRS.DataBases.Queries.GetDataBaseById
{
    public class GetDataBaseByIdRequest : IRequest<DataBaseModel>
    {
        public int Id { get; set; }
    }
}
