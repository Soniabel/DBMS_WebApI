using MediatR;
using DBMS_WebApI.CQRS.Tables.Models;

namespace DBMS_WebApI.CQRS.Tables.Commands.CreateTable
{
    public class CreateTableRequest : IRequest<TableModel>
    {
        public int DataBaseId { get; set; }
        public string Name { get; set; }
    }
}
