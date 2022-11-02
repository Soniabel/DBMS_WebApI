using DBMS_WebApI.CQRS.Rows.Commands.DeleteRow;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DBMS_WEbApITests.Rows.Commands
{
    public abstract class DeleteRowTests
    {
        public abstract class DeleteRowTest : BaseTest
        {
            protected readonly DeleteRowRequest _rowRequest;

            protected readonly DeleteRowHandler _rowHandler;

            protected DeleteRowTest()
            {
                _rowRequest = new DeleteRowRequest()
                {
                    Id = 2
                };

                _rowHandler = new DeleteRowHandler(dataBaseContext);
            }
        }

        public class Handle : DeleteRowTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = 2;

                var result = await _rowHandler.Handle(_rowRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _rowRequest.Id = 0;

                var result = _rowHandler.Handle(_rowRequest, new CancellationToken());

                result.Exception.Should().NotBeNull();
            }
        }
    }
}
