using DBMS_WebApI.CQRS.Cells.Commands.CreateCell;
using DBMS_WebApI.CQRS.Cells.Models;
using DBMS_WebApI.CQRS.Columns.Models;
using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.CQRS.Rows.Models;
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

namespace DBMS_WEbApITests.Cells.Commands
{
    public abstract class CreateCellTests
    {
        public abstract class CreateCellTest : BaseTest
        {
            protected readonly CreateCellRequest _cellRequest;

            protected readonly CreateCellHandler _cellHandler;

            protected CreateCellTest()
            {
                _cellRequest = new CreateCellRequest()
                {
                    Value = "TestValue",
                    RowId = 1,
                    ColumnID = 1
                };

                _cellHandler = new CreateCellHandler(dataBaseContext, _mapper);
            }
        }

        public class Handle : CreateCellTest
        {
            [Fact]
            public async Task Cell_model_is_returned_is_valid()
            {
                var expectedCell = new CellModel
                {
                    Id = 3,
                    Value = "TestValue",
                    Row = new RowModel
                    {
                        Id = 1,
                        Table = new TableModel
                        {
                            Id = 1,
                            Name = "TestTable",
                            DataBase = new DataBaseModel { Id = 1, Name = "TestDataBase" }
                        }
                    },
                    Column = new ColumnModel
                    {
                        Id = 1,
                        Name = "TestColumn",
                        TypeFullName = "TestFullName",
                        Table = new TableModel
                        {
                            Id = 1,
                            Name = "TestTable",
                            DataBase = new DataBaseModel { Id = 1, Name = "TestDataBase" }
                        }
                    }

                };
                var result = await _cellHandler.Handle(_cellRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedCell);
            }
        }
    }
}
