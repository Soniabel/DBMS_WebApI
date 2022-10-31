using AutoMapper;
using DBMS_WebApI.CQRS.Tables.Models;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.Tables.Queries.GetTableById
{
    public class GetTableByIdHandler : IRequestHandler<GetTableByIdRequest, TableModel>
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public GetTableByIdHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TableModel> Handle(GetTableByIdRequest request, CancellationToken cancellationToken)
        {
            var table = await _context.Tables.AsNoTracking()
                   .Include(table => table.Database)
                   //.Where(table => table.DataBaseId == request.DataBaseId)
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (table is null)
            {
                throw new NotFoundException(nameof(Table), request.Id);
            }

            return _mapper.Map<TableModel>(table);
        }
    }

}
