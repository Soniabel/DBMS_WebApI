using DBMS_WebApI.CQRS.Cells.Queries.GetAllCells;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static DBMS_WebApI.CQRS.Cells.Queries.GetAllCells.GetCells;

namespace DBMS_WEbApITests.Cells.Queries
{
    public abstract class GetAllCellsTests
    {
        public abstract class GetAllCellsTest : BaseTest
        {
            protected readonly GetCells _cellRequest;

            protected readonly GetCellsHandler _cellHandler;

            protected GetAllCellsTest()
            {
                _cellRequest = new GetCells();

                _cellHandler = new GetCellsHandler(dataBaseContext, _mapper);
            }
        }

        public class Handle : GetAllCellsTest
        {
            [Fact]
            public async Task CellList_is_returned_when_request_is_valid()
            {
                var result = await _cellHandler.Handle(_cellRequest, new CancellationToken());

                result.Cells.Should().HaveCount(x => x >= 1);
            }
        }
    }
}
