using DBMS_WebApI.CQRS.DataBases.Commands.DeleteDataBase;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DBMS_WEbApITests.DataBases.Commands
{
    public abstract class DeleteDataBaseTests
    {
        public abstract class DeleteDataBaseTest : BaseTest
        {
            protected readonly DeleteDataBaseRequest _databaseRequest;

            protected readonly DeleteDataBaseHandler _databaseHandler;

            protected DeleteDataBaseTest()
            {
                _databaseRequest = new DeleteDataBaseRequest()
                {
                    Id = 2
                };

                _databaseHandler = new DeleteDataBaseHandler(dataBaseContext);
            }
        }

        public class Handle : DeleteDataBaseTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _databaseHandler.Handle(_databaseRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _databaseRequest.Id = 0;

                var result = _databaseHandler.Handle(_databaseRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }

    }
}
