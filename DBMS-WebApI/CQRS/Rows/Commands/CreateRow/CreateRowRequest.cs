using DBMS_WebApI.CQRS.Rows.Models;
using MediatR;

namespace DBMS_WebApI.CQRS.Rows.Commands.CreateRow
{
    public class CreateRowRequest : IRequest<RowModel>
    {
        public int DataBaseId { get; set; }
        public int TableId { get; set; }
    }
}
