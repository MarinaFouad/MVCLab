using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
   

        public int Id { get; set; }
  
        public string Name { get; set; }


        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

    }
}
