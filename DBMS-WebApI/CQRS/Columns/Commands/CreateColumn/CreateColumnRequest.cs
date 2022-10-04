using DBMS_WebApI.CQRS.Columns.Models;
using MediatR;

namespace DBMS_WebApI.CQRS.Columns.Commands.CreateColumn
{
    public class CreateColumnRequest : IRequest<ColumnModel>
    {
        public string Name { get; set; }
        public string TypeFullName { get; set; }
        public int TableId { get; set; }
    }
}
