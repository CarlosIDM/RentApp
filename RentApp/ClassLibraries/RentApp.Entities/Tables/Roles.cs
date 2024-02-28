using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentApp.Entities.Tables
{
    [Table("Roles")]
    public class Roles : DefaultColumns
    {
        public Roles()
        {
            this.Users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RolName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
