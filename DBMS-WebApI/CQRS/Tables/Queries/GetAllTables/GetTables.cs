using DBMS_WebApI.CQRS.Tables.Models;
using DBMS_WebApI.Infrastructure;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DBMS_WebApI.Entities;

namespace DBMS_WebApI.CQRS.Tables.Queries.GetAllTables
{
    public class GetTables : IRequest<TablesList>
    {
        public class GetTablesHandler : IRequestHandler<GetTables, TablesList>
        {
            private readonly IMapper _mapper;
            private readonly DataBaseContext _context;

            public GetTablesHandler(DataBaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<TablesList> Handle(GetTables request, CancellationToken cancellationToken)
            {
                var tables = await _context.Tables.AsNoTracking()
                    .Include(table => table.Database)
                    .Select(tables => _mapper.Map<TableModel>(tables))
                    .ToListAsync(cancellationToken);

                if (tables is null)
                {
                    throw new NotFoundException("Tables is empty!");
                }

                return new TablesList { Tables = tables };
            }
        }
    }
}
