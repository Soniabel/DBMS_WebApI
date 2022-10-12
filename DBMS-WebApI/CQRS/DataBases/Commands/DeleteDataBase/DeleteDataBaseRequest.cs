using MediatR;

namespace DBMS_WebApI.CQRS.DataBases.Commands.DeleteDataBase
{
    public class DeleteDataBaseRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
