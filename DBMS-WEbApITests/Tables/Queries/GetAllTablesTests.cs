using DBMS_WebApI.CQRS.Tables.Queries.GetAllTables;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static DBMS_WebApI.CQRS.Tables.Queries.GetAllTables.GetTables;

namespace DBMS_WEbApITests.Tables.Queries
{
    public abstract class GetAllTablesTests
    {
        public abstract class GetAllTablesTest : BaseTest
        {
            protected readonly GetTables _tableRequest;

            protected readonly GetTablesHandler _tableHandler;

            protected GetAllTablesTest()
            {
                _tableRequest = new GetTables();

                _tableHandler = new GetTablesHandler(dataBaseContext, _mapper);
            }
        }

        public class Handle : GetAllTablesTest
        {
            [Fact]
            public async Task TablesList_is_returned_when_request_is_valid()
            {
                var result = await _tableHandler.Handle(_tableRequest, new CancellationToken());

                result.Tables.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
