using MediatR;

namespace DBMS_WebApI.CQRS.Cells.Commands.DeleteCell
{
    public class DeleteCellRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
