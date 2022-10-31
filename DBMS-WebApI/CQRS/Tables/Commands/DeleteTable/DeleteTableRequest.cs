using MediatR;

namespace DBMS_WebApI.CQRS.Tables.Commands.DeleteTable
{
    public class DeleteTableRequest: IRequest<int>
    {
        public int Id { get; set; }
        public int DataBaseId { get; set; }
    }
}
