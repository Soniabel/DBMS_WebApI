using DBMS_WebApI.CQRS.Tables.Models;

namespace DBMS_WebApI.CQRS.Columns.Models
{
    public class ColumnModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TypeFullName { get; set; }

        public TableModel Table { get; set; }
    }
}
