using AutoMapper;
using DBMS_WebApI.CQRS.Tables.Models;
using DBMS_WebApI.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.Tables.Commands.CreateTable
{
    public class CreateTableHandler : IRequestHandler<CreateTableRequest, TableModel>
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _context;

        public CreateTableHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TableModel> Handle(CreateTableRequest request, CancellationToken cancellationToken)
        {
            var table = _mapper.Map<Table>(request);

            _context.Tables.Add(table);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TableModel>(table);
        }
    }
}
