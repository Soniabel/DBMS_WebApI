using DBMS_WebApI.CQRS.Columns.Models;
using MediatR;

namespace DBMS_WebApI.CQRS.Columns.Commands.UpdateColumn
{
    public class UpdateColumnRequest : IRequest<ColumnModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeFullName { get; set; }
        public int TableId { get; set; }
    }
}
