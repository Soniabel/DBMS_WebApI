
using DBMS_WebApI.CQRS.Cells.Models;
using MediatR;

namespace DBMS_WebApI.CQRS.Cells.Commands.CreateCell
{
    public class CreateCellRequest : IRequest<CellModel>
    {
        public string Value { get; set; }
        public int RowId { get; set; }
        public int ColumnID { get; set; }
    }
}
