using AutoMapper;
using DBMS_WebApI.CQRS.Columns.Models;
using DBMS_WebApI.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.Columns.Commands.CreateColumn
{
    public class CreateColumnHandler : IRequestHandler<CreateColumnRequest, ColumnModel>
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _context;

        public CreateColumnHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ColumnModel> Handle(CreateColumnRequest request, CancellationToken cancellationToken)
        {
            var column = _mapper.Map<Column>(request);

            _context.Columns.Add(column);
            await _context.SaveChangesAsync(cancellationToken);

            var createdColumn = _context.Columns
                .Include(column => column.Table).ThenInclude(column => column.Database)
                .FirstOrDefault(column => column.Id == column.Id);

            return _mapper.Map<ColumnModel>(createdColumn);
        }
    }
}
