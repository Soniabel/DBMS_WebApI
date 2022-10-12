using MediatR;
using Microsoft.EntityFrameworkCore;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;

namespace DBMS_WebApI.CQRS.Rows.Commands.DeleteRow
{
    public class DeleteRowHandler : IRequestHandler<DeleteRowRequest, int>
    {
        private readonly DataBaseContext _context;

        public DeleteRowHandler(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteRowRequest request, CancellationToken cancellationToken)
        {
            var row = await _context.Rows.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (row is null)
            {
                throw new NotFoundException(nameof(Row), request.Id);
            }

            _context.Rows.Remove(row);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
