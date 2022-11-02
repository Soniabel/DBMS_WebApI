using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DBMS_WebApI.Infrastructure.Mapper;

namespace DBMS_WEbApITests.Helpers
{
    public class AutoMapperHelper
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(InitMapper);

        private static MapperConfiguration _configuration;

        public static IMapper Mapper { get; set; } = _mapper.Value;

        private static IMapper InitMapper()
        {
            _configuration = new MapperConfiguration(cfg => cfg.AddProfile<DBMSMappingProfile>());

            return new Mapper(_configuration);
        }
    }
}
