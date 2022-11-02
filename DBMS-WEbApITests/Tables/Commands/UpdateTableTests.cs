using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.CQRS.Tables.Commands.UpdateTable;
using DBMS_WebApI.CQRS.Tables.Models;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DBMS_WEbApITests.Tables.Commands
{
    public abstract class UpdateTableTests
    {
        public abstract class UpdateTableTest : BaseTest
        {
            protected readonly UpdateTableRequest _tableRequest;

            protected readonly UpdateTableHandler _tableHandler;

            protected  UpdateTableTest()
            {
                _tableRequest = new UpdateTableRequest()
                {
                    Id = 1,
                    Name = "TestTable",
                    DataBaseId = 1
                };

                _tableHandler = new UpdateTableHandler(dataBaseContext, _mapper);
            }

        }

        public class Handle : UpdateTableTest
        {
            [Fact]
            public async Task Table_model_is_returned_when_request_is_valid()
            {
                var expectedTable = new TableModel
                {
                    Id = 1,
                    Name = "TestTable",
                    DataBase = new DataBaseModel { Id = 1, Name = "TestDataBase"}
                };
                var result = await _tableHandler.Handle(_tableRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedTable);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _tableRequest.Id = 0;

                var result = _tableHandler.Handle(_tableRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
