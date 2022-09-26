using AutoMapper;
using DBMS_WebApI.CQRS.Cells.Models;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.Cells.Queries.GetAllCells
{
    public class GetCells : IRequest<CellsList>
    {
        public class GetCellsHandler : IRequestHandler<GetCells, CellsList>
        {
            private readonly IMapper _mapper;
            private readonly DataBaseContext _context;

            public GetCellsHandler(DataBaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CellsList> Handle(GetCells request, CancellationToken cancellationToken)
            {
                var cells = await _context.Cells.AsNoTracking()
                    .Select(cells => _mapper.Map<CellModel>(cells))
                    .ToListAsync(cancellationToken);

                if (cells is null)
                {
                    throw new NotFoundException("Cells is empty!");
                }

                return new CellsList { Cells = cells };
            }
        }
    }
}
