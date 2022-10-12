using AutoMapper;
using DBMS_WebApI.CQRS.Cells.Commands.CreateCell;
using DBMS_WebApI.CQRS.Cells.Models;
using DBMS_WebApI.CQRS.Columns.Commands.CreateColumn;
using DBMS_WebApI.CQRS.Columns.Models;
using DBMS_WebApI.CQRS.DataBases.Commands.CreateDataBase;
using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.CQRS.Rows.Commands.CreateRow;
using DBMS_WebApI.CQRS.Rows.Models;
using DBMS_WebApI.CQRS.Tables.Commands.CreateTable;
using DBMS_WebApI.CQRS.Tables.Models;
using DBMS_WebApI.Entities;

namespace DBMS_WebApI.Infrastructure.Mapper
{
    public class DBMSMappingProfile : Profile
    {
        public DBMSMappingProfile()
        {
            CreateMap<Cell, CellModel>().ReverseMap();
            CreateMap<CreateCellRequest, Cell>().ReverseMap();

            CreateMap<Column, ColumnModel>().ReverseMap();
            CreateMap<CreateColumnRequest, Column>().ReverseMap();

            CreateMap<DataBase, DataBaseModel>().ReverseMap();
            CreateMap<CreateDataBaseRequest, DataBase>().ReverseMap();

            CreateMap<Row, RowModel>().ReverseMap();
            CreateMap<CreateRowRequest, Row>().ReverseMap();

            CreateMap<Table, TableModel>().ReverseMap();
            CreateMap<CreateTableRequest, Table>().ReverseMap();
        }
    }
}
