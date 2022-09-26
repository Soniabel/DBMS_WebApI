namespace DBMS_WebApI.CQRS.Cells.Models
{
    public class CellModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int RowId { get; set; }
        public int ColumnID { get; set; }
    }
}
