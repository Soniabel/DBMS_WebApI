using DBMS_WebApI.CQRS.DataBases.Models;
using DBMS_WebApI.CQRS.Tables.Models;

namespace DBMS_WebApI.CQRS.Rows.Models
{
    public class RowModel
    {
        public int Id { get; set; }
        public TableModel Table { get; set; }
    }
}
