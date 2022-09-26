using System.ComponentModel.DataAnnotations;

namespace DBMS_WebApI.Entities
{
    public class Table
    {
        public Table()
        {
            Columns = new List<Column>();
            Rows = new List<Row>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Name should not be empty")]

        public string Name { get; set; }
        public int DataBaseId { get; set; }
        public DataBase Database { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
        public virtual ICollection<Row> Rows { get; set; }
    }
}
