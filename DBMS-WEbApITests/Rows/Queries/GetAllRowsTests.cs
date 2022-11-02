using DBMS_WebApI.CQRS.Rows.Queries.GetAllRows;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static DBMS_WebApI.CQRS.Rows.Queries.GetAllRows.GetRows;

namespace DBMS_WEbApITests.Rows.Queries
{
    public abstract class GetAllRowsTests
    {
        public abstract class GetAllRowsTest : BaseTest
        {
            protected readonly GetRows _rowRequest;

            protected readonly GetRowsHandler _rowHandler;

            protected GetAllRowsTest()
            {
                _rowRequest = new GetRows();

                _rowHandler = new GetRowsHandler(dataBaseContext, _mapper);
            }
        }

        public class Handle : GetAllRowsTest
        {
            [Fact]
            public async Task RowList_is_returned_when_request_is_valid()
            {
                var result = await _rowHandler.Handle(_rowRequest, new CancellationToken());

                result.Rows.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
