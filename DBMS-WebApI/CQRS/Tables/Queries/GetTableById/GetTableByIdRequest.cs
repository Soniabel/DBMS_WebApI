using DBMS_WebApI.CQRS.Tables.Models;
using MediatR;

namespace DBMS_WebApI.CQRS.Tables.Queries.GetTableById
{
    public class GetTableByIdRequest : IRequest<TableModel>
    {
        public int DataBaseId { get; set; }
        public int Id { get; set; }
    }
}
