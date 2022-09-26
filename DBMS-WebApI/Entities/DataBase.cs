using System.ComponentModel.DataAnnotations;

namespace DBMS_WebApI.Entities
{
    public class DataBase
    {
        public DataBase()
        {
            Tables = new List<Table>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Name should not be empty")]

        public string Name { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}
