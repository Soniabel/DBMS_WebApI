using AutoMapper;
using DBMS_WebApI.CQRS.Cells.Models;
using DBMS_WebApI.Entities;
using MediatR;

namespace DBMS_WebApI.CQRS.Cells.Commands.CreateCell
{
    public class CreateCellHandler : IRequestHandler<CreateCellRequest, CellModel>
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _context;

        public CreateCellHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CellModel> Handle(CreateCellRequest request, CancellationToken cancellationToken)
        {
            var cell = _mapper.Map<Cell>(request);

            _context.Cells.Add(cell);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CellModel>(cell);
        }
    }
}
