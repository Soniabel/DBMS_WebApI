namespace DBMS_WebApI.CQRS.Columns.Models
{
    public class ColumnModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TypeFullName { get; set; }

        public int TableId { get; set; }
    }
}
