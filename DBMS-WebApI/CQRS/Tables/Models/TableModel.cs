using DBMS_WebApI.CQRS.DataBases.Models;

namespace DBMS_WebApI.CQRS.Tables.Models
{
    public class TableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DataBaseModel DataBase { get; set; }
    }
}
