using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRegister.Models.Tables
{
    public class Persons
    {

        [Key, Column(TypeName = "varchar(36)"), Required, Display(Name = "id")]
        public string Id { get; set; }

        [Required, Column(TypeName = "varchar(30)"), Display(Name = "firstname")]
        public string Firstname { get; set; }

        [Required, Column(TypeName = "varchar(30)")]
        public string Lastname { get; set; }

        [Column(TypeName = "varchar(100)"), RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Invalid email")]
        public string? Email { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? Phone { get; set; }

        public Accounts Accounts { get; set; }
    }
}
