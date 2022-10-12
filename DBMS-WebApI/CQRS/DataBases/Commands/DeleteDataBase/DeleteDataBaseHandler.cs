using MediatR;
using Microsoft.EntityFrameworkCore;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;

namespace DBMS_WebApI.CQRS.DataBases.Commands.DeleteDataBase
{
    public class DeleteDataBaseHandler : IRequestHandler<DeleteDataBaseRequest, int>
    {
        private readonly DataBaseContext _context;

        public DeleteDataBaseHandler(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteDataBaseRequest request, CancellationToken cancellationToken)
        {
            var database = await _context.DataBases.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (database is null)
            {
                throw new NotFoundException(nameof(DataBase), request.Id);
            }

            _context.DataBases.Remove(database);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }

}
