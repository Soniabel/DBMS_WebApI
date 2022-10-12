using AutoMapper;
using DBMS_WebApI.CQRS.Rows.Models;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.Rows.Commands.UpdateRow
{
    public class UpdateRowHandler : IRequestHandler<UpdateRowRequest, RowModel>
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _context;

        public UpdateRowHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RowModel> Handle(UpdateRowRequest request, CancellationToken cancellationToken)
        {
            var row = await _context.Rows
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (row is null)
            {
                throw new NotFoundException(nameof(Row), request.Id);
            }

            row.TableId = request.TableId;

            await _context.SaveChangesAsync(cancellationToken);

            var updatedRow = await _context.Rows
               .Include(row => row.Table)
               .FirstOrDefaultAsync(x => x.Id == request.Id);

            return _mapper.Map<RowModel>(updatedRow);
        }
    }
}
