using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.CQRS.Rows.Commands.CreateRow;
using DBMS_WebApI.CQRS.Rows.Models;
using DBMS_WebApI.CQRS.Tables.Models;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DBMS_WEbApITests.Rows.Commands
{
    public abstract class CreateRowTests
    {
        public abstract class CreateRowTest : BaseTest
        {
            protected readonly CreateRowRequest _rowRequest;

            protected readonly CreateRowHandler _rowHandler;

            protected CreateRowTest()
            {
                _rowRequest = new CreateRowRequest()
                {
                    DataBaseId = 1,
                    TableId = 1
                };

                _rowHandler = new CreateRowHandler(dataBaseContext, _mapper);
            }
        }

        public class Handle : CreateRowTest
        {
            [Fact]
            public async Task Row_model_is_returned_is_valid()
            {
                var expectedRow = new RowModel
                {
                    Id = 2,
                    Table = new TableModel
                    {
                        Id = 1,
                        Name = "TestTable",
                        DataBase = new DataBaseModel { Id = 1, Name = "TestDataBase" }
                    }

                };
                var result = await _rowHandler.Handle(_rowRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedRow);
            }
        }
    }
}
