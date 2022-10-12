using AutoMapper;
using DBMS_WebApI.CQRS.Columns.Models;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.Columns.Queries.GetAllColumns
{
    public class GetColumns : IRequest<ColumnsList>
    {
        public class GetColumnsHandler : IRequestHandler<GetColumns, ColumnsList>
        {
            private readonly IMapper _mapper;
            private readonly DataBaseContext _context;

            public GetColumnsHandler(DataBaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ColumnsList> Handle(GetColumns request, CancellationToken cancellationToken)
            {
                var columns = await _context.Columns.AsNoTracking()
                    .Select(columns => _mapper.Map<ColumnModel>(columns))
                    .ToListAsync(cancellationToken);

                if (columns is null)
                {
                    throw new NotFoundException("Columns is empty!");
                }

                return new ColumnsList { Columns = columns };
            }
        }
    }
}
