using DBMS_WebApI.CQRS.Columns.Commands.DeleteColumn;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DBMS_WEbApITests.Columns.Commands
{
    public abstract class DeleteColumnTests
    {
        public abstract class DeleteColumnTest : BaseTest
        {
            protected readonly DeleteColumnRequest _columnRequest;

            protected readonly DeleteColumnHandler _columnHandler;

            protected DeleteColumnTest()
            {
                _columnRequest = new DeleteColumnRequest()
                {
                    Id = 2
                };

                _columnHandler = new DeleteColumnHandler(dataBaseContext);
            }
        }

        public class Handle : DeleteColumnTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _columnHandler.Handle(_columnRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _columnRequest.Id = 0;

                var result = _columnHandler.Handle(_columnRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
