using DBMS_WebApI.CQRS.Cells.Commands.DeleteCell;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DBMS_WEbApITests.Cells.Commands
{
    public abstract class DeleteCellTests
    {
        public abstract class DeleteCellTest : BaseTest
        {
            protected readonly DeleteCellRequest _cellRequest;

            protected readonly DeleteCellHandler _cellHandler;

            protected DeleteCellTest()
            {
                _cellRequest = new DeleteCellRequest()
                {
                    Id = 2
                };

                _cellHandler = new DeleteCellHandler(dataBaseContext);
            }
        }

        public class Handle : DeleteCellTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _cellHandler.Handle(_cellRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _cellRequest.Id = 0;

                var result = _cellHandler.Handle(_cellRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
