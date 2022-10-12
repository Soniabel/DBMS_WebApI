using MediatR;

namespace DBMS_WebApI.CQRS.Rows.Commands.DeleteRow
{
    public class DeleteRowRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
