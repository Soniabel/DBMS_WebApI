using DBMS_WebApI.Infrastructure;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DBMS_WebApI.Entities;
using DBMS_WebApI.CQRS.DataBases.Models;

namespace DBMS_WebApI.CQRS.DataBases.Queries.GetAllDataBases
{
    public class GetDataBases : IRequest<DataBaseList>
    {
        public class GetDataBasesHandler : IRequestHandler<GetDataBases, DataBaseList>
        {
            private readonly IMapper _mapper;
            private readonly DataBaseContext _context;

            public GetDataBasesHandler(DataBaseContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DataBaseList> Handle(GetDataBases request, CancellationToken cancellationToken)
            {
                var databases = await _context.DataBases.AsNoTracking()
                    .Select(databases => _mapper.Map<DataBaseModel>(databases))
                    .ToListAsync(cancellationToken);

                if (databases is null)
                {
                    throw new NotFoundException("No databases!");
                }

                return new DataBaseList { DataBases = databases };
            }
        }
    }

}
