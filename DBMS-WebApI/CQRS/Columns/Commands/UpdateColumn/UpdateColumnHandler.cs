using AutoMapper;
using DBMS_WebApI.CQRS.Columns.Models;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.Columns.Commands.UpdateColumn
{
    public class UpdateColumnHandler : IRequestHandler<UpdateColumnRequest, ColumnModel>
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _context;

        public UpdateColumnHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ColumnModel> Handle(UpdateColumnRequest request, CancellationToken cancellationToken)
        {
            var column = await _context.Columns
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (column is null)
            {
                throw new NotFoundException(nameof(Column), request.Id);
            }

            column.Name = request.Name;
            column.TypeFullName = request.TypeFullName;
            column.TableId = request.TableId;

            await _context.SaveChangesAsync(cancellationToken);

            var updatedColumn = await _context.Columns
               .Include(column => column.Table)
               .FirstOrDefaultAsync(x => x.Id == request.Id);

            return _mapper.Map<ColumnModel>(updatedColumn);
        }
    }
}
