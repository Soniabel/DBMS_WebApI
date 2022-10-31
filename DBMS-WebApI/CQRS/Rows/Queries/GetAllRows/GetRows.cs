using AutoMapper;
using DBMS_WebApI.CQRS.Rows.Models;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.Rows.Queries.GetAllRows
{
    public class GetRows : IRequest<RowsList>
    {
        public class GetRowsHandler : IRequestHandler<GetRows, RowsList>
        {
            private readonly IMapper _mapper;
            private readonly DataBaseContext _context;

            public GetRowsHandler(DataBaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RowsList> Handle(GetRows request, CancellationToken cancellationToken)
            {
                var rows = await _context.Rows.AsNoTracking()
                    .Include(row => row.Table.Database)
                    .Select(rows => _mapper.Map<RowModel>(rows))
                    .ToListAsync(cancellationToken);

                if (rows is null)
                {
                    throw new NotFoundException("Rows is empty!");
                }

                return new RowsList { Rows = rows };
            }
        }
    }
}
