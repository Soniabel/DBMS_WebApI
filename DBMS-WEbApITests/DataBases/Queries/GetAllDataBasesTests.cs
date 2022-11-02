using DBMS_WebApI.CQRS.DataBases.Queries.GetAllDataBases;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static DBMS_WebApI.CQRS.DataBases.Queries.GetAllDataBases.GetDataBases;

namespace DBMS_WEbApITests.DataBases.Queries
{
    public abstract class GetAllDataBasesTests
    {
        public abstract class GetAllDataBasesTest : BaseTest
        {
            protected readonly GetDataBases _databaseRequest;

            protected readonly GetDataBasesHandler _databaseHandler;

            protected GetAllDataBasesTest()
            {
                _databaseRequest = new GetDataBases();

                _databaseHandler = new GetDataBasesHandler(dataBaseContext, _mapper);
            }
        }

        public class Handle : GetAllDataBasesTest
        {
            [Fact]
            public async Task DataBaseList_is_returned_when_request_is_valid()
            {
                var result = await _databaseHandler.Handle(_databaseRequest, new CancellationToken());

                result.DataBases.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
