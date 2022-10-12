﻿using AutoMapper;
using DBMS_WebApI.CQRS.Rows.Models;
using DBMS_WebApI.Entities;
using MediatR;

namespace DBMS_WebApI.CQRS.Rows.Commands.CreateRow
{
    public class CreateRowHandler : IRequestHandler<CreateRowRequest, RowModel>
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _context;

        public CreateRowHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RowModel> Handle(CreateRowRequest request, CancellationToken cancellationToken)
        {
            var row = _mapper.Map<Row>(request);

            _context.Rows.Add(row);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RowModel>(row);
        }
    }
}
