using DBMS_WebApI.Entities;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_WEbApITests.Helpers
{
    public class BaseTest : IDisposable
    {
        protected readonly DataBaseContext dataBaseContext;

        protected readonly IMapper _mapper;

        public BaseTest()
        {
            dataBaseContext = InitTestDbContext();
            _mapper = AutoMapperHelper.Mapper;
        }

        public void Dispose()
        {
            dataBaseContext.Database.EnsureDeleted();
            dataBaseContext.Dispose();
        }

        public DataBaseContext InitTestDbContext()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new DataBaseContext(options);
            context.Database.EnsureCreated();

            SeedDb(context);
            context.SaveChanges();

            return context;
        }

        private void SeedDb(DataBaseContext context)
        {
            if (!context.DataBases.Any())
            {
                var databases = new List<DataBase>()
                {
                   new DataBase
                   {
                       //Id = 1,
                       Name = "TestDataBase"
                   },
                   new DataBase
                   {
                       //Id = 1,
                       Name = "TestDataBase"
                   }
                };
                context.AddRange(databases);
                context.SaveChanges();
            }

            if (!context.Tables.Any())
            {
                var tables = new List<Table>()
                {
                    new Table 
                    { 
                        //Id = 1, 
                        Name = "TestTable", 
                        DataBaseId = 1
                    },
                    new Table
                    {
                        //Id = 1,
                        Name = "TestTable",
                        DataBaseId = 1
                    }
                };

                context.AddRange(tables);
                context.SaveChanges();
            }

            if (!context.Rows.Any())
            {
                var rows = new List<Row>()
                {
                    new Row { //Id = 1, 
                              TableId = 1 },
                    new Row { //Id = 1, 
                        TableId = 1 }
                };

                context.AddRange(rows);
                context.SaveChanges();
            }

            if (!context.Columns.Any())
            {
                var columns = new List<Column>()
                {
                    new Column
                    {
                        //Id = 1,
                        Name = "TestColumn",
                        TypeFullName = "TestFullName",
                        TableId = 1
                    },
                    new Column
                    {
                        //Id = 1,
                        Name = "TestColumn",
                        TypeFullName = "TestFullName",
                        TableId = 1
                    }
                };

                context.AddRange(columns);
                context.SaveChanges();
            }

            if (!context.Cells.Any())
            {
                var cells = new List<Cell>()
                {
                    new Cell {
                        //Id = 1,
                        Value = "TestValue",
                        RowId = 1,
                        ColumnID = 1
                    },
                    new Cell {
                        //Id = 1,
                        Value = "TestValue",
                        RowId = 1,
                        ColumnID = 1
                    }
                };

                context.AddRange(cells);
                context.SaveChanges();
            }
        }
    }
}
