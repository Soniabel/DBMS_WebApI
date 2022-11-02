using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.CQRS.DataBases.Queries.GetDataBaseById;
using DBMS_WEbApITests.Helpers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DBMS_WEbApITests.DataBases.Queries
{
    public abstract class GetDataBaseByIdTests
    {
        public abstract class GetDataBaseByIdTest : BaseTest
        {
            protected readonly GetDataBaseByIdRequest _databaseRequest;

            protected readonly GetDataBaseByIdHandler _databaseHandler;

            protected GetDataBaseByIdTest()
            {
                _databaseRequest = new GetDataBaseByIdRequest()
                {
                    Id = 1
                };

                _databaseHandler = new GetDataBaseByIdHandler(dataBaseContext, _mapper);
            }
        }

        public class Handle : GetDataBaseByIdTest
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
