using AutoMapper;
using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.DataBases.Queries.GetDataBaseById
{
    public class GetDataBaseByIdHandler : IRequestHandler<GetDataBaseByIdRequest, DataBaseModel>
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public GetDataBaseByIdHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataBaseModel> Handle(GetDataBaseByIdRequest request, CancellationToken cancellationToken)
        {
            var database = await _context.DataBases.AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (database is null)
            {
                throw new NotFoundException(nameof(DataBase), request.Id);
            }

            return _mapper.Map<DataBaseModel>(database);
        }
    }

}
