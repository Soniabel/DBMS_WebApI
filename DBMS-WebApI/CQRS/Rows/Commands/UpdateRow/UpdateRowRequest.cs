using DBMS_WebApI.CQRS.Rows.Models;
using MediatR;

namespace DBMS_WebApI.CQRS.Rows.Commands.UpdateRow
{
    public class UpdateRowRequest : IRequest<RowModel>
    {
        public int Id { get; set; }
        public int TableId { get; set; }
    }
}
