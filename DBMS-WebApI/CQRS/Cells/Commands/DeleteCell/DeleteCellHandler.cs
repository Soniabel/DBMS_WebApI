using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.Cells.Commands.DeleteCell
{
    public class DeleteCellHandler : IRequestHandler<DeleteCellRequest, int>
    {
        private readonly DataBaseContext _context;

        public DeleteCellHandler(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteCellRequest request, CancellationToken cancellationToken)
        {
            var cell = await _context.Cells.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (cell is null)
            {
                throw new NotFoundException(nameof(Cell), request.Id);
            }

            _context.Cells.Remove(cell);
            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
