using MediatR;
using Microsoft.EntityFrameworkCore;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;

namespace DBMS_WebApI.CQRS.Columns.Commands.DeleteColumn
{
    public class DeleteColumnHandler : IRequestHandler<DeleteColumnRequest, int>
    {
        private readonly DataBaseContext _context;

        public DeleteColumnHandler(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteColumnRequest request, CancellationToken cancellationToken)
        {
            var column = await _context.Columns.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (column is null)
            {
                throw new NotFoundException(nameof(Column), request.Id);
            }

            _context.Columns.Remove(column);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
