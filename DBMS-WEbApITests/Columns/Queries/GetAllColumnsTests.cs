using DBMS_WebApI.CQRS.Columns.Queries.GetAllColumns;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static DBMS_WebApI.CQRS.Columns.Queries.GetAllColumns.GetColumns;

namespace DBMS_WEbApITests.Columns.Queries
{
    public abstract class GetAllColumnsTests
    {
        public abstract class GetAllColumnsTest : BaseTest
        {
            protected readonly GetColumns _columnRequest;

            protected readonly GetColumnsHandler _columnHandler;

            protected GetAllColumnsTest()
            {
                _columnRequest = new GetColumns();

                _columnHandler = new GetColumnsHandler(dataBaseContext, _mapper);
            }
        }

        public class Handle : GetAllColumnsTest
        {
            [Fact]
            public async Task ColumnList_is_returned_when_request_is_valid()
            {
                var result = await _columnHandler.Handle(_columnRequest, new CancellationToken());

                result.Columns.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
