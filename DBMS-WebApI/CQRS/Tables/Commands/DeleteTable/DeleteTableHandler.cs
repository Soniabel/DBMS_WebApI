using MediatR;
using Microsoft.EntityFrameworkCore;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;

namespace DBMS_WebApI.CQRS.Tables.Commands.DeleteTable
{
    public class DeleteTableHandler : IRequestHandler<DeleteTableRequest, int>
    {
        private readonly DataBaseContext _context;

        public DeleteTableHandler(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteTableRequest request, CancellationToken cancellationToken)
        {
            var table = await _context.Tables
                .Include(table => table.Database)
                .Where(table => table.DataBaseId == request.DataBaseId)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (table is null)
            {
                throw new NotFoundException(nameof(Table), request.Id);
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }

}
