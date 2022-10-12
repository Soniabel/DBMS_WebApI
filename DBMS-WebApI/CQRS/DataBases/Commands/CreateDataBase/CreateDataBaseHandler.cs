using AutoMapper;
using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.Entities;
using MediatR;

namespace DBMS_WebApI.CQRS.DataBases.Commands.CreateDataBase
{
    public class CreateDataBaseHandler : IRequestHandler<CreateDataBaseRequest, DataBaseModel>
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _context;

        public CreateDataBaseHandler(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataBaseModel> Handle(CreateDataBaseRequest request, CancellationToken cancellationToken)
        {
            var database = _mapper.Map<DataBase>(request);

            _context.DataBases.Add(database);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DataBaseModel>(database);
        }
    }

}
