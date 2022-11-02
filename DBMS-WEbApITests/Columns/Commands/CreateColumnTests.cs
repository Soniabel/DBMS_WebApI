using DBMS_WebApI.CQRS.Columns.Commands.CreateColumn;
using DBMS_WebApI.CQRS.Columns.Models;
using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.CQRS.Tables.Models;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DBMS_WEbApITests.Columns.Commands
{
    public abstract class CreateColumnTests
    {
        public abstract class CreateColumnTest : BaseTest
        {
            protected readonly CreateColumnRequest _columnRequest;

            protected readonly CreateColumnHandler _columnHandler;

            protected CreateColumnTest()
            {
                _columnRequest = new CreateColumnRequest()
                {
                    Name = "TestColumn",
                    TypeFullName = "TestFullName",
                    TableId = 1
                };

                _columnHandler = new CreateColumnHandler(dataBaseContext, _mapper);
            }
        }

        public class Handle : CreateColumnTest
        {
            [Fact]
            public async Task Column_model_is_returned_is_valid()
            {
                var expectedColumn = new ColumnModel
                {
                    Id = 2,
                    Name = "TestColumn",
                    TypeFullName = "TestFullName",
                    Table = new TableModel 
                    { 
                        Id = 1, 
                        Name = "TestTable", 
                        DataBase = new DataBaseModel { Id = 1, Name = "TestDataBase" } 
                    }

                };
                var result = await _columnHandler.Handle(_columnRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedColumn);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _columnRequest.Name = null;

                var result = _columnHandler.Handle(_columnRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
