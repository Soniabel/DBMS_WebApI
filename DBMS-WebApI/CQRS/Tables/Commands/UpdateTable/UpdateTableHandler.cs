using AutoMapper;
using DBMS_WebApI.CQRS.Tables.Models;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.Tables.Commands.UpdateTable
{
    public class UpdateTableHandler : IRequestHandler<UpdateTableRequest, TableModel>
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _context;

        public UpdateTableHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TableModel> Handle(UpdateTableRequest request, CancellationToken cancellationToken)
        {
            var table = await _context.Tables
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (table is null)
            {
                throw new NotFoundException(nameof(Table), request.Id);
            }

            table.Name = request.Name;
            table.DataBaseId = request.DataBaseId;

            await _context.SaveChangesAsync(cancellationToken);

            var updatedTable = await _context.Tables
               .Include(table => table.Database)
               .Where(table => table.DataBaseId == request.DataBaseId)
               .FirstOrDefaultAsync(x => x.Id == request.Id);

            return _mapper.Map<TableModel>(updatedTable);
        }
    }
}