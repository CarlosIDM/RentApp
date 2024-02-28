using RentApp.Models.Enumeraciones;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace RentApp.Entities.Tables
{
    [Table("Users")]
    public class User : DefaultColumns
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column(Order = 0)]
		public int Id { get; set; }

        [Required]
        [Column(Order =1)]
        public string Name { get; set; }

        [Required]
		[Column(Order = 2)]
		public string LastName { get; set; }

        [Required]
		[Column(Order = 3)]
		public string Email { get; set; }

        [Required]
		[Column(Order = 4)]
		public string Password { get; set; }

        [Required]
		[Column(Order = 5)]
		public DateTime Age { get; set; }

        [Required]
		[Column(Order = 6)]
		public string Sex { get; set; }

		[Column(Order = 7)]
		public string IdSocialRed {  get; set; }

        [Required]
		[Column(Order = 8)]
		public RegisterUser RegisterUser { get; set; }

        public virtual Roles Roles { get; set; }
    }
}
