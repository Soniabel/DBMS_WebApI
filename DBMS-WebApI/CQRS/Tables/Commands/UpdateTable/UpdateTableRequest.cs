using DBMS_WebApI.CQRS.Tables.Models;
using MediatR;

namespace DBMS_WebApI.CQRS.Tables.Commands.UpdateTable
{
    public class UpdateTableRequest : IRequest<TableModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DataBaseId { get; set; }
    }
}
