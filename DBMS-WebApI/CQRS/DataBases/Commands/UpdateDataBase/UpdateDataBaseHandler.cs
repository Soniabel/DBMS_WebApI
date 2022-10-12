using AutoMapper;
using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.Entities;
using DBMS_WebApI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.CQRS.DataBases.Commands.UpdateDataBase
{
    public class UpdateDataBaseHandler : IRequestHandler<UpdateDataBaseRequest, DataBaseModel>
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _context;

        public UpdateDataBaseHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataBaseModel> Handle(UpdateDataBaseRequest request, CancellationToken cancellationToken)
        {
            var database = await _context.DataBases
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (database is null)
            {
                throw new NotFoundException(nameof(DataBase), request.Id);
            }

            database.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DataBaseModel>(database
                );
        }
    }
}
