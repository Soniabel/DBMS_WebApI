using DBMS_WebApI.CQRS.DataBases.Commands.CreateDataBase;
using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WEbApITests.Helpers;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace DBMS_WEbApITests.DataBases.Commands
{
    public abstract class CreateDataBaseTests
    {
        public abstract class CreateDataBaseTest : BaseTest
        {
            protected readonly CreateDataBaseRequest _databaseRequest;

            protected readonly CreateDataBaseHandler _databaseHandler;

            protected CreateDataBaseTest()
            {
                _databaseRequest = new CreateDataBaseRequest()
                {
                    Name = "TestDataBase"
                };

                _databaseHandler = new CreateDataBaseHandler(dataBaseContext, _mapper);
            }
        }

        public class Handle : CreateDataBaseTest
        {
            [Fact]
            public async Task DataBase_model_is_returned_is_valid()
            {
                var expectedDataBase = new DataBaseModel
                {
                    Id = 3,
                    Name = "TestDataBase"
                };
                var result = await _databaseHandler.Handle(_databaseRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedDataBase);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _databaseRequest.Name = null;

                var result = _databaseHandler.Handle(_databaseRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
