using DBMS_WebApI.CQRS.Tables.Commands.DeleteTable;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DBMS_WEbApITests.Tables.Commands
{
    public abstract class DeleteTableTests
    {
        public abstract class DeleteTableTest : BaseTest
        {
            protected readonly DeleteTableRequest _tableRequest;

            protected readonly DeleteTableHandler _tableHandler;

            protected DeleteTableTest()
            {
                _tableRequest = new DeleteTableRequest()
                {
                    Id = 3
                };

                _tableHandler = new DeleteTableHandler(dataBaseContext);
            }
        }

        public class Handle : DeleteTableTest
        {
            //[Fact]
            //public async Task Deleted_Id_is_returned_when_request_is_valid()
            //{
            //    var expectedId = 3;

            //    var result = await _tableHandler.Handle(_tableRequest, new CancellationToken());

            //    result.Should().Be(expectedId);
            //}

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
