using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.CQRS.Tables.Commands.CreateTable;
using DBMS_WebApI.CQRS.Tables.Models;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DBMS_WEbApITests.Tables.Commands
{
    public abstract class CreateTableTests
    {
        public abstract class CreateTableTest : BaseTest
        {
            protected readonly CreateTableRequest _tableRequest;

            protected readonly CreateTableHandler _tableHandler;

            protected CreateTableTest()
            {
                _tableRequest = new CreateTableRequest()
                {
                    Name = "TestTable",
                    DataBaseId = 1
                };

                _tableHandler = new CreateTableHandler(dataBaseContext, _mapper);
            }
        }

        public class Handle : CreateTableTest
        {
            [Fact]
            public async Task Table_model_is_returned_is_valid()
            {
                var expectedTable = new TableModel
                {
                    Id = 3,
                    Name = "TestTable",
                    DataBase = new DataBaseModel { Id = 1 , Name = "TestDataBase"}

                };
                var result = await _tableHandler.Handle(_tableRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedTable);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _tableRequest.Name = null;

                var result = _tableHandler.Handle(_tableRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
