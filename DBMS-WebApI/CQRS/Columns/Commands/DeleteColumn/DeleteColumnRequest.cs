using MediatR;

namespace DBMS_WebApI.CQRS.Columns.Commands.DeleteColumn
{
    public class DeleteColumnRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
