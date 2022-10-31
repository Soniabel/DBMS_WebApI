using DBMS_WebApI.CQRS.Columns.Models;
using DBMS_WebApI.CQRS.Rows.Models;

namespace DBMS_WebApI.CQRS.Cells.Models
{
    public class CellModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public RowModel Row { get; set; }
        public ColumnModel Column { get; set; }
    }
}
