using DBMS_WebApI.CQRS.DataBases.Commands.UpdateDataBase;
using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DBMS_WEbApITests.DataBases.Commands
{
    public abstract class UpdateDataBaseTests
    {
        public abstract class UpdateDataBaseTest : BaseTest
        {
            protected readonly UpdateDataBaseRequest _databaseRequest;

            protected readonly UpdateDataBaseHandler _databaseHandler;

            protected UpdateDataBaseTest()
            {
                _databaseRequest = new UpdateDataBaseRequest()
                {
                    Id = 1,
                    Name = "TestDataBase"
                };

                _databaseHandler = new UpdateDataBaseHandler(dataBaseContext, _mapper);
            }

        }

        public class Handle : UpdateDataBaseTest
        {
            [Fact]
            public async Task DataBase_model_is_returned_when_request_is_valid()
            {
                var expectedDataBase = new DataBaseModel
                {
                    Id = 1,
                    Name = "TestDataBase"
                };
                var result = await _databaseHandler.Handle(_databaseRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedDataBase);
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
